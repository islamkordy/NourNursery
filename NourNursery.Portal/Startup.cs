using AutoMapper;
using Domain.Abstracts;
using Domain.Abstracts.Administration;
using Domain.Abstracts.BasicInput;
using Domain.Entities.Context;
using Domain.Services;
using Domain.Services.Administration;
using Domain.Services.Base;
using Domain.Services.BasicInput;
using Library.Helpers.APIUtilities;
using Library.Helpers.Repository;
using Library.Helpers.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Models.ViewModel.Mapping;
using NourNursery.Portal.CustomAttributes;
using System.Collections.Generic;
using System.Globalization;

namespace NourNursery.Portal
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment _environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NourNurseryContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                   .UseLazyLoadingProxies();//false
            });
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            var arabCulture = new CultureInfo("ar-EG");
            var enCulture = new CultureInfo("en-US");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
               {
                enCulture,
                arabCulture
                };
                options.DefaultRequestCulture = new RequestCulture("ar-EG", uiCulture: "ar-EG");
                //  options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                };
            });

            services.AddMvc();
            services.AddControllersWithViews();
            services.AddAuthentication("ProjectPortalCookies")
          .AddCookie("ProjectPortalCookies", options =>
          {
              options.Cookie.HttpOnly = true;
              options.Cookie.SecurePolicy = _environment.IsDevelopment()
                ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
              options.Cookie.SameSite = SameSiteMode.Lax;
          });
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
                options.HttpOnly = HttpOnlyPolicy.None;
                options.Secure = _environment.IsDevelopment()
                  ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
            });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();





            #region Services

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<DbContext, NourNurseryContext>();
            services.AddSingleton<ISeedData, SeedData>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IActionResultResponseHandler, ActionResultResponseHandler>();
            services.AddTransient<IRepositoryActionResult, RepositoryActionResult>();
            services.AddScoped<ISaveFiles, SaveFiles>();
            services.AddTransient<IRepositoryResult, RepositoryResult>();

            services.AddTransient(typeof(IBaseService<,,,,>), typeof(BaseService<,,,,>));


            services.AddTransient(typeof(IUnitOfWork<,>), typeof(UnitOfWork<,>));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ILookupService, LookupService>();
            services.AddTransient<ICommonService, CommonService>();


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IFrontService, FrontService>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IFaqsService, FaqsService>();
            services.AddScoped<ISlidersService, SlidersService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            #endregion


            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseCookiePolicy();
            app.UseAuthorization();


            var localizationOption = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizationOption.Value);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                  //   pattern: "{controller=Home}/{action=Index}/{id?}");
                  pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
