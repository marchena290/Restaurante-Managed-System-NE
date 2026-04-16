using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestauranteApp.Models
{
    public class M_Mesa
    {
        public int IdMesa { get; set; }

        [Required(ErrorMessage = "El número de mesa es obligatorio")]
        [Display(Name = "Número de Mesa")]
        public int NumeroMesa { get; set; }

        [Required(ErrorMessage = "La capacidad es obligatoria")]
        [Range(1, 20, ErrorMessage = "La capacidad debe estar entre 1 y 20 personas")]
        public int Capacidad { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [StringLength(20, ErrorMessage = "El estado no debe exceder los 20 caracteres")]
        public string Estado { get; set; }
    }
}