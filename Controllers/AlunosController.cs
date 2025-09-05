using System.Collections.Generic;
using System.Threading.Tasks;
using AlunosApi.Models;
using AlunosApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlunosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Produces("application/json")]
    public class AlunosController : ControllerBase
    {
        private IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos()
        {
            try
            {
                var alunos = await _alunoService.GetAlunos();
                return Ok(alunos);
            }
            catch
            {
                //return BadRequest("Request invalido");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter alunos");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> 
            GetAlunos([FromQuery] string nome)
        {
            try
            {
                var alunos = await _alunoService.GetAlunosbyNome(nome);
                if (alunos == null)
                    return NotFound($"Não Existem alunos com o criterio {nome}");

                return Ok(alunos);
            }
            catch
            {
                return BadRequest("Request invalido");
            }
        }
    }
}
