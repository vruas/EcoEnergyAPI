using EcoEnergyAPI.Dto.ContaLuz;
using EcoEnergyAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EcoEnergyAPI.Repositories.Interfaces
{
    public interface IContaLuzRepository
    {
        Task<ResponseModel<List<ContaLuzModel>>> ListarContasLuz();
        Task<ResponseModel<ContaLuzModel>> BuscarContaLuz(int idContaLuz);
        Task<ResponseModel<List<ContaLuzModel>>> BuscarContaLuzPorUsuario(int idUsuario);
        Task<ResponseModel<List<ContaLuzModel>>> CadastrarContaLuz(CriarContaLuzDto criarContaLuzDto);
        Task<ResponseModel<List<ContaLuzModel>>> EditarContaLuz(EditarContaLuzDto editarContaLuzDto);
        Task<ResponseModel<List<ContaLuzModel>>> DeletarContaLuz(int idContaLuz);
    }
}
