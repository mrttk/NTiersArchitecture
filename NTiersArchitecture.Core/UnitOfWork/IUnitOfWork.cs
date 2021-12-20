using NTiersArchitecture.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NTiersArchitecture.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductService Products { get; }
        ICategoryService Categories { get; }

        Task CommitAsync();
        void Commit();
    }
}
