using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        [Display(Name ="Nombre de Usuario")]
        [Required(ErrorMessage ="Este campo es obligatorio")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; }


        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string ApellidoPaterno { get; set; }


        [Display(Name ="Apellido Materno")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Email { get; set; }


        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Contrasenia { get; set; }


        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Sexo { get; set; }


        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(10)]
        [MinLength(10)]
        public string Telefono { get; set; }



        [MaxLength(10)]
        [MinLength(10)]
        public string Celular { get; set; }


        [Display(Name ="Fecha de Nacimiento")]
        public string FechaDeNacimiento { get; set; }


        [MaxLength(18)]
        [MinLength(18)]
        public string CURP { get; set; }
        public byte[] Imagen { get; set; }

        public bool Estatus  {get; set; }

        public ML.Rol Rol { get; set; }

        public ML.Direccion Direccion {get; set;}

        public List<object> Usuarios { get; set; } 

    }

    
}
