using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using API.Core.DbModels;


namespace API.Core.DataContext
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
