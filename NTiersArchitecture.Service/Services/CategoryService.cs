using NTiersArchitecture.Core.Entity;
using NTiersArchitecture.Core.Repositories;
using NTiersArchitecture.Core.Services;
using NTiersArchitecture.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NTiersArchitecture.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Category> GetWithProductByIdAsync(int categoryId)
        {
            return await _unitOfWork.Categories.GetWithProductByIdAsync(categoryId);
        }
    }
}
