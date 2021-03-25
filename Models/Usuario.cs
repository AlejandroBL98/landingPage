using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace landingP.Models
{
    public class Usuario
    {
       
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(10, ErrorMessage = "El numero de documento excede el numero maximo de caracteres (100)")]
        public string Nombre { get; set; }

        [MaxLength(10, ErrorMessage = "El numero de celular excede el numero maximo de caracteres (100)")]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [EmailAddress(ErrorMessage = "Debe ingresar un mail válido")]
        [MaxLength(10, ErrorMessage = "El numero de documento excede el numero maximo de caracteres (100)")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El mensage es obligatorio")]
        [MaxLength(10, ErrorMessage = "El numero de documento excede el numero maximo de caracteres (100)")]
        public string Mensage { get; set; }

    }
}