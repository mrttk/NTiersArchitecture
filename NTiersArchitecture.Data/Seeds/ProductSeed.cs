using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTiersArchitecture.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTiersArchitecture.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _categoryIds;
        public ProductSeed(int[] categoryIds)
        {
            _categoryIds = categoryIds;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Pen", Price = 15m, Stock = 50, CategoryId = _categoryIds[0] },
                new Product { Id = 2, Name = "Pencil", Price = 3m, Stock = 3000, CategoryId = _categoryIds[0] },
                new Product { Id = 3, Name = "Ball Pen", Price = 1m, Stock = 2000, CategoryId = _categoryIds[0] },
                new Product { Id = 4, Name = "S Notebook", Price = 5.5m, Stock = 1000, CategoryId = _categoryIds[1] },
                new Product { Id = 5, Name = "M Notebook", Price = 6.5m, Stock = 2000, CategoryId = _categoryIds[1] },
                new Product { Id = 6, Name = "L Notebook", Price = 8.0m, Stock = 750, CategoryId = _categoryIds[1] }
            );
        }
    }
}
