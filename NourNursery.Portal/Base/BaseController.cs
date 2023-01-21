using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using NourNursery.Portal.CustomAttributes;
using Library.Helpers.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModel.Administration;

namespace NourNursery.Portal.Controllers
{
    [ResponseCache(NoStore = true, Duration = 0, Location = ResponseCacheLocation.None)]
    public class BaseController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly ICommonService _commonService;
        public UserVm model;
        public BaseController(IHttpContextAccessor httpContextAccessor, ICommonService commonService = null)
        {
            _httpContextAccessor = httpContextAccessor;
            _commonService = commonService;
             model = new UserVm();
           
        }

        public string GetClaimValue(string type)
        {

            var user = User.Claims.First(t => t.Type == type).Value;
            var userId = _httpContextAccessor.HttpContext.User.Claims.First(t => t.Type == type).Value;
            return userId;
        }
        public async void SetClaimValue(string type,string value)
        {
            var claims = User.Claims;
            var claimsIdentity = new ClaimsIdentity(claims, "ProjectPortalCookies");

            // check for existing claim and remove it
            var existingClaim = claimsIdentity.FindFirst(type);
            if (existingClaim != null)
            {
                // update claim value
                claimsIdentity.RemoveClaim(existingClaim);
                claimsIdentity.AddClaim(new Claim(type, value));
                var authProperties = new AuthenticationProperties();
                await HttpContext.SignInAsync("ProjectPortalCookies", new ClaimsPrincipal(claimsIdentity), authProperties);
            }
        }


        protected virtual  UserVm UserData
        {
            get
            {
                model.UserId =int.Parse(User.Claims.First(t => t.Type == "UserId").Value.ToString());
                model.NameAr = User.Claims.First(t => t.Type == "NameAr").Value;
                model.NameEn = User.Claims.First(t => t.Type == "NameEn").Value;
                //model.Company = int.Parse(User.Claims.First(t => t.Type == "Company").Value.ToString());
                //model.Branch = int.Parse(User.Claims.First(t => t.Type == "Branch").Value.ToString());
                model.Name = ResourcesReader.IsArabic ? User.Claims.First(t => t.Type == "NameAr").Value: User.Claims.First(t => t.Type == "NameEn").Value;


                return model;
            }
        }

        public IActionResult ToggleLanguage(string culture, string returnUrl)
        {
            HttpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                 new CookieOptions
                 {
                     Expires = DateTimeOffset.UtcNow.AddYears(1),
                     IsEssential = true,
                     Path = "/",
                     HttpOnly = false,
                 });

            CultureInfo newCulture = new CultureInfo(culture);

            CultureInfo.DefaultThreadCurrentCulture = newCulture;
            CultureInfo.DefaultThreadCurrentUICulture = newCulture;

            if (!Url.IsLocalUrl(returnUrl))
            {
                return Redirect("/");
            }

            return Redirect(returnUrl);
        }

    }
}
