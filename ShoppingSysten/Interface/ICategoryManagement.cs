﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingSysten.Entity_class;


namespace Interface
{
    internal interface ICategoryManagement
    {
        Task<bool> AddCategory(category category);
        Task<category> GetCategoryById(int id);
        Task<category> GetCategoryByName(string name);
        Task<List<category>> SearchCategory(string keyword);
        Task<List<category>> GetAllCategories();
        Task<bool> DeleteCategory(int id);
        Task<bool> UpdateCategory(category nn);
        Task<bool> IsCategoryExist(int categoryId);
    }
}
