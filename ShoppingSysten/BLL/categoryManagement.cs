using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interface;
using ShoppingSysten.Entity_class;
namespace BLL
{
    internal class categoryManagement : ICategoryManagement
    {
        private readonly ICategoryDAO _repo;
        public categoryManagement(ICategoryDAO repo)
        {
            _repo = repo;
        }

        public async Task<bool> IsCategoryExist(int categoryId)
        {
            return await _repo.IsExistAsync(categoryId);
        }
        public async Task<bool> AddCategory(category category)
        => await _repo.AddAsync(category);
        public async Task<category> GetCategoryById(int categoryid)
        => await _repo.GetByIdAsync(categoryid);
        public async Task<category> GetCategoryByName(string categoryName)
        => await _repo.GetByNameAsync(categoryName);
        //public void DisplayAllCategories()
        //{
        //    foreach (var category in categories)
        //    {
        //        category.DisplayCategory();
        //    }
        //}
        public async Task<List<category>> GetAllCategories()
        {
            return await _repo.GetAllAsync();
        }
        public async Task<bool> DeleteCategory(int categoryId)
        => await _repo.DeleteAsync(categoryId);
        public async Task<List<category>> SearchCategory(string category_name)
        {
            return await _repo.SearchAsync(category_name);
        }
        public async Task<bool> UpdateCategory(category newc)
        => await _repo.UpdateAsync(newc);


    }
}
