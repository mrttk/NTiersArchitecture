using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTiersArchitecture.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTiersArchitecture.Data.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly int[] _ids;
        public CategorySeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = _ids[0], Name = "Pens" },
                new Category { Id = _ids[1], Name = "Notebooks" }
                );
        }
    }
}
