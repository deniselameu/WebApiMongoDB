using Microsoft.AspNetCore.Mvc;
using WebApiMongoDB.Models;
using WebApiMongoDB.Services;

namespace c.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly CadastroServices _cadastroServices;

        public CadastroController(CadastroServices cadastroServices) =>

            _cadastroServices = cadastroServices;

        [HttpGet]
        public async Task<List<Cadastro>> Get() =>
         await _cadastroServices.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Cadastro>> Get(string id)
        {
            var cadastro = await _cadastroServices.GetAsync(id);

            if (cadastro is null)
            {
                return NotFound();
            }

            return cadastro;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cadastro novocadastro)
        {
            await _cadastroServices.CreateAsync(novocadastro);

            return CreatedAtAction(nameof(Get), new { id = novocadastro.Id }, novocadastro);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Cadastro updatedcadastro)
        {
            var cadastro = await _cadastroServices.GetAsync(id);

            if (cadastro is null)
            {
                return NotFound();
            }

            updatedcadastro.Id = cadastro.Id;

            await _cadastroServices.UpdateAsync(id, updatedcadastro);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var cadastro = await _cadastroServices.GetAsync(id);

            if (cadastro is null)
            {
                return NotFound();
            }

            await _cadastroServices.RemoveAsync(id);

            return NoContent();
        }
    }
}
