using System.ComponentModel.DataAnnotations;

namespace practicaInterview.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "El campo email es obligatorio")]
        public string email { get; set; }

        [Required(ErrorMessage = "El campo contraseña es obligatorio")]
        public string userPassword { get; set; }
    }
}
