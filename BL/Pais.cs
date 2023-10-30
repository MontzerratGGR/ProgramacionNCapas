using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        public static ML.Result PaisGet()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MGonzalezProgramacionNCapas2Entities context = new DL_EF.MGonzalezProgramacionNCapas2Entities())
                {
                    var resultQuery = context.PaisGetAll().ToList();
                    result.Objects = new List<object>();

                    if (resultQuery != null)
                    {
                        foreach (var obj in resultQuery)
                        {
                            ML.Pais pais = new ML.Pais();
                            pais.IdPais = obj.IdPais;
                            pais.Nombre = obj.Nombre;

                            result.Objects.Add(pais);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;

            }
            return result;
        }

    }

}
