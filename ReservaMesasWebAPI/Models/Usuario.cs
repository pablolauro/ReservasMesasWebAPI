using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaMesasWebAPI.Models
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public string login { get; set; }        
        public string password { get; set; }
        public string tipo { get; set; }
        public Cliente? cliente { get; set; }

    }
}
