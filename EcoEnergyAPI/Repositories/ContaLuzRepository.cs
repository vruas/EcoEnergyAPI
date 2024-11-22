using EcoEnergyAPI.Data;
using EcoEnergyAPI.Dto.ContaLuz;
using EcoEnergyAPI.Models;
using EcoEnergyAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoEnergyAPI.Repositories
{
    public class ContaLuzRepository : IContaLuzRepository
    {
        private readonly AppDbContext _context;

        public ContaLuzRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ContaLuzModel>>> ListarContasLuz()
        {
            ResponseModel<List<ContaLuzModel>> response = new ResponseModel<List<ContaLuzModel>>();
            try
            {
                var contasLuz = await _context.ContasLuz.Include(u => u.Usuario).ToListAsync();

                response.Dados = contasLuz;
                response.Mensagem = "Contas de luz listadas com sucesso";


            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

            }

            return response;
        }

        public async Task<ResponseModel<ContaLuzModel>> BuscarContaLuz(int idContaLuz)
        {
            ResponseModel<ContaLuzModel> response = new ResponseModel<ContaLuzModel>();
            try
            {
                var contaLuz = await _context.ContasLuz.Include(u => u.Usuario).FirstOrDefaultAsync(cadConta => cadConta.IdContaLuz == idContaLuz);

                if (contaLuz == null)
                {
                    response.Mensagem = "Conta de luz não encontrada";
                    response.Status = false;
                    return response;
                }

                response.Dados = contaLuz;
                response.Mensagem = "Conta de luz encontrada com sucesso";


            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

            }

            return response;
        }

        public async Task<ResponseModel<List<ContaLuzModel>>> BuscarContaLuzPorUsuario(int idUsuario)
        {
            ResponseModel<List<ContaLuzModel>> response = new ResponseModel<List<ContaLuzModel>>();
            try
            {
                var contaLuz = await _context.ContasLuz.Include(u => u.Usuario)
                    .Where(cadConta => cadConta.Usuario.IdUsuario == idUsuario).ToListAsync();

                if (contaLuz == null)
                {
                    response.Mensagem = "Conta de luz não encontrada";
                    response.Status = false;
                    return response;
                }

                response.Dados = contaLuz;
                response.Mensagem = "Conta de luz encontrada com sucesso";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

            }

            return response;
        }

        public async Task<ResponseModel<List<ContaLuzModel>>> CadastrarContaLuz(CriarContaLuzDto criarContaLuzDto)
        {
            ResponseModel<List<ContaLuzModel>> response = new ResponseModel<List<ContaLuzModel>>();
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == criarContaLuzDto.Usuario.IdUsuario);

                var contaLuz = new ContaLuzModel()
                {
                    Regiao = criarContaLuzDto.Regiao,
                    Mes = criarContaLuzDto.Mes,
                    DiasNoMes = criarContaLuzDto.DiasNoMes,
                    TarifaKWh = criarContaLuzDto.TarifaKWh,
                    ClasseConsumo = criarContaLuzDto.ClasseConsumo,
                    Impostos = criarContaLuzDto.Impostos,
                    ValorConta = criarContaLuzDto.ValorConta,
                    Usuario = usuario
                };

                _context.Add(contaLuz);
                await _context.SaveChangesAsync();

                response.Dados = await _context.ContasLuz.Include(u => u.Usuario).ToListAsync();
                response.Mensagem = "Conta de luz cadastrada com sucesso";

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

            }

            return response;
        }

        public async Task<ResponseModel<List<ContaLuzModel>>> EditarContaLuz(EditarContaLuzDto editarContaLuzDto)
        {
            ResponseModel<List<ContaLuzModel>> response = new ResponseModel<List<ContaLuzModel>>();
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(cadUser => cadUser.IdUsuario == editarContaLuzDto.Usuario.IdUsuario);

                var contaLuz = await _context.ContasLuz.Include(u => u.Usuario).FirstOrDefaultAsync(cadConta => cadConta.IdContaLuz == editarContaLuzDto.IdContaLuz);

                if (contaLuz == null)
                {
                    response.Mensagem = "Conta de luz não encontrada";
                    response.Status = false;
                    return response;
                }

                if (usuario == null)
                {
                    response.Mensagem = "Usuário não encontrado";
                    response.Status = false;
                    return response;
                }

                contaLuz.Regiao = editarContaLuzDto.Regiao;
                contaLuz.Mes = editarContaLuzDto.Mes;
                contaLuz.DiasNoMes = editarContaLuzDto.DiasNoMes;
                contaLuz.TarifaKWh = editarContaLuzDto.TarifaKWh;
                contaLuz.ClasseConsumo = editarContaLuzDto.ClasseConsumo;
                contaLuz.Impostos = editarContaLuzDto.Impostos;
                contaLuz.ValorConta = editarContaLuzDto.ValorConta;
                contaLuz.Usuario = usuario;

                _context.Update(contaLuz);
                await _context.SaveChangesAsync();

                response.Dados = await _context.ContasLuz.ToListAsync();
                response.Mensagem = "Conta de luz editada com sucesso";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

            }

            return response;

        }

        public async Task<ResponseModel<List<ContaLuzModel>>> DeletarContaLuz(int idContaLuz)
        {
            ResponseModel<List<ContaLuzModel>> response = new ResponseModel<List<ContaLuzModel>>();
            try
            {
                var contaLuz = await _context.ContasLuz.Include(u => u.Usuario).FirstOrDefaultAsync(cadConta => cadConta.IdContaLuz == idContaLuz);

                if (contaLuz == null)
                {
                    response.Mensagem = "Conta de luz não encontrada";
                    response.Status = false;
                    return response;
                }

                _context.ContasLuz.Remove(contaLuz);
                await _context.SaveChangesAsync();

                response.Dados = await _context.ContasLuz.ToListAsync();
                response.Mensagem = "Conta de luz deletada com sucesso";
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
