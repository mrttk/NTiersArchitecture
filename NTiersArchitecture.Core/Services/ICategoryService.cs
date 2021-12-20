using NTiersArchitecture.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NTiersArchitecture.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithProductByIdAsync(int categoryId);
    }
}
