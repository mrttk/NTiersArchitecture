using Microsoft.EntityFrameworkCore;
using NTiersArchitecture.Core.Entity;
using NTiersArchitecture.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTiersArchitecture.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Category> GetWithProductByIdAsync(int categoryId)
        {
            return await _appDbContext.Categories.Include(x => x.Products)
                                               .SingleOrDefaultAsync(x => x.Id == categoryId);
        }
    }
}
