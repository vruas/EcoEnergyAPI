using EcoEnergyAPI.Data;
using EcoEnergyAPI.Dto.Usuario;
using EcoEnergyAPI.Models;
using EcoEnergyAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoEnergyAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios()
        {
            ResponseModel<List<UsuarioModel>> response = new ResponseModel<List<UsuarioModel>>();
            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();

                response.Dados = usuarios;
                response.Mensagem = "Usuários listados com sucesso!";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
            }

            return response;
        }

        public async Task<ResponseModel<UsuarioModel>> BuscarUsuarioPorId(int idUsuario)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(cadUser => cadUser.IdUsuario == idUsuario);

                if (usuario == null)
                {
                    response.Mensagem = "Usuário não encontrado!";
                    response.Status = false;
                    return response;
                }

                response.Dados = usuario;
                response.Mensagem = "Usuário encontrado com sucesso!";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
            }

            return response;
        }

        public async Task<ResponseModel<List<UsuarioModel>>> CadastrarUsuario(CriarUsuarioDto criarUsuarioDto)
        {
           ResponseModel<List<UsuarioModel>> response = new ResponseModel<List<UsuarioModel>>();
            try
            {
                var usuario = new UsuarioModel()
                {
                    Nome = criarUsuarioDto.Nome,
                    Endereco = criarUsuarioDto.Endereco,
                    CpfCnpj = criarUsuarioDto.CpfCnpj,
                    NomeUsuario = criarUsuarioDto.NomeUsuario,
                    Senha = criarUsuarioDto.Senha
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Usuarios.ToListAsync();
                response.Mensagem = "Usuário cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
            }

            return response;
        }

        public async Task<ResponseModel<List<UsuarioModel>>> AtualizarUsuario(EditarUsuarioDto editarUsuarioDto)
        {
            ResponseModel<List<UsuarioModel>> response = new ResponseModel<List<UsuarioModel>>();
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(cadUser => cadUser.IdUsuario == editarUsuarioDto.IdUsuario);
                
                if (usuario == null)
                {
                    response.Mensagem = "Usuário não encontrado!";
                    response.Status = false;
                    return response;
                }

                usuario.Nome = editarUsuarioDto.Nome;
                usuario.Endereco = editarUsuarioDto.Endereco;
                usuario.CpfCnpj = editarUsuarioDto.CpfCnpj;
                usuario.NomeUsuario = editarUsuarioDto.NomeUsuario;
                usuario.Senha = editarUsuarioDto.Senha;

                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Usuarios.ToListAsync();
                response.Mensagem = "Usuário atualizado com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async  Task<ResponseModel<List<UsuarioModel>>> DeletarUsuario(int idUsuario)
        {
            ResponseModel<List<UsuarioModel>> response = new ResponseModel<List<UsuarioModel>>();
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(cadUser => cadUser.IdUsuario == idUsuario);

                if (usuario == null)
                {
                    response.Mensagem = "Usuário não encontrado!";
                    response.Status = false;
                    return response;
                }

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Usuarios.ToListAsync();
                response.Mensagem = "Usuário deletado com sucesso!";

                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

                return response;
            }
        }

       
    }
}
