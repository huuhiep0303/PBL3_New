using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;
using Entity_class;

namespace BLL
{
    class StoreManagement : IStoreManagement
    {
        private readonly IEmployeeDAO employeeDAO;
        private readonly IProductDAO productDAO;
        private readonly IProductManagement pmProduct;

        public StoreManagement(IEmployeeDAO employeeDAO,
            IProductDAO productDAO,
            IProductManagement pmProduct)
        {
            this.employeeDAO = employeeDAO;
            this.productDAO = productDAO;
            this.pmProduct = pmProduct;
        }

        // ✅ Lấy toàn bộ sản phẩm
        public async Task<List<product>> GetAllProduct()
        {
            return await productDAO.GetAllProductsAsync();
        }

        // ✅ Lấy sản phẩm theo ID
        public async Task<product> GetProductById(int id)
        {
            return await productDAO.GetByIdAsync(id);
        }

        // ✅ Xoá sản phẩm theo ID
        public async Task DeleteProductById(int id)
        {
            await productDAO.DeleteByIdAsync(id);
        }

        // ✅ Thêm sản phẩm mới
        public async Task InserProduct(product product)
        {
            await productDAO.AddAsync(product);
        }

        // ✅ Cập nhật sản phẩm (giả sử cập nhật toàn bộ thông tin)
        public async Task UpdateInforProduct(int productId)
        {
            var existing = await productDAO.GetByIdAsync(productId);
            if (existing != null)
            {
                // Có thể thay bằng form nhập hoặc sửa trực tiếp ở đây
                Console.WriteLine("Tên sản phẩm hiện tại: " + existing.name_product);
                Console.Write("Nhập tên mới: ");
                var newName = Console.ReadLine();

                existing.name_product = newName;
                // Có thể cập nhật thêm các thuộc tính khác tại đây

                await productDAO.UpdateAsync(existing);
            }
            else
            {
                Console.WriteLine("❌ Không tìm thấy sản phẩm với ID = " + productId);
            }
        }
    }

}
