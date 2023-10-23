using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Email
    {
        [Key]
        public int IdEmail { get; set; }
        public string EmailUser { get; set; }
      
    }
}
