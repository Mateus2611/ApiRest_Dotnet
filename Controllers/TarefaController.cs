using Microsoft.AspNetCore.Mvc;
using TarefasBackEnd.Repositories;
using TarefasBackEnd.Models;

namespace TarefasBackEnd.Controllers
{
    [ApiController]
    [Route("tarefa")]
    public class TarefaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Read([FromServices] ITarefaRepository repository) 
        {
            var tarefas = repository.Read();
            return Ok(tarefas);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Tarefa model, [FromServices]ITarefaRepository repository)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            repository.Create(model);

            return Ok();
        }
    } 
}