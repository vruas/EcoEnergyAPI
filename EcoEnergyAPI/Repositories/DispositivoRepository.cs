using EcoEnergyAPI.Data;
using EcoEnergyAPI.Dto.Dispositivo;
using EcoEnergyAPI.Models;
using EcoEnergyAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoEnergyAPI.Repositories
{
    public class DispositivoRepository : IDispositivoRepository
    {
        private readonly AppDbContext _context;

        public DispositivoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<DispositivoModel>>> ListarDispositivos()
        {
            ResponseModel<List<DispositivoModel>> response = new ResponseModel<List<DispositivoModel>>();
            try
            {
                var dispositivos = await _context.Dispositivos.Include(u => u.Usuario).ToListAsync();
                response.Dados = dispositivos;
                response.Mensagem = "Dispositivos listados com sucesso";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

            }

            return response;
        }

        public async Task<ResponseModel<DispositivoModel>> BuscarDispositivo(int idDispositivo)
        {
            ResponseModel<DispositivoModel> response = new ResponseModel<DispositivoModel>();
            try
            {
                var dispositivo = await _context.Dispositivos.Include(u => u.Usuario).FirstOrDefaultAsync(cadDispositivo => cadDispositivo.IdDispositivo == idDispositivo);

                if (dispositivo == null)
                {
                    response.Mensagem = "Dispositivo não encontrado";
                    response.Status = false;
                    return response;
                }

                response.Dados = dispositivo;
                response.Mensagem = "Dispositivo encontrado com sucesso";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
            }
            return response;

        }

        public async Task<ResponseModel<List<DispositivoModel>>> BuscarDispositivosUsuario(int idUsuario)
        {
            ResponseModel<List<DispositivoModel>> response = new ResponseModel<List<DispositivoModel>>();
            try
            {
                var dispositivo = await _context.Dispositivos.Include(u => u.Usuario)
                    .Where(cadDispositivo => cadDispositivo.Usuario.IdUsuario == idUsuario).ToListAsync();

                if (dispositivo == null)
                {
                    response.Mensagem = "Nenhum dispositivo encontrado";
                    response.Status = false;
                    return response;
                }

                response.Dados = dispositivo;
                response.Mensagem = "Dispositivos encontrados com sucesso";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
            }

            return response;
        }

        public async Task<ResponseModel<List<DispositivoModel>>> CadastrarDispositivo(CriarDispositivoDto criarDispositivoDto)
        {
            ResponseModel<List<DispositivoModel>> response = new ResponseModel<List<DispositivoModel>>();
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == criarDispositivoDto.IdUsuario);

                var dispositivo = new DispositivoModel()
                {
                    NomeDispositivo = criarDispositivoDto.NomeDispositivo,
                    TipoDispositivo = criarDispositivoDto.TipoDispositivo,
                    ConsumoWatts = criarDispositivoDto.ConsumoWatts,
                    EstadoDispositivo = criarDispositivoDto.EstadoDispositivo,
                    Usuario = usuario
                };

                _context.Dispositivos.Add(dispositivo);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Dispositivos.Include(u => u.Usuario).ToListAsync();
                response.Mensagem = "Dispositivo cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

            }

            return response;
        }

        public async Task<ResponseModel<List<DispositivoModel>>> EditarDispositivo(EditarDispositivoDto editarDispositivoDto)
        {
           ResponseModel<List<DispositivoModel>> response = new ResponseModel<List<DispositivoModel>>();
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(cadUser => cadUser.IdUsuario == editarDispositivoDto.IdUsuario);

                var dispositivo = await _context.Dispositivos.Include(u => u.Usuario).FirstOrDefaultAsync(cadDispositivo => cadDispositivo.IdDispositivo == editarDispositivoDto.IdDispositivo);

                if (dispositivo == null)
                {
                    response.Mensagem = "Dispositivo não encontrado";
                    response.Status = false;
                    return response;
                }

                if (usuario == null)
                {
                    response.Mensagem = "Usuário não encontrado";
                    response.Status = false;
                    return response;
                }


                dispositivo.NomeDispositivo = editarDispositivoDto.NomeDispositivo;
                dispositivo.TipoDispositivo = editarDispositivoDto.TipoDispositivo;
                dispositivo.ConsumoWatts = editarDispositivoDto.ConsumoWatts;
                dispositivo.EstadoDispositivo = editarDispositivoDto.EstadoDispositivo;

                _context.Dispositivos.Update(dispositivo);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Dispositivos.ToListAsync();
                response.Mensagem = "Dispositivo editado com sucesso";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

            }

            return response;
        }

        public async Task<ResponseModel<List<DispositivoModel>>> DeletarDispositivo(int idDispositivo)
        {
            ResponseModel<List<DispositivoModel>> response = new ResponseModel<List<DispositivoModel>>();
            try
            {
                var dispositivo = await _context.Dispositivos.Include(u => u.Usuario).FirstOrDefaultAsync(cadDispositivo => cadDispositivo.IdDispositivo == idDispositivo);

                if (dispositivo == null)
                {
                    response.Mensagem = "Dispositivo não encontrado";
                    response.Status = false;
                    return response;
                }

                _context.Dispositivos.Remove(dispositivo);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Dispositivos.ToListAsync();
                response.Mensagem = "Dispositivo deletado com sucesso";
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
