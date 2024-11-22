namespace EcoEnergyAPI.Dto.Dispositivo
{
    public class CriarDispositivoDto
    {
        public string NomeDispositivo { get; set; }
        public string TipoDispositivo { get; set; }
        public float ConsumoWatts { get; set; }
        public string EstadoDispositivo { get; set; }
        public int IdUsuario { get; set; }

        UserLinkDto Usuario { get; set; }
    }
}
