using Domain.Abstracts.BasicInput;
using NourNursery.Portal.Controllers;
using NourNursery.Portal.CustomAttributes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModel.BasicInput;
using Portal.Resource.GlobalRes;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NourNursery.Portal.Areas.BasicInput.Controllers
{
    [Area("BasicInput")]
    public class RequestController : BaseController
    {
        #region Services
        private readonly IRequestService _thisService;
        private IWebHostEnvironment _hostingEnvironment;
        #endregion

        #region Constructor
        public RequestController(IRequestService thisService, ICommonService commonService, IWebHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
          : base(httpContextAccessor, commonService)
        {
            _thisService = thisService;
            _hostingEnvironment = hostingEnvironment;
            //   _commonService = new CommonService(lookupService);
        }
        #endregion


        #region Actions

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Search()
        {
            var result =await _thisService.GetAllAsync();
            return PartialView(result);
        }

     
        public async Task<IActionResult> Details(int id)
        {
            return PartialView(await _thisService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ContactUsVm obj = new ContactUsVm();
            obj.Id = id;
            return PartialView("~/Areas/BasicInput/Views/Request/Delete.cshtml", obj);
        }
        [HttpPost]
        public async Task<JsonResult> DeleteRow(int Id)
        {
            if (await _thisService.DeleteAsync( Id) )
            {
                return Json("success," + GlobalRes.Messagedelete);
            }
            else
                return Json("error," + GlobalRes.MessageError);
        }


        #endregion
    }
}
