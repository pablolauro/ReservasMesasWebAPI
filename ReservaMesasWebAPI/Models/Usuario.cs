using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaMesasWebAPI.Models
{
    public class Usuario
    {
        [Key]
        public string login { get; set; }        
        public string password { get; set; }
    }
}
