namespace EcoEnergyAPI.Dto.Tarefa
{
    public class CriarTarefaDto
    {
       public string Titulo { get; set; }
       public string Descricao { get; set; }
       public string Status { get; set; }

       public UserLinkDto Usuario { get; set; }

    }
}
