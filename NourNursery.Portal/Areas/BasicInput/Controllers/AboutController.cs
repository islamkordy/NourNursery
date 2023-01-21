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
    public class AboutController : BaseController
    {
        #region Services
        private readonly IAboutService _thisService;
        private IWebHostEnvironment _hostingEnvironment;
        #endregion

        #region Constructor
        public AboutController(IAboutService thisService, ICommonService commonService, IWebHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
          : base(httpContextAccessor, commonService)
        {
            _thisService = thisService;
            _hostingEnvironment = hostingEnvironment;
            //   _commonService = new CommonService(lookupService);
        }
        #endregion


        #region Actions

        public async Task<IActionResult> Index()
        {
            AboutVm Obj = await _thisService.GetByIdAsync(1);
            if (Obj == null)
                Obj = new AboutVm();
            return View(Obj);
        }
      

      
        [HttpPost]
        public async Task<IActionResult> Create(AboutVm viewModel, IFormFile Logo, IFormFile Logo2, IFormFile VisionImage)
        {
            viewModel.UserId = UserData.UserId;
            if (Logo != null)
            {
                var FileName = Logo.FileName;
                var path = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Uploads", "Logos");

                string imgPath = Path.Combine(path, FileName);
                if (System.IO.File.Exists(imgPath))
                {
                    FileName = DateTime.Now.ToString("ddMMyyyhhMMssfff") + FileName;
                }
                if (Logo.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(path, FileName), FileMode.Create))
                    {
                        await Logo.CopyToAsync(fileStream);
                    }
                    viewModel.Logo = "Uploads/Logos/" + FileName;
                }
            }
            if (Logo2 != null)
            {
                var FileName = Logo2.FileName;
                var path = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Uploads", "Logos");

                string imgPath = Path.Combine(path, FileName);
                if (System.IO.File.Exists(imgPath))
                {
                    FileName = DateTime.Now.ToString("ddMMyyyhhMMssfff") + FileName;
                }
                if (Logo2.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(path, FileName), FileMode.Create))
                    {
                        await Logo2.CopyToAsync(fileStream);
                    }
                    viewModel.Logo2 = "Uploads/Logos/" + FileName;
                }
            }
            if (VisionImage != null)
            {
                var FileName = VisionImage.FileName;
                var path = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Uploads", "Logos");

                string imgPath = Path.Combine(path, FileName);
                if (System.IO.File.Exists(imgPath))
                {
                    FileName = DateTime.Now.ToString("ddMMyyyhhMMssfff") + FileName;
                }
                if (VisionImage.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(path, FileName), FileMode.Create))
                    {
                        await VisionImage.CopyToAsync(fileStream);
                    }
                    viewModel.VisionImage = "Uploads/Logos/" + FileName;
                }
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
            var path = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Uploads", "Logos",
            Path.GetFileName(FileName));
            if (System.IO.File.Exists(path))
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(path);
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, FileName);
            }
            return null;
        }

        #endregion
    }
}
