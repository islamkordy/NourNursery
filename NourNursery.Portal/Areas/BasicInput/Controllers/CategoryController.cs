using Domain.Abstracts.BasicInput;
using NourNursery.Portal.Controllers;
using NourNursery.Portal.CustomAttributes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModel.BasicInput;
using Portal.Resource.GlobalRes;
using System.Threading.Tasks;

namespace NourNursery.Portal.Areas.BasicInput.Controllers
{
    [Area("BasicInput")]
    public class CategoryController : BaseController
    {
        #region Services
        private readonly ICategoryService _thisService;
        private IWebHostEnvironment _hostingEnvironment;
        #endregion

        #region Constructor
        public CategoryController(ICategoryService thisService, ICommonService commonService, IWebHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
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
            CategoryVm Obj = new CategoryVm();
            //ViewBag.ConditionerTypeId =await _commonService.FindAllConditionerTypes();
            //ViewBag.RoomTypeId = await _commonService.FindAllRoomTypes();

            return PartialView("~/Areas/BasicInput/Views/Category/Create.cshtml", Obj);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryVm viewModel)
        {
            viewModel.UserId = UserData.UserId;
           
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
        public async Task<IActionResult> Edit(int id)
        {
            CategoryVm obj = await _thisService.GetByIdAsync(id);

            return PartialView("~/Areas/BasicInput/Views/Category/Create.cshtml", obj);
        }


        public async Task<IActionResult> Details(int id)
        {
            return PartialView(await _thisService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            CategoryVm obj = new CategoryVm();
            obj.Id = id;
            return PartialView("~/Areas/BasicInput/Views/Category/Delete.cshtml", obj);
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
