using API.Core.DataContext;
using API.Core.DbModels;
using API.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        public ProductsController(IGenericRepository<Product> productRepository,
           IGenericRepository<ProductBrand> productBrandRepository,
           IGenericRepository<ProductType> productTypeRepository)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productRepository.GetByIdAsycn(id);
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProduct()
        {
            var data = await _productRepository.ListAllAsync();
            return Ok(data);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepository.ListAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepository.ListAllAsync());
        }

    }
}