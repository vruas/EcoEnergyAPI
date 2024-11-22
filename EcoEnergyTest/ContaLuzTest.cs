using EcoEnergyAPI.Controllers;
using EcoEnergyAPI.Dto.ContaLuz;
using EcoEnergyAPI.Models;
using EcoEnergyAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoEnergyTests
{
    public class ContaLuzTest
    {
        [Fact]
        public async Task GetAllContasAsyncTest()
        {
            // Arrange
            var mockRepository = new Mock<IContaLuzRepository>();
            mockRepository.Setup(repo => repo.ListarContasLuz()).ReturnsAsync(new ResponseModel<List<ContaLuzModel>>
            {
                Dados = new List<ContaLuzModel>
                {
                    new ContaLuzModel { IdContaLuz = 1 },
                    new ContaLuzModel { IdContaLuz = 2 },
                    new ContaLuzModel { IdContaLuz = 3 }
                },

                Status = true
            });

            var controller = new ContaLuzController(mockRepository.Object);

            // Act
            var result = await controller.ListarContasLuz();

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var response = Assert.IsType<ResponseModel<List<ContaLuzModel>>>(okResult.Value);
            Assert.True(response.Status);
            Assert.Equal(3, response.Dados.Count);

        }

        [Fact]
        public async Task GetContaAsyncTest()
        {
            // Arrange
            var mockRepository = new Mock<IContaLuzRepository>();
            mockRepository.Setup(repo => repo.BuscarContaLuz(1)).ReturnsAsync(new ResponseModel<ContaLuzModel>
            {
                Dados = new ContaLuzModel { IdContaLuz = 1 },
                Status = true
            });

            var controller = new ContaLuzController(mockRepository.Object);

            // Act
            var result = await controller.BuscarContaLuz(1);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var response = Assert.IsType<ResponseModel<ContaLuzModel>>(okResult.Value);
            Assert.True(response.Status);
            Assert.Equal(1, response.Dados.IdContaLuz);
        }

        [Fact]
        public async Task CreateContaAsyncTest()
        {
            // Arrange
            var mockRepository = new Mock<IContaLuzRepository>();
            mockRepository.Setup(repo => repo.CadastrarContaLuz(It.IsAny<CriarContaLuzDto>())).ReturnsAsync(new ResponseModel<List<ContaLuzModel>>
            {
                Dados = new List<ContaLuzModel>
                {
                    new ContaLuzModel { IdContaLuz = 1, Regiao = "", Mes = "", DiasNoMes = 0, TarifaKWh = 0, ClasseConsumo = "", Impostos = 0, ValorConta = 0 },
                    new ContaLuzModel { IdContaLuz = 2, Regiao = "", Mes = "", DiasNoMes = 0, TarifaKWh = 0, ClasseConsumo = "", Impostos = 0, ValorConta = 0 },
                    new ContaLuzModel { IdContaLuz = 3, Regiao = "", Mes = "", DiasNoMes = 0, TarifaKWh = 0, ClasseConsumo = "", Impostos = 0, ValorConta = 0 }
                },
            });

            var controller = new ContaLuzController(mockRepository.Object);

            // Act
            var result = await controller.CadastrarContaLuz(new CriarContaLuzDto());

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var response = Assert.IsType<ResponseModel<ContaLuzModel>>(okResult.Value);
            Assert.True(response.Status);
            Assert.Equal(3, response.Dados.IdContaLuz);
        }

        [Fact]
        public async Task UpdateContaAsyncTest()
        {
            // Arrange
            var mockRepository = new Mock<IContaLuzRepository>();
            mockRepository.Setup(repo => repo.EditarContaLuz(It.IsAny<EditarContaLuzDto>())).ReturnsAsync(new ResponseModel<List<ContaLuzModel>>
            {
                Dados = new List<ContaLuzModel>
                {
                    new ContaLuzModel { IdContaLuz = 1, Regiao = "", Mes = "", DiasNoMes = 0, TarifaKWh = 0, ClasseConsumo = "", Impostos = 0, ValorConta = 0 },
                    new ContaLuzModel { IdContaLuz = 2, Regiao = "", Mes = "", DiasNoMes = 0, TarifaKWh = 0, ClasseConsumo = "", Impostos = 0, ValorConta = 0 },
                    new ContaLuzModel { IdContaLuz = 3, Regiao = "", Mes = "", DiasNoMes = 0, TarifaKWh = 0, ClasseConsumo = "", Impostos = 0, ValorConta = 0 }
                },
                Status = true

            });

            var controller = new ContaLuzController(mockRepository.Object);

            // Act
            var result = await controller.EditarContaLuz(new EditarContaLuzDto { IdContaLuz = 1 });

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var response = Assert.IsType<ResponseModel<ContaLuzModel>>(okResult.Value);
            Assert.True(response.Status);
            Assert.Equal(3, response.Dados.IdContaLuz);
        }

        [Fact]
        public async Task DeleteContaAsyncTest()
        {
            // Arrange
            var mockRepository = new Mock<IContaLuzRepository>();
            mockRepository.Setup(repo => repo.DeletarContaLuz(1)).ReturnsAsync(new ResponseModel<List<ContaLuzModel>>
            {
                Dados = new List<ContaLuzModel>
                {
                    new ContaLuzModel { IdContaLuz = 1 },
                },


            });

            var controller = new ContaLuzController(mockRepository.Object);

            // Act
            var result = await controller.DeletarContaLuz(1);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var response = Assert.IsType<ResponseModel<ContaLuzModel>>(okResult.Value);
            Assert.True(response.Status);
            Assert.Equal(1, response.Dados.IdContaLuz);
        }
    }

}
