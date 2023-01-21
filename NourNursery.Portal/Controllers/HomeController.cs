using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NourNursery.Portal.Models;
using Domain.Abstracts.BasicInput;
using Models.ViewModel.BasicInput;
using Portal.Resource.GlobalRes;
using NourNursery.Portal.CustomAttributes;
using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;

namespace NourNursery.Portal.Controllers
{
    public class HomeController : BaseController
    {

      
        #region Services
        private readonly IFrontService _thisService;
        private readonly ILogger<HomeController> _logger;

        #endregion

        #region Constructor
        public HomeController(IFrontService thisService, ICommonService commonService, IHttpContextAccessor httpContextAccessor)
        : base(httpContextAccessor, commonService)
        {
            _thisService = thisService;
            //   _commonService = new CommonService(lookupService);
        }


        #endregion

        [AllowAnonymous]
        [Route("ChangeLanguage/{culture}/{returnUrl}")]
        [HttpGet]
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            culture = HttpUtility.UrlDecode(culture);
            returnUrl = HttpUtility.UrlDecode(returnUrl);

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
            if (culture == "ar-EG")
            {
                var en = new CultureInfo("en-US");
                newCulture.DateTimeFormat = en.DateTimeFormat;
            }

            CultureInfo.DefaultThreadCurrentCulture = newCulture;
            CultureInfo.DefaultThreadCurrentUICulture = newCulture;

            if (!Url.IsLocalUrl(returnUrl))
            {
                return Redirect("/");
            }

            return Redirect(returnUrl);
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _thisService.GetAllFrontData();
            return View(obj);
        }
        
        public async Task<IActionResult> Product()
        {
            var obj = await _thisService.GetAllFrontProductData();
            return View(obj);
        }
        public async Task<IActionResult> ProductDetails(int Id)
        {
            var obj = await _thisService.GetAllFrontProductDetails(Id);
            return View(obj);
        }

        //ContactUs
        public async Task<IActionResult> contact_us ()
        {
            var obj = await _thisService.GetAllFrontData();
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> contact_us(ContactUsVm model)
        {
            var res = await _thisService.AddAsync(model);
            if (res)
            {
                return Json("success," + GlobalRes.MessageSuccuss.ToString());
            }
            else
                return Json("error," + GlobalRes.MessageError.ToString());
        }


        public async Task<IActionResult> Faq()
        {
            var obj = await _thisService.GetAllFrontDataFaqs();
            return View(obj);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
