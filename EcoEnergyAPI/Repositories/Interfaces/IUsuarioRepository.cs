using EcoEnergyAPI.Models;
using EcoEnergyAPI.Dto.Usuario;

namespace EcoEnergyAPI.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios();
        Task<ResponseModel<UsuarioModel>> BuscarUsuarioPorId(int idUsuario);
        Task<ResponseModel<List<UsuarioModel>>> CadastrarUsuario(CriarUsuarioDto criarUsuarioDto);
        Task<ResponseModel<List<UsuarioModel>>> AtualizarUsuario(EditarUsuarioDto editarUsuarioDto);
        Task<ResponseModel<List<UsuarioModel>>> DeletarUsuario(int idUsuario);
    }
}
