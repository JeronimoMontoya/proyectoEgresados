using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace egresadosSENA.Models
{
    public class usuario
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El Documento es obligatorio")]
        [RegularExpression("[0123456789]", ErrorMessage = "Solo puede ingresar números")]
        public string documento { get; set; }


        public string tipo_doc { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string nombre { get; set; }

        public string celular { get; set; }

        [EmailAddress(ErrorMessage = "Debe ingresar un email valido")]
        public string email { get; set; }

        [RegularExpression("[FfMm]", ErrorMessage = "Solo puede ingresar F o M")]
        public string genero { get; set; }

        public string aprendiz { get; set; }

        public string egresado { get; set; }

        public string areaformacion { get; set; }

        public string fechaegresado { get; set; }

        public string direccion { get; set; }

        public string barrio { get; set; }

        public string ciudad { get; set; }

        public string departamento { get; set; }

        public string fecharegistro { get; set; }

    }
}