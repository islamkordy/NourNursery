using Domain.Abstracts.BasicInput;
using Domain.Entities.Entity;
using Library.Helpers.UnitOfWork;
using Library.Helpers.Utilities;
using Microsoft.EntityFrameworkCore;
using Models.ViewModel.BasicInput;
using System.Threading.Tasks;

namespace Domain.Services.BasicInput
{

    public class FrontService : IFrontService
    {
        IUnitOfWork<TBL_About, int> _aboutUnitOfWork;
        IUnitOfWork<TBL_ContactUs, int> _contactUsUnitOfWork;
        IUnitOfWork<TBL_Faqs, int> _faqsUnitOfWork;
        IUnitOfWork<TBL_Sliders, int> _sliderUnitOfWork;
        IUnitOfWork<TBL_Product, int> _productUnitOfWork;
        public FrontService(IUnitOfWork<TBL_About, int> aboutUnitOfWork,
        IUnitOfWork<TBL_ContactUs, int> contactUsUnitOfWork
            , IUnitOfWork<TBL_Faqs, int> faqsUnitOfWork, IUnitOfWork<TBL_Sliders, int> sliderUnitOfWork,
        IUnitOfWork<TBL_Product, int> productUnitOfWork
              )
        {
            _aboutUnitOfWork = aboutUnitOfWork;
            _contactUsUnitOfWork = contactUsUnitOfWork;
            _faqsUnitOfWork = faqsUnitOfWork;
            _sliderUnitOfWork = sliderUnitOfWork;
            _productUnitOfWork = productUnitOfWork;
        }

        public async Task<FrontVm> GetAllFrontDataFaqs()
        {

            var data = await _aboutUnitOfWork.Repository.FirstOrDefaultAsync(q => q.Id > 0);
            FrontVm model = new FrontVm();

            model.Title = ResourcesReader.IsArabic ? data.TitleAr?.Trim() : data.TitleEn?.Trim();
            model.About = ResourcesReader.IsArabic ? data.AboutAr?.Trim() : data.AboutEn?.Trim();
            model.Description = ResourcesReader.IsArabic ? data.DescAr?.Trim() : data.DescEn?.Trim();
            model.Address = ResourcesReader.IsArabic ? data.AddressAr?.Trim() : data.AddressEn?.Trim();
            model.Email = data.Email;
            model.Phone = data.Phone;
            model.Mobile = data.Mobile;
            model.FaceBook = data.FaceBook;
            model.Twitter = data.Twitter;
            model.Instagram = data.Instagram;
            model.Linkedin = data.Linkedin;
            model.Youtube = data.Youtube;
            model.Logo = data.Logo;
            model.Logo2 = data.Logo2;
            model.Faqs = await _faqsUnitOfWork.Repository.FindAsync(q => !q.IsBlock,
                include: source => source.Include(a => a.FaqsDetails));
            return model;

        }


