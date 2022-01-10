namespace ReservaMesasWebAPI.Models
{
    public class AreaMesa
    {
        public int id { get; set; }
        public string nome { get; set; }
        public List<Mesa>? mesas { get; set; }
    }
}
