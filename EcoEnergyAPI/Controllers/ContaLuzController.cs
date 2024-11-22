using EcoEnergyAPI.Dto.ContaLuz;
using EcoEnergyAPI.Models;
using EcoEnergyAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoEnergyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaLuzController : ControllerBase
    {
        private readonly IContaLuzRepository _contaLuzRepository;

        public ContaLuzController(IContaLuzRepository contaLuzRepository)
        {
            _contaLuzRepository = contaLuzRepository;
        }

        [HttpGet("ListarContasLuz")]
        public async Task<ActionResult<ResponseModel<List<ContaLuzModel>>>> ListarContasLuz()
        {
            var contasLuz = await _contaLuzRepository.ListarContasLuz();
            return Ok(contasLuz);
        }

        [HttpGet("BuscarContaLuz/{idContaLuz}")]
        public async Task<ActionResult<ResponseModel<ContaLuzModel>>> BuscarContaLuz(int idContaLuz)
        {
            var contaLuz = await _contaLuzRepository.BuscarContaLuz(idContaLuz);
            return Ok(contaLuz);
        }

        [HttpGet("BuscarContaLuzPorUsuario/{idUsuario}")]
        public async Task<ActionResult<ResponseModel<List<ContaLuzModel>>>> BuscarContaLuzPorUsuario(int idUsuario)
        {
            var contasLuz = await _contaLuzRepository.BuscarContaLuzPorUsuario(idUsuario);
            return Ok(contasLuz);
        }

        [HttpPost("CadastrarContaLuz")]
        public async Task<ActionResult<ResponseModel<List<ContaLuzModel>>>> CadastrarContaLuz(CriarContaLuzDto criarContaLuzDto)
        {
            var contasLuz = await _contaLuzRepository.CadastrarContaLuz(criarContaLuzDto);
            return Ok(contasLuz);
        }

        [HttpPut("EditarContaLuz")]
        public async Task<ActionResult<ResponseModel<List<ContaLuzModel>>>> EditarContaLuz(EditarContaLuzDto editarContaLuzDto)
        {
            var contasLuz = await _contaLuzRepository.EditarContaLuz(editarContaLuzDto);
            return Ok(contasLuz);
        }

        [HttpDelete("DeletarContaLuz/{idContaLuz}")]
        public async Task<ActionResult<ResponseModel<List<ContaLuzModel>>>> DeletarContaLuz(int idContaLuz)
        {
            var contasLuz = await _contaLuzRepository.DeletarContaLuz(idContaLuz);
            return Ok(contasLuz);
        }
    }
}
