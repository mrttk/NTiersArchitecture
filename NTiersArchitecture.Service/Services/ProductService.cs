using Microsoft.EntityFrameworkCore;
using NTiersArchitecture.Core.Entity;
using NTiersArchitecture.Core.Repositories;
using NTiersArchitecture.Core.Services;
using NTiersArchitecture.Core.UnitOfWork;
using NTiersArchitecture.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NTiersArchitecture.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);
        }
    }
}
