using EcoEnergyAPI.Dto.Tarefa;
using EcoEnergyAPI.Models;
using EcoEnergyAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoEnergyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpGet("ListarTarefas")]
        public async Task<ActionResult<ResponseModel<List<TarefaModel>>>> ListarTarefas()
        {
            var tarefas = await _tarefaRepository.ListarTarefas();
            return Ok(tarefas);

        }

        [HttpGet("BuscarTarefa/{idTarefa}")]
        public async Task<ActionResult<ResponseModel<TarefaModel>>> BuscarTarefa(int idTarefa)
        {
            var tarefa = await _tarefaRepository.BuscarTarefa(idTarefa);
            return Ok(tarefa);
        }

        [HttpGet("BuscarTarefaPorUsuario/{idUsuario}")]
        public async Task<ActionResult<ResponseModel<List<TarefaModel>>>> BuscarTarefaPorUsuario(int idUsuario)
        {
            var tarefas = await _tarefaRepository.BuscarTarefaPorUsuario(idUsuario);
            return Ok(tarefas);
        }

        [HttpPost("CadastrarTarefa")]
        public async Task<ActionResult<ResponseModel<List<TarefaModel>>>> CadastrarTarefa(CriarTarefaDto criarTarefaDto)
        {
            var tarefas = await _tarefaRepository.CadastrarTarefa(criarTarefaDto);
            return Ok(tarefas);
        }

        [HttpPut("EditarTarefa")]
        public async Task<ActionResult<ResponseModel<List<TarefaModel>>>> EditarTarefa(EditarTarefaDto editarTarefaDto)
        {
            var tarefas = await _tarefaRepository.EditarTarefa(editarTarefaDto);
            return Ok(tarefas);
        }

        [HttpDelete("DeletarTarefa/{idTarefa}")]
        public async Task<ActionResult<ResponseModel<List<TarefaModel>>>> DeletarTarefa(int idTarefa)
        {
            var tarefas = await _tarefaRepository.DeletarTarefa(idTarefa);
            return Ok(tarefas);
        }
    }
}
