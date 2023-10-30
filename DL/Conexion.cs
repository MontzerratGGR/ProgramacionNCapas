using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion 
    { 
        public static string Get()
        {
            //CAMBIAR LA DIRECCION DE LA BD
            string conexion = "Data Source=.;Initial Catalog=MGonzalezProgramacionNCapas2;Integrated Security=True";
            return conexion;
        }
    }
}