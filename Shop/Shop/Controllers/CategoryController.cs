using Microsoft.AspNetCore.Authorization;
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
    [Route("v1/categories")]
    public class CategoryController : ControllerBase
    {

        [HttpGet]
        [Route("get")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext dataContext)
        {
            var categories = await dataContext.Categories.AsNoTracking().ToListAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Category>> GetBydId(long id,
                                                          [FromServices] DataContext dataContext)
        {
            var category = await dataContext.Categories.AsNoTracking().FirstOrDefaultAsync(cat => cat.Id == id);
            if(category != null) return Ok(category);
            return NotFound(new { message = "Categoria não encontrada" });
        }

        [HttpPost]
        [Route("post")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<Category>> Post(
            [FromBody]Category categoryModel,
            [FromServices]DataContext dataContext)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                dataContext.Categories.Add(categoryModel);
                await dataContext.SaveChangesAsync();
                return Ok(categoryModel);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível criar uma categoria."});
            }

        }

        [HttpPut]
        [Route("{id:long}")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<Category>> Put(long id,
                                            [FromBody] Category categoryModel,
                                            [FromServices] DataContext dataContext)
        {
            if (id != categoryModel.Id)
            {
                return NotFound(new { message = "Categoria não encontrada"});
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                dataContext.Entry<Category>(categoryModel).State = EntityState.Modified;
                await dataContext.SaveChangesAsync();
                return Ok(categoryModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Não foi possível atualizar a categoria"});
            }

        }

        [HttpDelete]
        [Route("{id:long}")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult> Delete(long id,
                                              [FromServices] DataContext dataContext)
        {
            try
            {
                var category = await dataContext.Categories.FirstOrDefaultAsync(cat => cat.Id == id);
                if (category == null)
                    return NotFound(new { message = "Categoria não encontrada" });
                return Ok(category);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível deletar a categoria"});
            }

        }
    }
}
