using EcoEnergyAPI.Dto.Dispositivo;
using EcoEnergyAPI.Models;

namespace EcoEnergyAPI.Repositories.Interfaces
{
    public interface IDispositivoRepository
    {
        Task<ResponseModel<List<DispositivoModel>>> ListarDispositivos();
        Task<ResponseModel<DispositivoModel>> BuscarDispositivo(int idDispositivo);
        Task<ResponseModel<List<DispositivoModel>>> BuscarDispositivosUsuario(int idUsuario);
        Task<ResponseModel<List<DispositivoModel>>> CadastrarDispositivo(CriarDispositivoDto criarDispositivoDto);
        Task<ResponseModel<List<DispositivoModel>>> EditarDispositivo(EditarDispositivoDto editarDispositivoDto);
        Task<ResponseModel<List<DispositivoModel>>> DeletarDispositivo(int idDispositivo);
    }
}
