using Domain.Abstracts.BasicInput;
using NourNursery.Portal.Controllers;
using NourNursery.Portal.CustomAttributes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModel.BasicInput;
using Newtonsoft.Json;
using Portal.Resource.GlobalRes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NourNursery.Portal.Areas.BasicInput.Controllers
{
    [Area("BasicInput")]
    public class FaqsController : BaseController
    {
        #region Services
        private readonly IFaqsService _thisService;
        private IWebHostEnvironment _hostingEnvironment;
        #endregion

        #region Constructor
        public FaqsController(IFaqsService thisService, ICommonService commonService, IWebHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
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

        public async Task<IActionResult> Create()
        {
            FaqsVm Obj = new FaqsVm();
            //ViewBag.ConditionerTypeId =await _commonService.FindAllConditionerTypes();
            //ViewBag.RoomTypeId = await _commonService.FindAllRoomTypes();

            return PartialView("~/Areas/BasicInput/Views/Faqs/Create.cshtml", Obj);
        }
        [HttpPost]
        public async Task<IActionResult> Create(FaqsVm viewModel)
        {
            viewModel.UserId = UserData.UserId;
            if (!string.IsNullOrWhiteSpace(viewModel.FaqsDetailsStr))
                viewModel.FaqsDetails = JsonConvert.DeserializeObject<List<FaqsDetailsVm>>(viewModel.FaqsDetailsStr);
            foreach (var item in viewModel.FaqsDetails)
            {
                item.CreateUserId = UserData.UserId;
            }



            var res = false;
            if (viewModel.Id == 0)
             res =await _thisService.AddAsync(viewModel);
            else
                res = await _thisService.UpdateAsync(viewModel);

            if (res)
            {
                return Json("success," + GlobalRes.MessageSuccuss.ToString());
            }
            else
                return Json("error," + GlobalRes.MessageError.ToString());

        }

        public FileResult DownloadAttachment(string FileName)
        {
            var path = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Uploads", "FeaturesImages",
Path.GetFileName(FileName));
            if (System.IO.File.Exists(path))
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(path);
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, FileName);
            }
            return null;
        }
        public async Task<IActionResult> Edit(int id)
        {
            FaqsVm obj =await _thisService.GetByIdAsync(id);
          
            return PartialView("~/Areas/BasicInput/Views/Faqs/Create.cshtml", obj);
        }

      
        public async Task<IActionResult> Details(int id)
        {
            return PartialView(await _thisService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            FaqsVm obj = new FaqsVm();
            obj.Id = id;
            return PartialView("~/Areas/BasicInput/Views/Faqs/Delete.cshtml", obj);
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
