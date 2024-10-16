using System.ComponentModel.DataAnnotations;

namespace practicaInterview.Models
{
    public class bookModel
    {
        public int id_book { get; set; }
        [Required(ErrorMessage = "el campo nombre es obligatorio")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "el campo descripcion es obligatorio")]
        public string descripcion { get; set; }
        [Required(ErrorMessage = "el campo seleccionar autor es obligatorio")]
        public int id_user { get; set; }

        public string? autor { get; set; }

    }
}
