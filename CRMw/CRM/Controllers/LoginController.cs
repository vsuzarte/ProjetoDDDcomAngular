using Domain.Dtos;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CRM.Controllers
{
    [Route("api/crm/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<object> Login([FromBody] LoginDTO login)
        {
            if (!ModelState.IsValid || login == null)
                return BadRequest();

            try
            {
                var result = await _service.CarregarPorLoginSenha(login);

                if (result != null)
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
