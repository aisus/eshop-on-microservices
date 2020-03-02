using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.Catalog.DataAccess;
using Shop.Catalog.Domain;

namespace Shop.Catalog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private ILogger<ProductsController> Logger { get; }
        private IProductRepository ProductRepository { get; }

        public ProductsController(ILogger<ProductsController> logger, IProductRepository productRepository)
        {
            Logger = logger;
            ProductRepository = productRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await ProductRepository.GetAllAsync();
        }
    }
}