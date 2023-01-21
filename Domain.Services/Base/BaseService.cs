using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Afaqy.Erp.DataLayer.Base;
using AutoMapper;
using Domain.Entities.Context;
using Library.Helpers.AdoModeule;
using Library.Helpers.APIUtilities;
using Library.Helpers.UnitOfWork;
using Library.Helpers.Utilities;
using Microsoft.AspNetCore.Http;
using Models.ViewModel.Administration;

namespace Domain.Services.Base
{
    public class BaseService<T, TDto, TGetDto, TKey, TKeyDto>
        : IBaseService<T, TDto, TGetDto, TKey, TKeyDto>
        where T : GeneralTable<TKey>
        where TDto : IEntityDto<TKeyDto>
        where TGetDto : IEntityDto<TKeyDto>
    {
        protected readonly IUnitOfWork<T,TKey> _unitOfWork;
        protected IRepositoryActionResult _repositoryActionResult { get; set; }
        protected readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IDbHandler _db;
        public UserVm model;


        internal BaseService(IUnitOfWork<T, TKey> UnitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper = null, IDbHandler db = null)
        {
            _unitOfWork = UnitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _db = db;
            model = new UserVm();
        }

        internal BaseService(IRepositoryActionResult repositoryActionResult, IUnitOfWork<T, TKey> UnitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper = null, IDbHandler db = null)
        {
            _unitOfWork = UnitOfWork;
            _repositoryActionResult = repositoryActionResult;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _db = db;
            model = new UserVm();

        }
        public virtual async Task<IEnumerable<TGetDto>> GetAllAsync(bool disableTracking = false)
        {
            var query = await _unitOfWork.Repository.GetAllAsync(disableTracking: disableTracking);
            var data = _mapper.Map<IEnumerable<T>, IEnumerable<TGetDto>>(query);
            return data;
        }

        public virtual async Task<bool> AddAsync(TDto model)
        {

            T entity = _mapper.Map<TDto, T>(model);
            SetEntityCreatedBaseProperties(entity);
            _unitOfWork.Repository.Add(entity);
            bool isSave = await _unitOfWork.SaveChanges() > 0;
            return isSave;

        }
        public virtual async Task<bool> AddListAsync(List<TDto> model)
        {
            List<T> entities = _mapper.Map<List<TDto>, List<T>>(model);
            _unitOfWork.Repository.AddRange(entities);
            bool isSave = await _unitOfWork.SaveChanges() > 0;
            return isSave;
        }

        public virtual async Task<bool> UpdateAsync(TDto model)
        {
            T entityToUpdate = await _unitOfWork.Repository.GetAsync(model.Id);
            var newEntity = _mapper.Map(model, entityToUpdate);
            SetEntityModifiedBaseProperties(newEntity);
            _unitOfWork.Repository.Update(entityToUpdate, newEntity);
            bool isSave = await _unitOfWork.SaveChanges() > 0;
            return isSave;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {

            var entityToDelete = await _unitOfWork.Repository.GetAsync(id);
            _unitOfWork.Repository.Remove(entityToDelete);
            bool isSave = await _unitOfWork.SaveChanges() > 0;
            return isSave;

        }
        public virtual async Task<bool> DeleteSoftAsync(int id)
        {

            var entityToDelete = await _unitOfWork.Repository.GetAsync(id);
            SetEntityModifiedBaseProperties(entityToDelete);
            _unitOfWork.Repository.RemoveLogical(entityToDelete);
            bool isSave = await _unitOfWork.SaveChanges() > 0;
            return isSave;
        }

        public virtual async Task<TGetDto> GetByIdAsync(int id)
        {

            T query = await _unitOfWork.Repository.GetAsync(id);
            var data = _mapper.Map<T, TGetDto>(query);
            return data;

        }
       

        protected void SetEntityCreatedBaseProperties(GeneralTable<TKey> entity)
        {
            entity.CreateUserId = UserData.UserId;
            entity.CreateDate = DateTime.Now;

        }

        protected void SetEntityModifiedBaseProperties(GeneralTable<TKey> entity)
        {
            entity.ModifyUserId = UserData.UserId;
            entity.ModifyDate = DateTime.Now;

        }


        protected virtual new UserVm UserData
        {
            get
            {
                model.UserId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.First(t => t.Type == "UserId").Value.ToString());
                model.NameAr = _httpContextAccessor.HttpContext.User.Claims.First(t => t.Type == "NameAr").Value;
                model.NameEn = _httpContextAccessor.HttpContext.User.Claims.First(t => t.Type == "NameEn").Value;
                //model.Company = int.Parse(User.Claims.First(t => t.Type == "Company").Value.ToString());
                //model.Branch = int.Parse(User.Claims.First(t => t.Type == "Branch").Value.ToString());
                model.Name = ResourcesReader.IsArabic ? _httpContextAccessor.HttpContext.User.Claims.First(t => t.Type == "NameAr").Value : _httpContextAccessor.HttpContext.User.Claims.First(t => t.Type == "NameEn").Value;


                return model;
            }
        }

    }
}
