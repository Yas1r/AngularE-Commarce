using API.Core.DataContext;
using API.Core.DbModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;

        }
        [HttpGet]
        public ActionResult<List<Product>> GetProduct()
        {
            var data = _context.Products.ToList();
            return data;
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            
            return _context.Products.Find(id);
        }

    }
}