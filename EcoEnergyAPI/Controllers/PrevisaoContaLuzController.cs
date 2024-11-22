using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace EcoEnergyAPI.Controllers
{
    public class DadosContaDeLuz
    {
        [LoadColumn(0)] public float ConsumoMensal { get; set; }
        [LoadColumn(1)] public string Regiao { get; set; }
        [LoadColumn(2)] public float DiasNoMes { get; set; }
        [LoadColumn(3)] public float TarifaPorKWh { get; set; }
        [LoadColumn(4)] public string ClasseDeConsumo { get; set; }
        [LoadColumn(5)] public float Impostos { get; set; }
        [LoadColumn(6)] public float ValorConta { get; set; } // A coluna que queremos prever
    }

    public class PrevisaoPrecoContaLuz
    {
        [ColumnName("Score")] public float PrecoPrevisto { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class PrevisaoContaLuzController : ControllerBase
    {
        private readonly string caminhoModelo = Path.Combine(Environment.CurrentDirectory, "wwwroot", "ModeloContaDeLuz.zip");
        private readonly string caminhoTreinamento = Path.Combine(Environment.CurrentDirectory, "Data", "conta-luz-train.csv");
        private readonly MLContext mlContext;

        public PrevisaoContaLuzController()
        {
            mlContext = new MLContext();

            if (!System.IO.File.Exists(caminhoModelo))
            {
                TreinarModelo();
            }
        }

        private void TreinarModelo()
        {
            IDataView dadosTreinamento = mlContext.Data.LoadFromTextFile<DadosContaDeLuz>(
                path: caminhoTreinamento, hasHeader: true, separatorChar: ',');

            var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "ValorConta")
                .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "RegiaoEncoded", inputColumnName: "Regiao"))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "ClasseDeConsumoEncoded", inputColumnName: "ClasseDeConsumo"))
                .Append(mlContext.Transforms.Concatenate("Features",
                    "ConsumoMensal", "DiasNoMes", "TarifaPorKWh", "Impostos", "RegiaoEncoded", "ClasseDeConsumoEncoded"))
                .Append(mlContext.Regression.Trainers.Sdca());

            var modelo = pipeline.Fit(dadosTreinamento);
            mlContext.Model.Save(modelo, dadosTreinamento.Schema, caminhoModelo);
        }

        [HttpPost("PreverContaLuz")]
        public ActionResult<PrevisaoPrecoContaLuz> PreverContaLuz([FromBody] DadosContaDeLuz dados)
        {
            if (!System.IO.File.Exists(caminhoModelo))
            {
                return BadRequest("Modelo não encontrado.");
            }

            var modelo = mlContext.Model.Load(caminhoModelo, out _);
            var enginePrevisao = mlContext.Model.CreatePredictionEngine<DadosContaDeLuz, PrevisaoPrecoContaLuz>(modelo);
            var previsao = enginePrevisao.Predict(dados);

            return Ok(previsao);
        }
    }
}
