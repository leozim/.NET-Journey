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
    [Route("v1/users")]
    public class UserController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<List<User>>> Get([FromServices]DataContext dataContext)
        {
            var users = await dataContext
                .Users
                .AsNoTracking()
                .ToListAsync();

            return users;
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<User>> Post([FromServices]DataContext dataContext,
                                                   [FromBody] User userModel)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                dataContext.Add(userModel);
                await dataContext.SaveChangesAsync();
                return Ok(userModel);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário"});
            }

        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromServices]DataContext dataContext,
                                                              [FromBody]User userModel)
        {
            var user = await dataContext.Users
                .AsNoTracking()
                .Where(user => user.Username == userModel.Username && user.Password == userModel.Password)
                .FirstOrDefaultAsync();

            if(user == null)
                return NotFound(new { message = "usuário õu senha inválido"});

            var token = TokenService.TokenService.GenerateToken(user);
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpPut]
        [Route("{id:long}")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<User>> Put([FromServices]DataContext dataContext,
                                                  [FromBody] User userModel,
                                                  long id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(id != userModel.Id)
                return NotFound(new { message = "Usuario não encontrado"});

            try
            {
                dataContext.Entry(userModel).State = EntityState.Modified;
                await dataContext.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar usuário"});
            }
        }


        [HttpGet]
        [Route("anonimo")]
        [AllowAnonymous]
        public string Anonimo() => new string("Anonimo");

        [HttpGet]
        [Route("autenticado")]
        [Authorize]
        public string Autenticado() => new string("Autenticado");

        [HttpGet]
        [Route("funcionario")]
        [Authorize(Roles = "employee")]
        public string Funcionario() => new string("Funcionario");

        [HttpGet]
        [Route("gerente")]
        [Authorize(Roles = "gerente")]
        public string Gerente() => "Gerente";

    }
}
