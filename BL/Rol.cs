using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAllLinQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MGonzalezProgramacionNCapas2Entities context = new DL_EF.MGonzalezProgramacionNCapas2Entities())

                {
                    var query = (from usarioGetAll in context.Rols
                                 select usarioGetAll).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var objRol in query)
                        {
                            ML.Rol rol = new ML.Rol();
                            rol.IdRol = objRol.IdRol;
                            rol.Nombre = objRol.Nombre;

                             // usuario.IdUsuario = objUsuario.Rol.IdRol;

                            result.Objects.Add(rol);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros para mostrar";

                    }
                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;

            }

            return result;
        }

    }
}
