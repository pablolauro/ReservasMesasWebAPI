namespace ReservaMesasWebAPI.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public List<Reserva>? reservas { get; set; }
        public int? usuarioId { get;  set; }
        public Usuario? usuario { get; set; }
    }
}
