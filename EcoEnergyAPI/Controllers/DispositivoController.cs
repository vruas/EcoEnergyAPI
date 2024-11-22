using EcoEnergyAPI.Dto.Dispositivo;
using EcoEnergyAPI.Models;
using EcoEnergyAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoEnergyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispositivoController : ControllerBase
    {
        private readonly IDispositivoRepository _dispositivoRepository;

        public DispositivoController(IDispositivoRepository dispositivoRepository)
        {
            _dispositivoRepository = dispositivoRepository;
        }

        [HttpGet("ListarDispositivos")]
        public async Task<ActionResult<ResponseModel<List<DispositivoModel>>>> ListarDispositivos()
        {
            var dispositivos = await _dispositivoRepository.ListarDispositivos();
            return Ok(dispositivos);
        }

        [HttpGet("BuscarDispositivo/{idDispositivo}")]
        public async Task<ActionResult<ResponseModel<DispositivoModel>>> BuscarDispositivo(int idDispositivo)
        {
            var dispositivo = await _dispositivoRepository.BuscarDispositivo(idDispositivo);
            return Ok(dispositivo);
        }

        [HttpGet("BuscarDispositivosUsuario/{idUsuario}")]
        public async Task<ActionResult<ResponseModel<List<DispositivoModel>>>> BuscarDispositivosUsuario(int idUsuario)
        {
            var dispositivos = await _dispositivoRepository.BuscarDispositivosUsuario(idUsuario);
            return Ok(dispositivos);
        }

        [HttpPost("CadastrarDispositivo")]
        public async Task<ActionResult<ResponseModel<List<DispositivoModel>>>> CadastrarDispositivo(CriarDispositivoDto criarDispositivoDto)
        {
            var dispositivos = await _dispositivoRepository.CadastrarDispositivo(criarDispositivoDto);
            return Ok(dispositivos);
        }

        [HttpPut("EditarDispositivo")]
        public async Task<ActionResult<ResponseModel<List<DispositivoModel>>>> EditarDispositivo(EditarDispositivoDto editarDispositivoDto)
        {
            var dispositivos = await _dispositivoRepository.EditarDispositivo(editarDispositivoDto);
            return Ok(dispositivos);
        }

        [HttpDelete("DeletarDispositivo/{idDispositivo}")]
        public async Task<ActionResult<ResponseModel<List<DispositivoModel>>>> DeletarDispositivo(int idDispositivo)
        {
            var dispositivos = await _dispositivoRepository.DeletarDispositivo(idDispositivo);
            return Ok(dispositivos);
        }

    }
}
