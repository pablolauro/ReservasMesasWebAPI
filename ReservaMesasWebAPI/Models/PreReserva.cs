namespace ReservaMesasWebAPI.Models
{
    public class PreReserva
    {
        public int id { get; set; }
        public DateTime data { get; set; }
        public string nomecliente { get; set; }
        public string emailcliente { get; set; }
        public string fonecliente { get; set; }
        public string observacao { get; set; }
    }
}
