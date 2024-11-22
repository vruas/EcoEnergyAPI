using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EcoEnergyAPI.Models
{
    [Table("USUARIO")]
    public class UsuarioModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public string CpfCnpj { get; set; }

        [Required]
        public string NomeUsuario { get; set; }

        [Required]
        public string Senha { get; set; }

        [JsonIgnore]
        public ICollection<ContaLuzModel> ContasLuz { get; set; }
        [JsonIgnore]
        public ICollection<TarefaModel> Tarefas { get; set; }
        [JsonIgnore]
        public ICollection<DispositivoModel> Dispositivos { get; set; }
    }
}
