using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueRepository estoqueRepository;
        public EstoqueController(IEstoqueRepository estqRepository)
        {
            estoqueRepository = estqRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ESTOQUE>> GetEstoque()
        {
            return await estoqueRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ESTOQUE>> GetEstoqueEspecifico(int id)
        {
            return await estoqueRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<ESTOQUE>> PostEstoque([FromBody] ESTOQUE estoque)
        {
            var newEstoque = await estoqueRepository.Create(estoque);
            return CreatedAtAction(nameof(GetEstoqueEspecifico), new { id = newEstoque.Id }, newEstoque);
        }

        // INSERÇÃO DE UMA LIST 
        [Route("listaEstoquePost")]
        [HttpPost]
        public async Task<IActionResult> postListEstoque([FromBody] List<ESTOQUE> estoque)
        {
            if (estoque == null)
                return BadRequest();

            foreach (var item in estoque)
            {
                await estoqueRepository.Create(item);
            }

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var estoqueDelete = await estoqueRepository.Get(id);

            if (estoqueDelete == null)
                return NotFound();

            await estoqueRepository.Delete(estoqueDelete.Id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> PutEstoque(int id, [FromBody] ESTOQUE estoque)
        {
            if (id != estoque.Id)
                return BadRequest();

            await estoqueRepository.Update(estoque);

            return NoContent();
        }

        // UPDATE DE UMA LIST 
        [Route("listaEstoquePut")]
        [HttpPut]
        public async Task<IActionResult> PutListEstoque([FromBody] List<ESTOQUE> estoque)
        {
            if (estoque == null)
                return BadRequest();

            foreach (var item in estoque)
            {
                await estoqueRepository.Update(item);
            }

            return NoContent();
        }
    }
}
