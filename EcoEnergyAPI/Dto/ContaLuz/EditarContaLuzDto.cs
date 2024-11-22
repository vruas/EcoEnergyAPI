using System.ComponentModel.DataAnnotations;

namespace EcoEnergyAPI.Dto.ContaLuz
{
    public class EditarContaLuzDto
    {

        public int IdContaLuz { get; set; }

        public string Regiao { get; set; }

        public string Mes { get; set; }

        public float DiasNoMes { get; set; }

        public float TarifaKWh { get; set; }

        public string ClasseConsumo { get; set; }

        public float Impostos { get; set; }

        public float ValorConta { get; set; }

        public UserLinkDto Usuario { get; set; }
    }
}
