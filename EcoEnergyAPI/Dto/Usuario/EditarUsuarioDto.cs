namespace EcoEnergyAPI.Dto.Usuario
{
    public class EditarUsuarioDto
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CpfCnpj { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
    }
}
