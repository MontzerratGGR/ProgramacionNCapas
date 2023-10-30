using DL_EF;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {

        //public static ML.Result Add(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
        //        {

        //            SqlCommand cmd = new SqlCommand();
        //            cmd.Connection = conn;
        //            cmd.CommandText = "UsuarioAdd";
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
        //            cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
        //            cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
        //            cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
        //            cmd.Parameters.AddWithValue("@Email", usuario.Email);
        //            cmd.Parameters.AddWithValue("@Contrasenia", usuario.Contrasenia);
        //            cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
        //            cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
        //            cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
        //            cmd.Parameters.AddWithValue("@FechaDeNacimiento", usuario.FechaDeNacimiento);
        //            cmd.Parameters.AddWithValue("@CURP", usuario.CURP);
        //            // cmd.Parameters.AddWithValue("@Imagen", usuario.Imagen);
        //            cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);

        //            conn.Open();

        //            int rowsAffected = cmd.ExecuteNonQuery();

        //            if (rowsAffected > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Ocurrio un error al insertar el usuario " + usuario.Nombre;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }

        //    return result;
        //}

        ////__________________________________________________________________________
        //public static ML.Result Update(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))

        //        {
        //            SqlCommand cmd = new SqlCommand();
        //            cmd.Connection = conn;
        //            cmd.CommandText = "UsuarioUpdate";
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
        //            cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
        //            cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
        //            cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
        //            cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
        //            cmd.Parameters.AddWithValue("@Email", usuario.Email);
        //            cmd.Parameters.AddWithValue("@Contrasenia", usuario.Contrasenia);
        //            cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
        //            cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
        //            cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
        //            cmd.Parameters.AddWithValue("@FechaDeNacimiento", usuario.FechaDeNacimiento);
        //            cmd.Parameters.AddWithValue("@CURP", usuario.CURP);
        //            // cmd.Parameters.AddWithValue("@Imagen", usuario.Imagen);
        //            cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);

        //            conn.Open();

        //            int rowsAffected = cmd.ExecuteNonQuery();

        //            if (rowsAffected > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Ocurrio un error al actualizar el usuario " + usuario.IdUsuario;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }

        //    return result;
        //}
        ////__________________________________________________________________________

        //public static ML.Result Delete(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            SqlCommand cmd = new SqlCommand();
        //            cmd.Connection = conn;
        //            cmd.CommandText = "UsuarioDelete";
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);

        //            cmd.Connection.Open();

        //            int rowsAffected = cmd.ExecuteNonQuery();

        //            if (rowsAffected > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Ocurrio un error al Eliminar el usuario " + usuario.IdUsuario;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }

        //    return result;
        //}



        //public static ML.Result GetAll()
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            SqlCommand cmd = new SqlCommand();
        //            cmd.Connection = conn;
        //            cmd.CommandText = "UsuarioGetAll";
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataTable tablaUsuario = new DataTable();

        //            da.Fill(tablaUsuario);

        //            if (tablaUsuario.Rows.Count > 0)
        //            {
        //                result.Objects = new List<object>();

        //                foreach (DataRow row in tablaUsuario.Rows)
        //                {
        //                    ML.Usuario usuario = new ML.Usuario();

        //                    usuario.IdUsuario = int.Parse(row[0].ToString());
        //                    usuario.UserName = row[1].ToString();
        //                    usuario.Nombre = row[2].ToString();
        //                    usuario.ApellidoPaterno = row[3].ToString();
        //                    usuario.ApellidoMaterno = row[4].ToString();
        //                    usuario.Email = row[5].ToString();
        //                    usuario.Contrasenia = row[6].ToString();
        //                    usuario.Sexo = row[7].ToString();
        //                    usuario.Telefono = row[8].ToString();
        //                    usuario.Celular = row[9].ToString();
        //                    usuario.FechaDeNacimiento = DateTime.Parse(row[10].ToString());
        //                    usuario.CURP = row[11].ToString();

        //                    usuario.Rol = new ML.Rol();
        //                    usuario.Rol.IdRol = int.Parse(row[12].ToString());
        //                    //  Console.WriteLine();
        //                    result.Objects.Add(usuario);
        //                    result.Correct = true;

        //                }
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "La tabla no tiene datos";
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //        result.Correct = false;

        //    }
        //    return result;
        //}
        ////-------------------------------------------------------------------------------------------
        //public static ML.Result GetById(int IdUsuario)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            SqlCommand cmd = new SqlCommand();
        //            cmd.Connection = context;
        //            cmd.CommandText = "UsuarioGetById";
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
        //            // cmd.Connection = context;

        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataTable tablaUsuario = new DataTable();

        //            da.Fill(tablaUsuario);

        //            if (tablaUsuario.Rows.Count > 0)
        //            {
        //                DataRow row = tablaUsuario.Rows[0];
        //                ML.Usuario usuario = new ML.Usuario();

        //                usuario.IdUsuario = int.Parse(row[0].ToString());
        //                usuario.UserName = row[1].ToString();
        //                usuario.Nombre = row[2].ToString();
        //                usuario.ApellidoPaterno = row[3].ToString();
        //                usuario.ApellidoMaterno = row[4].ToString();
        //                usuario.Email = row[5].ToString();
        //                usuario.Contrasenia = row[6].ToString();
        //                usuario.Sexo = row[7].ToString();
        //                usuario.Telefono = row[8].ToString();
        //                usuario.Celular = row[9].ToString();
        //                usuario.FechaDeNacimiento = DateTime.Parse(row[10].ToString());
        //                usuario.CURP = row[11].ToString();
        //                //usuario.Imagen = row[10].ToString();
        //                usuario.Rol = new ML.Rol();
        //                usuario.Rol.IdRol = int.Parse(row[12].ToString());


        //                result.Object = usuario;
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "- La Tabla no tiene informacion para mostrar -";

        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //        result.Correct = false;
        //    }

        //    return result;
        //}
        //------------------------FIN--------------------------------------


        //----------------------------ENTITY FRAMEWORK-----------------------------------------------

        //---USUARIO ADD
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MGonzalezProgramacionNCapas2Entities context = new DL_EF.MGonzalezProgramacionNCapas2Entities())
                {
                    ObjectParameter DireccionIdUsuario = new ObjectParameter("IdUsuario", typeof(int));

                    var resultQuery = context.UsuarioAdd(usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno,
                        usuario.ApellidoMaterno, usuario.Email, usuario.Contrasenia, usuario.Sexo, usuario.Telefono,
                        usuario.Celular, usuario.FechaDeNacimiento, usuario.CURP, usuario.Rol.IdRol, usuario.Imagen, DireccionIdUsuario);

                    if (resultQuery > 0)
                    {
                        result.Correct = true;
                        result.Object = Convert.ToInt32(DireccionIdUsuario.Value);
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

        //--- USUARIO UPDATE
        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MGonzalezProgramacionNCapas2Entities context = new DL_EF.MGonzalezProgramacionNCapas2Entities())
                {
                    ObjectParameter DireccionIdUsuario = new ObjectParameter("IdUsuario", typeof(int));

                    var updateResult = context.UsuarioUpdate(usuario.IdUsuario, usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno,
                        usuario.ApellidoMaterno, usuario.Email, usuario.Contrasenia, usuario.Sexo, usuario.Telefono,
                        usuario.Celular, usuario.FechaDeNacimiento, usuario.CURP, usuario.Rol.IdRol, usuario.Imagen, usuario.Estatus);

                    if (updateResult >= 1)
                    {
                        result.Correct = true;
                        result.Object = Convert.ToInt32(DireccionIdUsuario.Value);

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar al usuario";
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

        //---USUARIO DELETE
        public static ML.Result DeleteEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MGonzalezProgramacionNCapas2Entities context = new DL_EF.MGonzalezProgramacionNCapas2Entities())
                {
                    var query = context.UsuarioDelete(usuario.IdUsuario);
                    if (query >= 1)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar el usuario";
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

        //--USUARIO GETALL

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MGonzalezProgramacionNCapas2Entities context = new DL_EF.MGonzalezProgramacionNCapas2Entities())
                {
                    var resultQuery = context.UsuarioGetAll().ToList();
                    result.Objects = new List<object>();

                    if (resultQuery != null)
                    {
                        foreach (var obj in resultQuery)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.UserName = obj.UserName;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.Email = obj.Email;
                            usuario.Contrasenia = obj.Contrasenia;
                            usuario.Sexo = obj.Sexo;
                            usuario.Telefono = obj.Telefono;
                            usuario.Celular = obj.Celular;
                            usuario.FechaDeNacimiento = obj.FechaDeNacimiento.Value.ToString("dd-MM-yyyy");
                            usuario.CURP = obj.CURP;
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = obj.IdRol.Value;
                            //usuario.Rol = new ML.Rol();
                            //usuario.Rol.Nombre = (obj.Rol.Nombre != null) ? obj.Rol.Nombre : ("Sin Rol"); //Mostrar el nombre de rol
                            usuario.Imagen = obj.Imagen;
                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.Calle = obj.Calle;
                            usuario.Direccion.NumeroInterior = obj.NumeroInterior;
                            usuario.Direccion.NumeroExterior = obj.NumeroExterior;
                            usuario.Direccion.Colonia.Nombre = obj.Nombre;
                            usuario.Direccion.Colonia.Municipio.Nombre = obj.Nombre;
                            usuario.Direccion.Colonia.Municipio.Estado.Nombre = obj.Nombre;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = obj.Nombre;

                            result.Objects.Add(usuario);
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


        //---USUARIO GETBYID

        public static ML.Result GetByIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MGonzalezProgramacionNCapas2Entities context = new DL_EF.MGonzalezProgramacionNCapas2Entities())
                {
                    var objGetById = context.UsuarioGetById(IdUsuario).FirstOrDefault();
                    result.Objects = new List<object>();

                    if (objGetById != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = objGetById.IdUsuario;
                        usuario.UserName = objGetById.UserName;
                        usuario.Nombre = objGetById.Nombre;
                        usuario.ApellidoPaterno = objGetById.ApellidoPaterno;
                        usuario.ApellidoMaterno = objGetById.ApellidoMaterno;
                        usuario.Email = objGetById.Email;
                        usuario.Contrasenia = objGetById.Contrasenia;
                        usuario.Sexo = objGetById.Sexo;
                        usuario.Telefono = objGetById.Telefono;
                        usuario.Celular = objGetById.Celular;
                        usuario.FechaDeNacimiento = objGetById.FechaDeNacimiento.Value.ToString("dd-MM-yyyy");
                        usuario.CURP = objGetById.CURP;
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = objGetById.IdRol.Value;
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




        //---------------------------- LINQ -----------------------------------

        //--ADD
        public static ML.Result AddLinQ(ML.Usuario usuario)
        {
            Result result = new Result();
            try
            {
                using (MGonzalezProgramacionNCapas2Entities context = new MGonzalezProgramacionNCapas2Entities())
                {
                    DL_EF.Usuario usuarioDL = new DL_EF.Usuario();

                    usuarioDL.UserName = usuario.UserName;
                    usuarioDL.Nombre = usuario.Nombre;
                    usuarioDL.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioDL.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioDL.Email = usuario.Email;
                    usuarioDL.Contrasenia = usuario.Contrasenia;
                    usuarioDL.Sexo = usuario.Sexo;
                    usuarioDL.Telefono = usuario.Telefono;
                    usuarioDL.Celular = usuario.Celular;
                    // usuarioDL.FechaDeNacimiento = usuario.FechaDeNacimiento.Value.ToString("dd-MM-yyyy");
                    usuarioDL.CURP = usuario.CURP;
                    //usuarioDL.Rol = new DL_EF.Rol();
                    //Aquí va la imagen
                    usuarioDL.IdRol = usuario.Rol.IdRol;
                    usuarioDL.Imagen = usuario.Imagen;

                    context.Usuarios.Add(usuarioDL);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Error.Add(ex);

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }

        //--UPDATE

        public static Result UpdateLinQ(ML.Usuario usuario)
        {
            Result result = new Result();
            try
            {
                using (MGonzalezProgramacionNCapas2Entities context = new MGonzalezProgramacionNCapas2Entities())
                {
                    var query = (from usuarioUpdate in context.Usuarios
                                 where usuarioUpdate.IdUsuario == usuario.IdUsuario
                                 select usuarioUpdate).SingleOrDefault();

                    if (query != null)
                    {
                        query.UserName = usuario.UserName;
                        query.Nombre = usuario.Nombre;
                        query.ApellidoPaterno = usuario.ApellidoPaterno;
                        query.ApellidoMaterno = usuario.ApellidoMaterno;
                        query.Email = usuario.Email;
                        query.Contrasenia = usuario.Contrasenia;
                        query.Sexo = usuario.Sexo;
                        query.Telefono = usuario.Telefono;
                        query.Celular = usuario.Celular;
                        //query.FechaDeNacimiento = usuario.FechaDeNacimiento.Value.ToString("dd-MM-yyyy");
                        query.CURP = usuario.CURP;
                        query.IdRol = usuario.Rol.IdRol;
                        query.Imagen = usuario.Imagen;

                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar el usuario" + usuario.IdUsuario;
                    }
                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;

            }
            return result;
        }


        //-DELETE   

        public static Result DeleteLinQ(ML.Usuario usuario)
        {

            Result result = new Result();

            try
            {
                using (MGonzalezProgramacionNCapas2Entities context = new MGonzalezProgramacionNCapas2Entities())

                {
                    var query = (from usuarioDelete in context.Usuarios
                                 where usuarioDelete.IdUsuario == usuario.IdUsuario
                                 select usuarioDelete).First();

                    context.Usuarios.Remove(query);
                    context.SaveChanges();

                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "No se pudo eliminar el usuario";
                result.ErrorMessage = e.Message;

            }
            return result;
        }


        // --GETALL

        public static ML.Result GetAllLinQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MGonzalezProgramacionNCapas2Entities context = new DL_EF.MGonzalezProgramacionNCapas2Entities())

                {
                    var query = (from usarioGetAll in context.Usuarios
                                 join rol in context.Rols on usarioGetAll.IdRol equals rol.IdRol


                                 select new { usarioGetAll, rol.Nombre }).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var objUsuario in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = objUsuario.usarioGetAll.IdUsuario;
                            usuario.UserName = objUsuario.usarioGetAll.UserName;
                            usuario.Nombre = objUsuario.usarioGetAll.Nombre;
                            usuario.ApellidoPaterno = objUsuario.usarioGetAll.ApellidoPaterno;
                            usuario.ApellidoMaterno = objUsuario.usarioGetAll.ApellidoMaterno;
                            usuario.Email = objUsuario.usarioGetAll.Email;
                            usuario.Contrasenia = objUsuario.usarioGetAll.Contrasenia;
                            usuario.Sexo = objUsuario.usarioGetAll.Sexo;
                            usuario.Telefono = objUsuario.usarioGetAll.Telefono;
                            usuario.Celular = objUsuario.usarioGetAll.Celular;
                            usuario.FechaDeNacimiento = objUsuario.usarioGetAll.FechaDeNacimiento.Value.ToString("dd-MM-yyyy");
                            usuario.CURP = objUsuario.usarioGetAll.CURP;
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.Nombre = (objUsuario.usarioGetAll.Rol.Nombre != null) ? objUsuario.usarioGetAll.Rol.Nombre : ("Sin Rol"); //Mostrar el nombre de rol
                            usuario.Imagen = objUsuario.usarioGetAll.Imagen;
                            usuario.Estatus = (bool)objUsuario.usarioGetAll.Estatus;
                            // usuario.Rol.IdRol = (objUsuario.usarioGetAll.Rol.IdRol != null) ? int.Parse(objUsuario.usarioGetAll.Nombre) : int.Parse("0"); mostrar el ID en Rol
                            // usuario.IdUsuario = objUsuario.Rol.IdRol;

                            result.Objects.Add(usuario);
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


        //--GetById
        public static ML.Result GetByIdLinQ(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MGonzalezProgramacionNCapas2Entities context = new DL_EF.MGonzalezProgramacionNCapas2Entities())
                {
                    var objById = (from usuario in context.Usuarios

                                   join direccion in context.Direccions
                                   on usuario.IdUsuario equals direccion.IdUsuario

                                   join colonia in context.Colonias
                                   on direccion.IdColonia equals colonia.IdColonia

                                   join municipio in context.Municipios
                                   on colonia.IdMunicipio equals municipio.IdMunicipio

                                   join estado in context.Estadoes
                                   on municipio.IdEstado equals estado.IdEstado

                                   join pais in context.Pais
                                   on estado.IdPais equals pais.IdPais

                                   where usuario.IdUsuario == IdUsuario
                                   select new
                                   {
                                       IdUsuario = usuario.IdUsuario,
                                       UserName = usuario.UserName,
                                       UsuarioNombre = usuario.Nombre,
                                       ApellidoPaterno = usuario.ApellidoPaterno,
                                       ApellidoMaterno = usuario.ApellidoMaterno,
                                       Email = usuario.Email,
                                       Contrasenia = usuario.Contrasenia,
                                       Sexo = usuario.Sexo,
                                       Telefono = usuario.Telefono,
                                       Celular = usuario.Celular,
                                       FechaDeNacimiento = usuario.FechaDeNacimiento,
                                       CURP = usuario.CURP,
                                       IdRol = usuario.IdRol,
                                       Imagen = usuario.Imagen,
                                       Estatus = usuario.Estatus,

                                       IdDireccion = direccion.IdDireccion,
                                       Calle = direccion.Calle,
                                       NumeroInterior = direccion.NumeroInterior,
                                       NumeroExterior = direccion.NumeroExterior,
                                       IdColonia = colonia.IdColonia,
                                       ColoniaNombre = colonia.Nombre,
                                       IdMunicipio = municipio.IdMunicipio,
                                       NombreMunicipio = municipio.Nombre,
                                       IdEstado = estado.IdEstado,
                                       NombreEstado = estado.Nombre,
                                       IdPais = pais.IdPais,
                                       NombrePais = pais.Nombre

                                   }).First();

                    result.Objects = new List<object>();

                    if (objById != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = objById.IdUsuario;
                        usuario.UserName = objById.UserName;
                        usuario.Nombre = objById.UsuarioNombre;
                        usuario.ApellidoPaterno = objById.ApellidoPaterno;
                        usuario.ApellidoMaterno = objById.ApellidoMaterno;
                        usuario.Email = objById.Email;
                        usuario.Contrasenia = objById.Contrasenia;
                        usuario.Sexo = objById.Sexo;
                        usuario.Telefono = objById.Telefono;
                        usuario.Celular = objById.Celular;
                        usuario.FechaDeNacimiento = objById.FechaDeNacimiento.Value.ToString("dd-MM-yyyy");
                        usuario.CURP = objById.CURP;
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = objById.IdRol.Value;
                        usuario.Imagen = objById.Imagen;
                        usuario.Estatus = (bool)objById.Estatus;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.Calle = objById.Calle;
                        usuario.Direccion.NumeroInterior = objById.NumeroInterior;
                        usuario.Direccion.NumeroExterior = objById.NumeroExterior;

                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = objById.IdColonia;
                        usuario.Direccion.Colonia.Nombre = objById.ColoniaNombre;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = objById.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.Nombre = objById.NombreMunicipio;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = objById.IdEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = objById.NombreEstado;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = objById.IdPais;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = objById.NombrePais;

                        result.Objects.Add(usuario);
                        result.Object = usuario;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct &= false;
                        result.ErrorMessage = "No se encontraron datos que mostrar";
                    }

                    try
                    {
                        ML.Result resultDireccion = new ML.Result();

                        try
                        {
                            using (DL_EF.MGonzalezProgramacionNCapas2Entities con = new DL_EF.MGonzalezProgramacionNCapas2Entities())
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
                    }
                    catch (Exception e)
                    {
                        result.Correct = false;
                        result.ErrorMessage = e.Message;
                        result.Ex = e;
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
    }

}


