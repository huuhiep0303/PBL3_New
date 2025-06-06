using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;
using Entity_class;


//cứ dùng các list để lưu các danh sách như là danh sách hàng, thông tinh nhân viên, các list đó sẽ được kết nối để lấy thông tin tử csdl sau
namespace BLL
{
    internal class productManagement : IProductManagement
    {
        private readonly IProductDAO _repo;
        private readonly ICategoryManagement categoryService;
        private readonly IInventoryManagement inventoryService;
        public productManagement(IProductDAO repo, ICategoryManagement categoryManagement,IInventoryManagement inventoryService)
        {
            _repo = repo;
            categoryService = categoryManagement;
            this.inventoryService = inventoryService;
        }
        public async Task<bool> AddProduct(product product)
        {
            if (!await categoryService.IsCategoryExist(product.CategoryId))
            {
                Console.WriteLine("Không tồn tại danh mục");
                return false;
            }

            if (await _repo.GetByIdAsync(product.id_product) != null)
            {
                Console.WriteLine("Sản phẩm đã tồn tại");
                return false;
            }

            var added = await _repo.AddAsync(product);
            if (!added) return false;

            await inventoryService.CreateRecord(product.id_product, 0, 30);
            Console.WriteLine("Thêm sản phẩm thành công");
            return true;

        }
        public async Task<product> GetProductById(int id)
        {
            var prod = await _repo.GetByIdAsync(id);
            if (prod != null)
            {
                prod.DynamicAttributes = new Dictionary<string, object>();
                var attrs = await _repo.GetAttributesAsync(id);
                foreach (var kv in attrs)
                    prod.DynamicAttributes[kv.Key] = kv.Value;
            }
            return prod;
        }
        public async Task<List<product>> SearchProducts(string keyword)// tìm kiếm theo tên(cụ thể là keyword}
        {
            return await _repo.SearchAsync(keyword);
        }
        //public void DisplayAllProducts()
        //{
        //    foreach (var product in products)
        //    {
        //        product.DisplayProduct();
        //    }
        //}
      
        public async Task<bool> DeleteProductByName(string name)
        {
            return await _repo.DeleteByNameAsync(name);
        }
        public async Task<List<product>> GetProductsByCategoryId(int categoryId)
        {
            return await _repo.GetByCategoryIdAsync(categoryId);
        }
        public async Task<bool> UpdateProduct(int productId, product updated)
        {
            updated.id_product = productId;
            var ok = _repo.UpdateAsync(updated);

            Console.WriteLine(await ok ? "Sửa thành công" : "Sửa thất bại");

            return await ok;
        }

        public async Task<bool> UpdateDynamicAttribute(int productId, string attrName, string newValue)
        {
            
            var ok = await _repo.AddOrUpdateAttributeAsync(productId,attrName,newValue);

            Console.WriteLine (ok ? "Sửa thành công" : "Sửa thất bại");

            return ok;
        }
        
        public async Task<List<product>> GetProductsByCategoryName(string categoryName)
        {
            var category = await categoryService.GetCategoryByName(categoryName);   
            if (category == null)
            {
                Console.WriteLine($"⚠️ Không tìm thấy danh mục '{categoryName}'");
                return new List<product>();
            }
 
            return await _repo.GetByCategoryIdAsync(category.CategoryId);
        }

        public async Task DisplayProductsByCategoryName(string categoryName)
        {
            var list = await GetProductsByCategoryName(categoryName);
            if (list.Count == 0)
            {
                Console.WriteLine("⚠️ Không có sản phẩm nào trong danh mục này.");
                return;
            }

            Console.WriteLine($"\n📂 Danh mục: {categoryName}");
            foreach (var product in list)
            {
                product.DisplayProduct();
            }
        }
        public async Task<List<product>> GetAllProductsAsync()
        {
            return await _repo.GetAllProductsAsync();
        }
    }

}