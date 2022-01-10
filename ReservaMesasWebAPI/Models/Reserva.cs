using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ReservaMesasWebAPI.Models
{
    public class Reserva
    {
        public int id { get; set; }
        [Required]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime data { get; set; }
        public DateTime horainicio { get; set; }
        public DateTime horaFim { get; set; }
        public int clienteId { get; set; }
        public Cliente? cliente { get; set; }
        public int mesaId { get; set; }
        public Mesa? mesa { get; set; }
    }
}
