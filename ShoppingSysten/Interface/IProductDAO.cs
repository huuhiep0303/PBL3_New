using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_class;
using DAO;

namespace Interface
{
    public interface IProductDAO
    {
        Task<bool> AddAsync(product product);
        Task<product> GetByIdAsync(int id);
        Task<List<product>> SearchAsync(string keyword);
        Task<bool> DeleteByNameAsync(string name);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> UpdateAsync(product product);
        Task<List<product>> GetByCategoryIdAsync(int categoryId);
        Task<Dictionary<string, string>> GetAttributesAsync(int productId);
        Task<bool> AddOrUpdateAttributeAsync(int productId, string attrName, string attrValue);
        Task<bool> DeleteAttributeAsync(int productId, string attrName);
    }
}
