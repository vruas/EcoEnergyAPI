using EcoEnergyAPI.Data;
using EcoEnergyAPI.Dto.Tarefa;
using EcoEnergyAPI.Models;
using EcoEnergyAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoEnergyAPI.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<TarefaModel>>> ListarTarefas()
        {
            ResponseModel<List<TarefaModel>> response = new ResponseModel<List<TarefaModel>>();
            try
            {
                var tarefas = await _context.Tarefas.Include(u => u.Usuario).ToListAsync();

                response.Dados = tarefas;
                response.Mensagem = "Tarefas listadas com sucesso";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

            }

            return response;
        }

        public async Task<ResponseModel<TarefaModel>> BuscarTarefa(int idTarefa)
        {
            ResponseModel<TarefaModel> response = new ResponseModel<TarefaModel>();
            try
            {
                var tarefa = await _context.Tarefas.Include(u => u.Usuario).FirstOrDefaultAsync(cadTask => cadTask.IdTarefa == idTarefa);

                if (tarefa == null)
                {
                    response.Mensagem = "Tarefa não encontrada";
                    response.Status = false;
                    return response;
                }

                response.Dados = tarefa;
                response.Mensagem = "Tarefa encontrada com sucesso";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

            }

            return response;
        }

        public async Task<ResponseModel<List<TarefaModel>>> BuscarTarefaPorUsuario(int idUsuario)
        {
            ResponseModel<List<TarefaModel>> response = new ResponseModel<List<TarefaModel>>();
            try
            {
                var tarefa = await _context.Tarefas.Include(u => u.Usuario)
                    .Where(cadTask => cadTask.Usuario.IdUsuario == idUsuario).ToListAsync();

                if (tarefa == null)
                {
                    response.Mensagem = "Tarefa não encontrada";
                    response.Status = false;
                }

                response.Dados = tarefa;
                response.Mensagem = "Tarefa encontrada com sucesso";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

            }

            return response;
        }

        public async Task<ResponseModel<List<TarefaModel>>> CadastrarTarefa(CriarTarefaDto criarTarefaDto)
        {
            ResponseModel<List<TarefaModel>> response = new ResponseModel<List<TarefaModel>>();
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(cadUser => cadUser.IdUsuario == criarTarefaDto.Usuario.IdUsuario);

                if (usuario == null)
                {
                    response.Mensagem = "Usuário não encontrado";
                    response.Status = false;
                    return response;
                }

                TarefaModel tarefa = new TarefaModel()
                {
                    Titulo = criarTarefaDto.Titulo,
                    Descricao = criarTarefaDto.Descricao,
                    Status = criarTarefaDto.Status,
                    Usuario = usuario
                };

                _context.Tarefas.Add(tarefa);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Tarefas.Include(u => u.Usuario).ToListAsync();
                response.Mensagem = "Tarefa cadastrada com sucesso";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

            }

            return response;
        }

        public async Task<ResponseModel<List<TarefaModel>>> EditarTarefa(EditarTarefaDto editarTarefaDto)
        {
            ResponseModel<List<TarefaModel>> response = new ResponseModel<List<TarefaModel>>();
            try
            {
                var tarefa = await _context.Tarefas.Include(u => u.Usuario).FirstOrDefaultAsync(cadTask => cadTask.IdTarefa == editarTarefaDto.IdTarefa);
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(cadUser => cadUser.IdUsuario == editarTarefaDto.Usuario.IdUsuario);

                if (tarefa == null)
                {
                    response.Mensagem = "Tarefa não encontrada";
                    response.Status = false;
                    return response;
                }

                if (usuario == null)
                {
                    response.Mensagem = "Usuário não encontrado";
                    response.Status = false;
                    return response;
                }

                tarefa.Titulo = editarTarefaDto.Titulo;
                tarefa.Descricao = editarTarefaDto.Descricao;
                tarefa.Status = editarTarefaDto.Status;
                tarefa.Usuario = usuario;

                _context.Tarefas.Update(tarefa);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Tarefas.Include(u => u.Usuario).ToListAsync();
                response.Mensagem = "Tarefa editada com sucesso";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

            }

            return response;

        }

        public async Task<ResponseModel<List<TarefaModel>>> DeletarTarefa(int idTarefa)
        {
            ResponseModel<List<TarefaModel>> response = new ResponseModel<List<TarefaModel>>();
            try
            {
                var tarefa = await _context.Tarefas.Include(u => u.Usuario).FirstOrDefaultAsync(cadTask => cadTask.IdTarefa == idTarefa);

                if (tarefa == null)
                {
                    response.Mensagem = "Tarefa não encontrada";
                    response.Status = false;
                    return response;
                }

                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Tarefas.ToListAsync();
                response.Mensagem = "Tarefa deletada com sucesso";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

            }
            return response;
        }
        
    }
}
