namespace ReservaMesasWebAPI.Models
{
    public class Mesa
    {
        public int id { get; set; }
        public int qtdlugares { get; set; }
        public int numMesa { get; set; }
        public bool funcionando { get; set; }
        public int idAreaMesa { get; set; }
        public AreaMesa? area { get; set; }
        public List<Reserva>? reservas { get; set; }

    }
}
