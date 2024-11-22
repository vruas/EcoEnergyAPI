using EcoEnergyAPI.Controllers;
using EcoEnergyAPI.Dto.Dispositivo;
using EcoEnergyAPI.Models;
using EcoEnergyAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EcoEnergyTests
{
    public class DispositivoTest
    {
        [Fact]
        public async Task GetAllDevicesAsyncTest()
        {
            // Arrange
            var mockRepository = new Mock<IDispositivoRepository>();
            mockRepository.Setup(repo => repo.ListarDispositivos()).ReturnsAsync(new ResponseModel<List<DispositivoModel>>
            {
                Dados = new List<DispositivoModel>
                {
                    new DispositivoModel { IdDispositivo = 1 },
                    new DispositivoModel { IdDispositivo = 2 },
                    new DispositivoModel { IdDispositivo = 3 }
                },
                Status = true
            });
            var controller = new DispositivoController(mockRepository.Object);

            // Act
            var result = await controller.ListarDispositivos();

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var response = Assert.IsType<ResponseModel<List<DispositivoModel>>>(okResult.Value);
            Assert.True(response.Status);
            Assert.Equal(3, response.Dados.Count);
        }

        [Fact]
        public async Task GetDeviceAsyncTest()
        {
            // Arrange
            var mockRepository = new Mock<IDispositivoRepository>();
            mockRepository.Setup(repo => repo.BuscarDispositivo(1)).ReturnsAsync(new ResponseModel<DispositivoModel>
            {
                Dados = new DispositivoModel { IdDispositivo = 1 },
                Status = true
            });
            var controller = new DispositivoController(mockRepository.Object);

            // Act
            var result = await controller.BuscarDispositivo(1);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var response = Assert.IsType<ResponseModel<DispositivoModel>>(okResult.Value);
            Assert.True(response.Status);
            Assert.Equal(1, response.Dados.IdDispositivo);
        }

        [Fact]
        public async Task CreateDeviceAsyncTest()
        {
            // Arrange
            var mockRepository = new Mock<IDispositivoRepository>();
            mockRepository.Setup(repo => repo.CadastrarDispositivo(It.IsAny<CriarDispositivoDto>())).ReturnsAsync(new ResponseModel<List<DispositivoModel>>
            {
                Dados = new List<DispositivoModel>
                {
                    new DispositivoModel { IdDispositivo = 1, NomeDispositivo = "Device1", TipoDispositivo = "Type1", ConsumoWatts = 100, EstadoDispositivo = "On" },
                    new DispositivoModel { IdDispositivo = 2, NomeDispositivo = "Device2", TipoDispositivo = "Type2", ConsumoWatts = 200, EstadoDispositivo = "Off" },
                    new DispositivoModel { IdDispositivo = 3, NomeDispositivo = "Device3", TipoDispositivo = "Type3", ConsumoWatts = 300, EstadoDispositivo = "On" }
                },
                Status = true
            });
            var controller = new DispositivoController(mockRepository.Object);

            // Act
            var result = await controller.CadastrarDispositivo(new CriarDispositivoDto());

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var response = Assert.IsType<ResponseModel<List<DispositivoModel>>>(okResult.Value);
            Assert.True(response.Status);
            Assert.Equal(3, response.Dados.Count);
        }

        [Fact]
        public async Task UpdateDeviceAsyncTest()
        {
            // Arrange
            var mockRepository = new Mock<IDispositivoRepository>();
            mockRepository.Setup(repo => repo.EditarDispositivo(It.IsAny<EditarDispositivoDto>())).ReturnsAsync(new ResponseModel<List<DispositivoModel>>
            {
                Dados = new List<DispositivoModel>
                {
                    new DispositivoModel { IdDispositivo = 1, NomeDispositivo = "UpdatedDevice1", TipoDispositivo = "Type1", ConsumoWatts = 120, EstadoDispositivo = "On" },
                    new DispositivoModel { IdDispositivo = 2, NomeDispositivo = "UpdatedDevice2", TipoDispositivo = "Type2", ConsumoWatts = 220, EstadoDispositivo = "Off" },
                    new DispositivoModel { IdDispositivo = 3, NomeDispositivo = "UpdatedDevice3", TipoDispositivo = "Type3", ConsumoWatts = 320, EstadoDispositivo = "On" }
                },
                Status = true
            });
            var controller = new DispositivoController(mockRepository.Object);

            // Act
            var result = await controller.EditarDispositivo(new EditarDispositivoDto { IdDispositivo = 1 });

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var response = Assert.IsType<ResponseModel<List<DispositivoModel>>>(okResult.Value);
            Assert.True(response.Status);
            Assert.Equal(3, response.Dados.Count);
        }

        [Fact]
        public async Task DeleteDeviceAsyncTest()
        {
            // Arrange
            var mockRepository = new Mock<IDispositivoRepository>();
            mockRepository.Setup(repo => repo.DeletarDispositivo(1)).ReturnsAsync(new ResponseModel<List<DispositivoModel>>
            {
                Dados = new List<DispositivoModel>
                {
                    new DispositivoModel { IdDispositivo = 1 },
                    new DispositivoModel { IdDispositivo = 2 },
                    new DispositivoModel { IdDispositivo = 3 }
                },
                Status = true
            });
            var controller = new DispositivoController(mockRepository.Object);

            // Act
            var result = await controller.DeletarDispositivo(1);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);

            var response = Assert.IsType<ResponseModel<List<DispositivoModel>>>(okResult.Value);
            Assert.True(response.Status);
            Assert.Equal(3, response.Dados.Count);
        }
    }
}
