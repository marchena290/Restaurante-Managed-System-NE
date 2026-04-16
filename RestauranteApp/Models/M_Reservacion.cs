using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestauranteApp.Models
{
    public class M_Reservacion
    {
        [Display(Name = "ID Reservación")]
        public int IdReservaciones { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un cliente")]
        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una mesa")]
        [Display(Name = "Mesa")]
        public int IdMesa { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un menú")]
        [Display(Name = "Menú")]
        public int IdMenu { get; set; }

        [Required(ErrorMessage = "Debe ingresar la cantidad")]
        [Range(1, 100, ErrorMessage = "La cantidad debe estar entre 1 y 100")]
        [Display(Name = "Cantidad de Platos")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Debe ingresar la fecha y hora")]
        [Display(Name = "Fecha y Hora de Reservación")]
        [DataType(DataType.DateTime)]
        public DateTime FechaReservacion { get; set; }
    }
}