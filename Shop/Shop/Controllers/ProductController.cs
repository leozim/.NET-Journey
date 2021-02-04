using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)] //a duração é em minutos
        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult<List<Product>>> getProducts([FromServices] DataContext dataContext)
        {
            var products = await dataContext.Products
                .Include(prod => prod.Category)
                .AsNoTracking()
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet]
        [Route("/categories/{categoryId:long}")]
        public async Task<ActionResult<Product>> getByCategory(long categoryId,
                                                              [FromServices]DataContext dataContext)
        {
            var product = await dataContext.Products
                .Include(prod => prod.Category)
                .AsNoTracking()
                .Where(prod => prod.CategoryId == categoryId)
                .ToListAsync();

            return Ok(product);
        }

        [HttpPost]
        [Route("/post")]
        public async Task<ActionResult<Product>> post([FromBody] Product productModel,
                                                     [FromServices] DataContext dataContext)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            dataContext.Products.Add(productModel);
            await dataContext.SaveChangesAsync();
            return Ok(productModel);
        }

    }
}
