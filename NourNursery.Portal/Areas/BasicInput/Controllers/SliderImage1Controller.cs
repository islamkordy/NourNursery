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
    public class SliderImage1Controller : BaseController
    {
        #region Services
        private readonly ISlidersService _thisService;
        private IWebHostEnvironment _hostingEnvironment;
        #endregion

        #region Constructor
        public SliderImage1Controller(ISlidersService thisService, ICommonService commonService, IWebHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
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
            var result = await _thisService.GetAllByTypeAsync(1);
            return PartialView(result);
        }

        public async Task<IActionResult> Create()
        {
           SlidersVm Obj = new SlidersVm();
            //ViewBag.ConditionerTypeId =await _commonService.FindAllConditionerTypes();
            //ViewBag.RoomTypeId = await _commonService.FindAllRoomTypes();

            return PartialView("~/Areas/BasicInput/Views/SliderImage1/Create.cshtml", Obj);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SlidersVm viewModel, IFormFile Image)
        {
            viewModel.UserId = UserData.UserId;
            if (Image != null)
            {
                var FileName = Image.FileName;
                var path = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Uploads", "Media");

                string imgPath = Path.Combine(path, FileName);
                if (System.IO.File.Exists(imgPath))
                {
                    FileName = DateTime.Now.ToString("ddMMyyyhhMMssfff") + FileName;
                }
                if (Image.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(path, FileName), FileMode.Create))
                    {
                        await Image.CopyToAsync(fileStream);
                    }
                    viewModel.Image = "Uploads/Media/" + FileName;
                }
            }

            var res = false;
            if (viewModel.Id == 0)
                res = await _thisService.AddAsync(viewModel);
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
            var path = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Uploads", "Media",
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
            SlidersVm obj = await _thisService.GetByIdAsync(id);

            return PartialView("~/Areas/BasicInput/Views/SliderImage1/Create.cshtml", obj);
        }


        public async Task<IActionResult> Details(int id)
        {
            return PartialView(await _thisService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            SlidersVm obj = new SlidersVm();
            obj.Id = id;
            return PartialView("~/Areas/BasicInput/Views/SliderImage1/Delete.cshtml", obj);
        }


        [HttpPost]

        public async Task<JsonResult> DeleteRow(int Id)
        {
            if (await _thisService.DeleteAsync(Id))
            {
                return Json("success," + GlobalRes.Messagedelete);
            }
            else
                return Json("error," + GlobalRes.MessageError);
        }


        #endregion
    }
}
