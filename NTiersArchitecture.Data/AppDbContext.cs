using Microsoft.EntityFrameworkCore;
using NTiersArchitecture.Core.Entity;
using NTiersArchitecture.Data.Configurations;
using NTiersArchitecture.Data.Seeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTiersArchitecture.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));
        }
    }
}
