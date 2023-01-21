﻿using Domain.Abstracts;
using Domain.Entities.Entity;
using Library.Helpers.UnitOfWork;
using Library.Helpers.Utilities;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class LookupService : ILookupService
    {

        protected readonly IUnitOfWork<TBL_Category, int> _categoryUnitOfWork;

        public LookupService(IUnitOfWork<TBL_Category, int> categoryUnitOfWork)
        {
            _categoryUnitOfWork = categoryUnitOfWork;
        }
        public async Task<List<KeyValueLookup>> FindAllCategory()
        {
            KeyValueLookup FirstItem;
            List<KeyValueLookup> Items = new List<KeyValueLookup>();
            var data = await _categoryUnitOfWork.Repository.FindAsync(q => !q.IsBlock);

            FirstItem = new KeyValueLookup { Value = 0, Text = ResourcesReader.IsArabic ? "-- أختر --" : "-- Select --" };
            Items = data.Select(q => new KeyValueLookup
            {
                Value = q.Id,
                Text = ResourcesReader.IsArabic ? q.NameAr : q.NameEn
            }).ToList();
            Items.Insert(0, FirstItem);

            return Items;
        }




    }
}
