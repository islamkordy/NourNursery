
using AutoMapper;
using Library.Helpers.AdoModeule;
using Library.Helpers.APIUtilities;
using Library.Helpers.UnitOfWork;
using Library.Helpers.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Models.ViewModel.Administration;
using System;
using System.Linq;

namespace Domain.Services.Base
{
    //public class BaseService2<T,TKey> where T : class
    //{       
    //    protected readonly IUnitOfWork<T,TKey> _unitOfWork;
    //    protected  IRepositoryActionResult _repositoryActionResult { get; set; }
    //    protected readonly IMapper _mapper;
    //    private readonly IHttpContextAccessor _httpContextAccessor;
    //    protected readonly IDbHandler _db;
    //    public UserVm model;


    //    internal BaseService2( IUnitOfWork<T, TKey> UnitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper = null, IDbHandler db = null)
    //    {
    //        _unitOfWork = UnitOfWork;
    //        _mapper = mapper;
    //        _httpContextAccessor = httpContextAccessor;
    //        _db = db;
    //        model = new UserVm();
    //    }

    //    internal BaseService2(IRepositoryActionResult repositoryActionResult,IUnitOfWork<T, TKey> UnitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper = null, IDbHandler db = null)
    //    {
    //        _unitOfWork = UnitOfWork;
    //        _repositoryActionResult = repositoryActionResult;
    //        _mapper = mapper;
    //        _httpContextAccessor = httpContextAccessor;
    //        _db = db;
    //    }

      
    //    public Language GetUserLangId()
    //    {
    //        StringValues langs;
    //        _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("lang", out langs);
    //        var lang = langs.FirstOrDefault();
    //        return string.IsNullOrEmpty(lang) ? Language.English : lang == "en" ? Language.English : Language.Arabic;
    //    }

    //    protected virtual new UserVm UserData
    //    {
    //        get
    //        {
    //            model.UserId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.First(t => t.Type == "UserId").Value.ToString());
    //            model.NameAr = _httpContextAccessor.HttpContext.User.Claims.First(t => t.Type == "NameAr").Value;
    //            model.NameEn = _httpContextAccessor.HttpContext.User.Claims.First(t => t.Type == "NameEn").Value;
    //            //model.Company = int.Parse(User.Claims.First(t => t.Type == "Company").Value.ToString());
    //            //model.Branch = int.Parse(User.Claims.First(t => t.Type == "Branch").Value.ToString());
    //            model.Name = ResourcesReader.IsArabic ? _httpContextAccessor.HttpContext.User.Claims.First(t => t.Type == "NameAr").Value : _httpContextAccessor.HttpContext.User.Claims.First(t => t.Type == "NameEn").Value;


    //            return model;
    //        }
    //    }


    //    //protected void SetEntityCreatedBaseProperties(BaseEntity<T> entity)
    //    //{
    //    //    entity.CreateUserId = UserData.UserId;
    //    //    entity.CreateDate = DateTime.Now;

    //    //}

    //    //protected void SetEntityModifiedBaseProperties(BaseEntity<T> entity)
    //    //{
    //    //    entity.ModifyUserId = UserData.UserId;
    //    //    entity.ModifyDate = DateTime.Now;
         
    //    //}
    //}

}
