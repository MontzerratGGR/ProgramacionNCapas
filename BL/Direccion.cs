using DL_EF;
using ML;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Direccion
    {
        public static ML.Result Add(ML.Direccion direccion, int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MGonzalezProgramacionNCapas2Entities context = new DL_EF.MGonzalezProgramacionNCapas2Entities())
                {
                   var resultQuery = context.DireccionAdd(direccion.Calle, direccion.NumeroInterior, direccion.NumeroExterior, direccion.Colonia.IdColonia, IdUsuario);

                    if (resultQuery > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo aregar al usuario nuevo";
                    }
                }

            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }

            return result;
        }
        public static ML.Result DireccionGetByUsuario(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MGonzalezProgramacionNCapas2Entities context = new DL_EF.MGonzalezProgramacionNCapas2Entities())
                {
                    var resultQuery = context.DireccionGetByUsuario(IdUsuario).ToList();
                    result.Objects = new List<object>();

                    if (resultQuery != null)
                    {
                        foreach (var obj in resultQuery)
                        {
                            ML.Direccion direccion = new ML.Direccion();
                            direccion.IdDireccion = direccion.IdDireccion;
                            direccion.Calle = direccion.Calle;
                            direccion.NumeroInterior = direccion.NumeroInterior;
                            direccion.NumeroExterior = direccion.NumeroExterior;
                            direccion.Colonia = direccion.Colonia;
                            //direccion.IdUsuario = direccion.IdUsuario;

                            result.Objects.Add(direccion);
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

        public static ML.Result DireccionUpdate(ML.Direccion direccion, ML.Usuario usuario) 
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MGonzalezProgramacionNCapas2Entities context = new DL_EF.MGonzalezProgramacionNCapas2Entities())
                {
                    //ObjectParameter DireccionUpdate = new ObjectParameter("IdUsuario", typeof(int));

                    var updateResult = context.DireccionUpdate(usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, 
                        usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia, usuario.IdUsuario);
                    if (updateResult >= 1)
                    {
                        result.Correct = true;
                        //result.Object = Convert.ToInt32(DireccionUpdate.Value);

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar la direccion";
                    }

                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
                return result;
        
        }

        public static ML.Result DireccionDeleteEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MGonzalezProgramacionNCapas2Entities context = new DL_EF.MGonzalezProgramacionNCapas2Entities())
                {
                    var query = context.DireccionDelete(usuario.IdUsuario);
                    if (query >= 1)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar la dirección";
                    }

                    result.Correct = true;
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
