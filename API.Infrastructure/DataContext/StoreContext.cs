using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using API.Core.DbModels;
using System.Threading.Tasks;

namespace API.Core.DataContext
{
    public class StoreContext : DbContext
    {
        internal readonly Task<IReadOnlyList<ProductType>> ProductType;

        public StoreContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<ProductBrand> ProductBrands { get; set; }
    }
}
