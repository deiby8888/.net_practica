using System.ComponentModel.DataAnnotations;

namespace practicaInterview.Models
{
    public class ClientModel
    {
        public int id_user { get; set; }
        [Required(ErrorMessage = "el campo userName es obligatorio")]
        public string userName { get; set; }
        [Required(ErrorMessage = "el campo email es obligatorio")]
        public string email { get; set; }
        [Required(ErrorMessage = "el campo userPassword es obligatorio")]
        public string userPassword { get; set; }

        [Required(ErrorMessage = "el campo confirmar contraseña es obligatorio")]
        public string confir { get; set; }

        public string? newPassword { get; set; }
    }
}