        public async Task<FrontVm> GetAllFrontProductDetails(int Id)
        {

            var data = await _aboutUnitOfWork.Repository.FirstOrDefaultAsync(q => q.Id > 0);
            FrontVm model = new FrontVm();

            model.Title = ResourcesReader.IsArabic ? data.TitleAr?.Trim() : data.TitleEn?.Trim();
            //model.About = ResourcesReader.IsArabic ? data.AboutAr?.Trim() : data.AboutEn?.Trim();
            //model.Description = ResourcesReader.IsArabic ? data.DescAr?.Trim() : data.DescEn?.Trim();

            //model.Vision = ResourcesReader.IsArabic ? data.VisionAr?.Trim() : data.VisionEn?.Trim();
            //model.Value = ResourcesReader.IsArabic ? data.ValueAr?.Trim() : data.ValueEn?.Trim();
            //model.Mission = ResourcesReader.IsArabic ? data.MissionAr?.Trim() : data.MissionEn?.Trim();
            //model.Contact = ResourcesReader.IsArabic ? data.ContactAr?.Trim() : data.ContactEn?.Trim();
            //model.ProjectTitle = ResourcesReader.IsArabic ? data.ProjectTitleAr?.Trim() : data.ProjectTitleEn?.Trim();
            //model.Description = ResourcesReader.IsArabic ? data.DescAr?.Trim() : data.DescEn?.Trim();

            //model.Address = ResourcesReader.IsArabic ? data.AddressAr?.Trim() : data.AddressEn?.Trim();
            //model.Email = data.Email;
            //model.Phone = data.Phone;
            //model.Mobile = data.Mobile;
            //model.FaceBook = data.FaceBook;
            //model.Twitter = data.Twitter;
            //model.Instagram = data.Instagram;
            //model.Linkedin = data.Linkedin;
            //model.Youtube = data.Youtube;
            model.Logo = data.Logo;
            //model.Logo2 = data.Logo2;
            //model.VisionImage = data.VisionImage;

            model.Sliders1 = await _sliderUnitOfWork.Repository.FindAsync(q => q.Type == 3);
            model.ProductDetails = await _productUnitOfWork.Repository.FirstOrDefaultAsync(q => !q.IsBlock && q.Id == Id);
            //var res = await _productUnitOfWork.Repository.FindPagedAsync(take: 4,include:
            //    t=>t.Include(c=>c.Category));
            //model.Products = res.Item2;


            return model;

        }
        public async Task<FrontVm> GetAllFrontProductData()
        {

            var data = await _aboutUnitOfWork.Repository.FirstOrDefaultAsync(q => q.Id > 0);
            FrontVm model = new FrontVm();

            model.Title = ResourcesReader.IsArabic ? data.TitleAr?.Trim() : data.TitleEn?.Trim();
            model.About = ResourcesReader.IsArabic ? data.AboutAr?.Trim() : data.AboutEn?.Trim();
            model.Description = ResourcesReader.IsArabic ? data.DescAr?.Trim() : data.DescEn?.Trim();

            model.Vision = ResourcesReader.IsArabic ? data.VisionAr?.Trim() : data.VisionEn?.Trim();
            model.Value = ResourcesReader.IsArabic ? data.ValueAr?.Trim() : data.ValueEn?.Trim();
            model.Mission = ResourcesReader.IsArabic ? data.MissionAr?.Trim() : data.MissionEn?.Trim();
            model.Contact = ResourcesReader.IsArabic ? data.ContactAr?.Trim() : data.ContactEn?.Trim();
            model.ProjectTitle = ResourcesReader.IsArabic ? data.ProjectTitleAr?.Trim() : data.ProjectTitleEn?.Trim();
            //model.Description = ResourcesReader.IsArabic ? data.DescAr?.Trim() : data.DescEn?.Trim();

            model.Address = ResourcesReader.IsArabic ? data.AddressAr?.Trim() : data.AddressEn?.Trim();
            model.Email = data.Email;
            model.Phone = data.Phone;
            model.Mobile = data.Mobile;
            model.FaceBook = data.FaceBook;
            model.Twitter = data.Twitter;
            model.Instagram = data.Instagram;
            model.Linkedin = data.Linkedin;
            model.Youtube = data.Youtube;
            model.Logo = data.Logo;
            model.Logo2 = data.Logo2;
            model.VisionImage = data.VisionImage;

            model.Sliders1 = await _sliderUnitOfWork.Repository.FindAsync(q => q.Type == 3);
            model.Products = await _productUnitOfWork.Repository.FindAsync(q => !q.IsBlock);
            //var res = await _productUnitOfWork.Repository.FindPagedAsync(take: 4,include:
            //    t=>t.Include(c=>c.Category));
            //model.Products = res.Item2;


            return model;

        }
        public async Task<FrontVm> GetAllFrontData()
        {

            var data = await _aboutUnitOfWork.Repository.FirstOrDefaultAsync(q => q.Id > 0);
            FrontVm model = new FrontVm();  

            model.Title = ResourcesReader.IsArabic ? data.TitleAr?.Trim() : data.TitleEn?.Trim();
            model.About = ResourcesReader.IsArabic ? data.AboutAr?.Trim() : data.AboutEn?.Trim();
            model.Description = ResourcesReader.IsArabic ? data.DescAr?.Trim() : data.DescEn?.Trim();

            model.Vision = ResourcesReader.IsArabic ? data.VisionAr?.Trim() : data.VisionEn?.Trim();
            model.Value = ResourcesReader.IsArabic ? data.ValueAr?.Trim() : data.ValueEn?.Trim();
            model.Mission = ResourcesReader.IsArabic ? data.MissionAr?.Trim() : data.MissionEn?.Trim();
            model.Contact = ResourcesReader.IsArabic ? data.ContactAr?.Trim() : data.ContactEn?.Trim();
            model.ProjectTitle = ResourcesReader.IsArabic ? data.ProjectTitleAr?.Trim() : data.ProjectTitleEn?.Trim();
            //model.Description = ResourcesReader.IsArabic ? data.DescAr?.Trim() : data.DescEn?.Trim();

            model.Address = ResourcesReader.IsArabic ? data.AddressAr?.Trim() : data.AddressEn?.Trim();
            model.Email = data.Email;
            model.Phone = data.Phone;
            model.Mobile = data.Mobile;
            model.FaceBook = data.FaceBook;
            model.Twitter = data.Twitter;
            model.Instagram = data.Instagram;
            model.Linkedin = data.Linkedin;
            model.Youtube = data.Youtube;
            model.Logo = data.Logo;
            model.Logo2 = data.Logo2;
            model.VisionImage = data.VisionImage;

            model.Sliders1 = await _sliderUnitOfWork.Repository.FindAsync(q => q.Type == 1);
            model.Sliders2 = await _sliderUnitOfWork.Repository.FindAsync(q => q.Type == 2);
            model.MainProducts = await _productUnitOfWork.Repository.FindAsync(q => q.IsMainPage == true);
            var res = await _productUnitOfWork.Repository.FindPagedAsync(take: 4, include:
                t => t.Include(c => c.Category));
            model.Products = res.Item2;


            return model;

        }

        public virtual async Task<bool> AddAsync(ContactUsVm model)
        {
            TBL_ContactUs obj = new TBL_ContactUs();
            obj.Phone = model.ContactPhone;
            obj.Name = model.Name;
            obj.City = model.City;
            obj.PostalCode = model.PostalCode;
            obj.HoteName = model.HoteName;
            obj.Email = model.ContactEmail;
            obj.Description = model.ContactDescription;
            obj.CreateDate = model.CreateDate;
            obj.CreateUserId = 1;
            _contactUsUnitOfWork.Repository.Add(obj);
            bool isSave = await _contactUsUnitOfWork.SaveChanges() > 0;
            return isSave;
        }
    }
}


