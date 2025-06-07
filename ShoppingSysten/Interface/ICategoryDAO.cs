using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_class;

namespace Interface
{
    internal interface ICategoryDAO
    {
        Task<bool> AddAsync(category category);
        Task<category> GetByIdAsync(int id);
        Task<List<category>> GetAllAsync();
        Task<bool> UpdateAsync(category category);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsExistAsync(int id);
        Task<category> GetByNameAsync(string name);
        Task<List<category>> SearchAsync(string keyword);
    }
}
