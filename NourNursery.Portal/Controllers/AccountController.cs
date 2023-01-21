using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Abstracts.Administration;
using Library.Helpers.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModel.Administration;

namespace NourNursery.Portal.Controllers
{
    public class AccountController : BaseController
    {
        #region Services
        private readonly IUserService _thisService;
        private IWebHostEnvironment _hostingEnvironment;
        // private readonly CommonService _commonService;
        EncryptEngin _EncryptEngin = new EncryptEngin();
        #endregion

        #region Constructor
        public AccountController(IUserService thisService, IWebHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
          : base(httpContextAccessor)
        {
            _thisService = thisService;
            _hostingEnvironment = hostingEnvironment;
         //   _commonService = new CommonService(lookupService);
        }
        #endregion

        public IActionResult Login()
        {
            LoginModelVm obj = new LoginModelVm();
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModelVm obj)
        {
            LoginModelVm model = new LoginModelVm();
            if (ModelState.IsValid)
            {
                try
                {
                    model.Username = obj.Username;
                    model.Branch = obj.Branch;
             //       model.Password = obj.Password.Trim();//_EncryptEngin.Encrypt(obj.Username.Trim().ToLower() + "♪" + obj.Password.Trim(), "icat2056913!", true);
                    model.Password = _EncryptEngin.Encrypt( obj.Password.Trim(), "icat2056913!", true);
                    var user =  await _thisService.UserLogin(model);
                    if (user == null )
                    {
                        ModelState.AddModelError("", "UserNotFound");
                        return View("Login", model);
                    }
                    else
                    {
                        var claims = new[] {
                                new Claim("UserId",user.Id.ToString()),
                                new Claim("NameEn",user.NameEn.ToString()),
                                new Claim("NameAr",user.NameAr.ToString()),
                                //new Claim("Company",user.Company.ToString()),
                                //new Claim("Branch",user.Branch.ToString()),
                                new Claim("Name",!ResourcesReader.IsArabic ? user.NameEn.ToString(): user.NameAr.ToString()),
                            };

                        var claimsIdentity = new ClaimsIdentity(claims, "ProjectPortalCookies");
                        var authProperties = new AuthenticationProperties();

                        await HttpContext.SignInAsync("ProjectPortalCookies", new ClaimsPrincipal(claimsIdentity), authProperties);

                        //user log
                        string path = HttpContext.Request.Path;

                        return RedirectToAction("Index", "About",new {area= "BasicInput" });
                    }
                }
                catch (Exception e)
                {
                    //ModelState.AddModelError("", Resource.AuthManagement_Controllers_ErrorInLogin);
                    //return FormView("HeadLogin", model);
                }
            }
            return View("Login", model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("ProjectPortalCookies");
            return RedirectToAction("Login", "Account");
        }
    }
}
