using API.Core.DataContext;
using API.Core.DbModels;
using API.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure.Implements
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(p=>p.Id == id);
        }
        public async Task<IReadOnlyList<Product>> GetProductAsync()
        {
            return await _context.Products
                .Include(p=>p.ProductBrand)
                .Include(p=>p.ProductType)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsycn()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsycn()
        {
            return await _context.ProductBrands.ToListAsync();
        }
    }
}
