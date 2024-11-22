using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcoEnergyAPI.Repositories.Interfaces;
using EcoEnergyAPI.Models;
using EcoEnergyAPI.Dto.Usuario;

namespace EcoEnergyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("ListarUsuarios")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> ListarUsuarios()
        {
            var usuarios = await _usuarioRepository.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("BuscarUsuarioPorId/{idUsuario}")]
        public async Task<ActionResult<ResponseModel<UsuarioModel>>> BuscarUsuarioPorId(int idUsuario)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorId(idUsuario);
            return Ok(usuario);
        }

        [HttpPost("CadastrarUsuario")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> CadastrarUsuario(CriarUsuarioDto criarUsuarioDto)
        {
            var usuario = await _usuarioRepository.CadastrarUsuario(criarUsuarioDto);
            return Ok(usuario);
        }

        [HttpPut("AtualizarUsuario")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> AtualizarUsuario(EditarUsuarioDto editarUsuarioDto)
        {
            var usuario = await _usuarioRepository.AtualizarUsuario(editarUsuarioDto);
            return Ok(usuario);
        }

        [HttpDelete("DeletarUsuario/{idUsuario}")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> DeletarUsuario(int idUsuario)
        {
            var usuario = await _usuarioRepository.DeletarUsuario(idUsuario);
            return Ok(usuario);
        }

    }
}
