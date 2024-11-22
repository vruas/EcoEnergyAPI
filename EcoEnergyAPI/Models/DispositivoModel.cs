using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoEnergyAPI.Models
{
    [Table("DISPOSITIVO")]
    public class DispositivoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDispositivo { get; set; }
        [Required]
        public string NomeDispositivo { get; set; }
        [Required]
        public string TipoDispositivo { get; set; }
        [Required]
        public float ConsumoWatts { get; set; }
        [Required]
        public string EstadoDispositivo { get; set; }

        public UsuarioModel Usuario { get; set; }
    }
}
