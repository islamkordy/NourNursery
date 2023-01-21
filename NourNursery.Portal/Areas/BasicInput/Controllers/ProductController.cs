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
    public class ProductController : BaseController
    {
        #region Services
        private readonly IProductService _thisService;
        private IWebHostEnvironment _hostingEnvironment;
        #endregion

        #region Constructor
        public ProductController(IProductService thisService, ICommonService commonService, IWebHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
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
            var result = await _thisService.GetAllAsync();
            return PartialView(result);
        }

        public async Task<IActionResult> Create()
        {
            ProductVm Obj = new ProductVm();
            ViewBag.CategoryId = await _commonService.FindAllCategory();
            //ViewBag.RoomTypeId = await _commonService.FindAllRoomTypes();

            return PartialView("~/Areas/BasicInput/Views/Product/Create.cshtml", Obj);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductVm viewModel, IFormFile Image1,IFormFile Image2,IFormFile Image3
            ,IFormFile Image4,IFormFile Image5)
        {
            viewModel.UserId = UserData.UserId;
            if (Image1 != null)
            {
                var FileName = Image1.FileName;
                var path = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Uploads", "Product");

                string imgPath = Path.Combine(path, FileName);
                if (System.IO.File.Exists(imgPath))
                {
                    FileName = DateTime.Now.ToString("ddMMyyyhhMMssfff") + FileName;
                }
                if (Image1.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(path, FileName), FileMode.Create))
                    {
                        await Image1.CopyToAsync(fileStream);
                    }
                    viewModel.Image1 = "Uploads/Product/" + FileName;
                }
            }
            
            if (Image2 != null)
            {
                var FileName = Image2.FileName;
                var path = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Uploads", "Product");

                string imgPath = Path.Combine(path, FileName);
                if (System.IO.File.Exists(imgPath))
                {
                    FileName = DateTime.Now.ToString("ddMMyyyhhMMssfff") + FileName;
                }
                if (Image2.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(path, FileName), FileMode.Create))
                    {
                        await Image2.CopyToAsync(fileStream);
                    }
                    viewModel.Image2 = "Uploads/Product/" + FileName;
                }
            }
            
            if (Image3 != null)
            {
                var FileName = Image3.FileName;
                var path = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Uploads", "Product");

                string imgPath = Path.Combine(path, FileName);
                if (System.IO.File.Exists(imgPath))
                {
                    FileName = DateTime.Now.ToString("ddMMyyyhhMMssfff") + FileName;
                }
                if (Image3.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(path, FileName), FileMode.Create))
                    {
                        await Image3.CopyToAsync(fileStream);
                    }
                    viewModel.Image3 = "Uploads/Product/" + FileName;
                }
            }
            
            if (Image4 != null)
            {
                var FileName = Image4.FileName;
                var path = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Uploads", "Product");

                string imgPath = Path.Combine(path, FileName);
                if (System.IO.File.Exists(imgPath))
                {
                    FileName = DateTime.Now.ToString("ddMMyyyhhMMssfff") + FileName;
                }
                if (Image4.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(path, FileName), FileMode.Create))
                    {
                        await Image4.CopyToAsync(fileStream);
                    }
                    viewModel.Image4 = "Uploads/Product/" + FileName;
                }
            }
            
            if (Image5 != null)
            {
                var FileName = Image5.FileName;
                var path = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Uploads", "Product");

                string imgPath = Path.Combine(path, FileName);
                if (System.IO.File.Exists(imgPath))
                {
                    FileName = DateTime.Now.ToString("ddMMyyyhhMMssfff") + FileName;
                }
                if (Image5.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(path, FileName), FileMode.Create))
                    {
                        await Image5.CopyToAsync(fileStream);
                    }
                    viewModel.Image5 = "Uploads/Product/" + FileName;
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
            var path = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Uploads", "Product",
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
            ProductVm obj = await _thisService.GetByIdAsync(id);
            ViewBag.CategoryId = await _commonService.FindAllCategory(obj.CategoryId??0);
            return PartialView("~/Areas/BasicInput/Views/Product/Create.cshtml", obj);
        }


        public async Task<IActionResult> Details(int id)
        {
            return PartialView(await _thisService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ProductVm obj = new ProductVm();
            obj.Id = id;
            return PartialView("~/Areas/BasicInput/Views/Product/Delete.cshtml", obj);
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
