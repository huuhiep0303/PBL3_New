using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_class;

namespace Interface
{
    public interface IProductDAO
    {
        Task<bool> AddAsync(product product);
        Task<product> GetByIdAsync(int id);
        Task<List<product>> SearchAsync(string keyword);
        Task<bool> DeleteByNameAsync(string name);
        Task<bool> UpdateAsync(product product);
        Task<List<product>> GetByCategoryIdAsync(int categoryId);
    }
}
