using NTiersArchitecture.Core.Repositories;
using NTiersArchitecture.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NTiersArchitecture.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }

        Task CommitAsync();
        void Commit();
    }
}
