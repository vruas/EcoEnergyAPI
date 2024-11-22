using EcoEnergyAPI.Controllers;
using EcoEnergyAPI.Dto.Usuario;
using EcoEnergyAPI.Models;
using EcoEnergyAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EcoEnergyTests
{
    public class UsuarioTest
    {
        [Fact]
        public async Task GetAllUsersAsyncTest()
        {
            // Arrange
            var mockRepository = new Mock<IUsuarioRepository>();
            mockRepository.Setup(repo => repo.ListarUsuarios()).ReturnsAsync(new ResponseModel<List<UsuarioModel>>
            {
                Dados = new List<UsuarioModel>
                            {
                                new UsuarioModel { IdUsuario = 1 },
                                new UsuarioModel { IdUsuario = 2 },
                                new UsuarioModel { IdUsuario = 3 }
                            },
                Status = true
            });
            var controller = new UsuarioController(mockRepository.Object);

            // Act
            var result = await controller.ListarUsuarios();

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var response = Assert.IsType<ResponseModel<List<UsuarioModel>>>(okResult.Value);
            Assert.True(response.Status);
            Assert.Equal(3, response.Dados.Count);
        }

        [Fact]
        public async Task GetUserAsyncTest()
        {
            // Arrange
            var mockRepository = new Mock<IUsuarioRepository>();
            mockRepository.Setup(repo => repo.BuscarUsuarioPorId(1)).ReturnsAsync(new ResponseModel<UsuarioModel>
            {
                Dados = new UsuarioModel { IdUsuario = 1 },
                Status = true
            });
            var controller = new UsuarioController(mockRepository.Object);

            // Act
            var result = await controller.BuscarUsuarioPorId(1);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var response = Assert.IsType<ResponseModel<UsuarioModel>>(okResult.Value);
            Assert.True(response.Status);
            Assert.Equal(1, response.Dados.IdUsuario);
        }

        [Fact]
        public async Task CreateUserAsyncTest()
        {
            // Arrange
            var mockRepository = new Mock<IUsuarioRepository>();
            mockRepository.Setup(repo => repo.CadastrarUsuario(It.IsAny<CriarUsuarioDto>())).ReturnsAsync(new ResponseModel<List<UsuarioModel>>
            {
                Dados = new List<UsuarioModel>
                            {
                                new UsuarioModel { IdUsuario = 1, Nome = "Vitor", Endereco = "Rua V", CpfCnpj = "600.762.910-49", NomeUsuario = "vetoor", Senha = "12345678" },
                                new UsuarioModel { IdUsuario = 2, Nome = "Lucas", Endereco = "Rua Z", CpfCnpj = "024.691.900-02", NomeUsuario = "zeca", Senha = "12345678" },
                                new UsuarioModel { IdUsuario = 3, Nome = "Gabriel", Endereco = "Rua G", CpfCnpj = "577.783.100-15", NomeUsuario = "gprevig", Senha = "12345678" }
                            },
                Status = true
            });
            var controller = new UsuarioController(mockRepository.Object);

            // Act
            var result = await controller.CadastrarUsuario(new CriarUsuarioDto());

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var response = Assert.IsType<ResponseModel<List<UsuarioModel>>>(okResult.Value);
            Assert.True(response.Status);
            Assert.Equal(3, response.Dados.Count);
        }

        [Fact]
        public async Task UpdateUserAsyncTest()
        {
            // Arrange
            var mockRepository = new Mock<IUsuarioRepository>();
            mockRepository.Setup(repo => repo.AtualizarUsuario(It.IsAny<EditarUsuarioDto>())).ReturnsAsync(new ResponseModel<List<UsuarioModel>>
            {
                Dados = new List<UsuarioModel>
                            {
                                new UsuarioModel { IdUsuario = 1, Nome = "Pedro", Endereco = "Rua P", CpfCnpj = "839.585.530-36", NomeUsuario = "pedro23", Senha = "12345678" },
                                new UsuarioModel { IdUsuario = 2, Nome = "Gustavo", Endereco = "Rua G", CpfCnpj = "341.023.720-83", NomeUsuario = "gustavofozalusa", Senha = "12345678" },
                                new UsuarioModel { IdUsuario = 3, Nome = "Mateus", Endereco = "Rua m", CpfCnpj = "208.792.320-56", NomeUsuario = "matvini", Senha = "12345678" }
                            },
                Status = true
            });
            var controller = new UsuarioController(mockRepository.Object);

            // Act
            var result = await controller.AtualizarUsuario(new EditarUsuarioDto { IdUsuario = 1 });

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var response = Assert.IsType<ResponseModel<List<UsuarioModel>>>(okResult.Value);
            Assert.True(response.Status);
            Assert.Equal(3, response.Dados.Count);
        }

        [Fact]
        public async Task DeleteUserAsyncTest()
        {
            // Arrange
            var mockRepository = new Mock<IUsuarioRepository>();
            mockRepository.Setup(repo => repo.DeletarUsuario(1)).ReturnsAsync(new ResponseModel<List<UsuarioModel>>
            {
                Dados = new List<UsuarioModel>
                            {
                                new UsuarioModel { IdUsuario = 1 },
                                new UsuarioModel { IdUsuario = 2 },
                                new UsuarioModel { IdUsuario = 3 }
                            },
                Status = true
            });
            var controller = new UsuarioController(mockRepository.Object);

            // Act
            var result = await controller.DeletarUsuario(1);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var response = Assert.IsType<ResponseModel<List<UsuarioModel>>>(okResult.Value);
            Assert.True(response.Status);
            Assert.Equal(3, response.Dados.Count);
        }
    }
}
