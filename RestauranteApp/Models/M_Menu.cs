using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestauranteApp.Models
{
    public class M_Menu
    {
        public int IdMenu { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(25, ErrorMessage = "La descripción no puede tener más de 25 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(100, 50000, ErrorMessage = "El precio debe estar entre ₡100 y ₡50,000")]
        public decimal Precio { get; set; }
    }
}