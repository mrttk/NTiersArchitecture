using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTiersArchitecture.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTiersArchitecture.Data.Seeds
{
    public class PersonSeed : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData(
                new Person() { Id = 1, Name = "Emre", Surname = "Tetik" }
            );
        }
    }
}
