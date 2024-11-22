using EcoEnergyAPI.Dto.Tarefa;
using EcoEnergyAPI.Models;

namespace EcoEnergyAPI.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        Task<ResponseModel<List<TarefaModel>>> ListarTarefas();
        Task<ResponseModel<TarefaModel>> BuscarTarefa(int idTarefa);
        Task<ResponseModel<List<TarefaModel>>> BuscarTarefaPorUsuario(int idUsuario);
        Task<ResponseModel<List<TarefaModel>>> CadastrarTarefa(CriarTarefaDto criarTarefaDto);
        Task<ResponseModel<List<TarefaModel>>> EditarTarefa(EditarTarefaDto editarTarefaDto);
        Task<ResponseModel<List<TarefaModel>>> DeletarTarefa(int idTarefa);

    }
}
