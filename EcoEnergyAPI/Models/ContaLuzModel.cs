using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcoEnergyAPI.Models
{
    [Table("CONTA_LUZ")]
    public class ContaLuzModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdContaLuz { get; set; }

        [Required]
        public string Regiao { get; set; }

        [Required]
        public string Mes { get; set; }

        [Required]
        public float DiasNoMes { get; set; }

        [Required]
        public float TarifaKWh { get; set; }

        [Required]
        public string ClasseConsumo { get; set; }

        [Required]
        public float Impostos { get; set; }

        [Required]
        public float ValorConta { get; set; }

       
        public UsuarioModel Usuario { get; set; }
    }
}
