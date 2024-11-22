using EcoEnergyAPI.Controllers;
using EcoEnergyAPI.Dto.Tarefa;
using EcoEnergyAPI.Models;
using EcoEnergyAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EcoEnergyTests
{
    public class TarefaTest
    {
        [Fact]
        public async Task GetAllTasksAsyncTest()
        {
            // Arrange
            var mockRepository = new Mock<ITarefaRepository>();
            mockRepository.Setup(repo => repo.ListarTarefas()).ReturnsAsync(new ResponseModel<List<TarefaModel>>
            {
                Dados = new List<TarefaModel>
                {
                    new TarefaModel { IdTarefa = 1 },
                    new TarefaModel { IdTarefa = 2 },
                    new TarefaModel { IdTarefa = 3 }
                },

                Status = true
            });

            var controller = new TarefaController(mockRepository.Object);

            // Act
            var result = await controller.ListarTarefas();

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var response = Assert.IsType<ResponseModel<List<TarefaModel>>>(okResult.Value);
            Assert.True(response.Status);
            Assert.Equal(3, response.Dados.Count);
        }

        [Fact]
        public async Task GetTaskAsyncTest()
        {
            // Arrange
            var mockRepository = new Mock<ITarefaRepository>();
            mockRepository.Setup(repo => repo.BuscarTarefa(1)).ReturnsAsync(new ResponseModel<TarefaModel>
            {
                Dados = new TarefaModel { IdTarefa = 1 },
                Status = true
            });

            var controller = new TarefaController(mockRepository.Object);

            // Act
            var result = await controller.BuscarTarefa(1);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var response = Assert.IsType<ResponseModel<TarefaModel>>(okResult.Value);
            Assert.True(response.Status);
            Assert.Equal(1, response.Dados.IdTarefa);
        }

        [Fact]
        public async Task CreateTaskAsyncTest()
        {
            // Arrange
            var mockRepository = new Mock<ITarefaRepository>();
            mockRepository.Setup(repo => repo.CadastrarTarefa(It.IsAny<CriarTarefaDto>())).ReturnsAsync(new ResponseModel<List<TarefaModel>>
            {
                Dados = new List<TarefaModel>
                {
                    new TarefaModel { IdTarefa = 1, Titulo = "", Descricao = "", Status = "" },
                    new TarefaModel { IdTarefa = 2, Titulo = "", Descricao = "", Status = "" },
                    new TarefaModel { IdTarefa = 3, Titulo = "", Descricao = "", Status = "" }

                },
                Status = true
            });
           

            var controller = new TarefaController(mockRepository.Object);

            // Act
            var result = await controller.CadastrarTarefa(new CriarTarefaDto());

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var response = Assert.IsType<ResponseModel<TarefaModel>>(okResult.Value);
            Assert.True(response.Status);
            Assert.Equal(1, response.Dados.IdTarefa);
        }

        [Fact]
        public async Task UpdateTaskAsyncTest()
        {
            // Arrange
            var mockRepository = new Mock<ITarefaRepository>();
            mockRepository.Setup(repo => repo.EditarTarefa(It.IsAny<EditarTarefaDto>())).ReturnsAsync(new ResponseModel<List<TarefaModel>>
            {
                Dados = new List<TarefaModel>
                {
                    new TarefaModel { IdTarefa = 1, Titulo = "", Descricao = "", Status = "" },
                    new TarefaModel { IdTarefa = 2, Titulo = "", Descricao = "", Status = "" },
                    new TarefaModel { IdTarefa = 3, Titulo = "", Descricao = "", Status = "" }
                },
                Status = true

            });

            var controller = new TarefaController(mockRepository.Object);

            // Act
            var result = await controller.EditarTarefa(new EditarTarefaDto());

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var response = Assert.IsType<ResponseModel<TarefaModel>>(okResult.Value);
            Assert.True(response.Status);
            Assert.Equal(1, response.Dados.IdTarefa);
        }

        [Fact]
        public async Task DeleteTaskAsyncTest()
        {
            // Arrange
            var mockRepository = new Mock<ITarefaRepository>();
            mockRepository.Setup(repo => repo.DeletarTarefa(1)).ReturnsAsync(new ResponseModel<List<TarefaModel>>
            {
                Dados = new List<TarefaModel>
                {
                    new TarefaModel { IdTarefa = 1 }
                },
                Status = true

            });

            var controller = new TarefaController(mockRepository.Object);

            // Act
            var result = await controller.DeletarTarefa(1);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var response = Assert.IsType<ResponseModel<TarefaModel>>(okResult.Value);
            Assert.True(response.Status);
            Assert.Equal(1, response.Dados.IdTarefa);
        }
    }
}
