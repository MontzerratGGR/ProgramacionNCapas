using ML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet] //Mostrar el formulario
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = new List<object>();

            ML.Result result = BL.Usuario.GetAllLinQ();

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }

            return View(usuario);
        }

        [HttpGet] //Actualizar y Agregar FORMULARIO
        public ActionResult Form(int? IdUsuario, int? IdPais)
        {
            ML.Usuario usuario = new ML.Usuario();
            
            //INSTANCIAS PARA FORM DE DIRECCION
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            //GET PAISES PARA DDL
            ML.Result resultPais = BL.Pais.PaisGet();
            usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;

            //se agrega ADD

            //GET: Roles
            ML.Result resultRol = BL.Rol.GetAllLinQ();
            usuario.Rol = new ML.Rol();
            usuario.Rol.Rols = resultRol.Objects;

            if (IdUsuario == null)
            {
                return View(usuario);
                // usuario.Rol = new ML.Rol();

            }
            else //UPDATE USUARIO
            {
                ML.Result result = BL.Usuario.GetByIdLinQ((byte)IdUsuario);
                //UNBOXING
                usuario.IdUsuario = ((ML.Usuario)result.Object).IdUsuario;
                usuario.UserName = ((ML.Usuario)result.Object).UserName;
                usuario.Nombre = ((ML.Usuario)result.Object).Nombre;
                usuario.ApellidoPaterno = ((ML.Usuario)result.Object).ApellidoPaterno;
                usuario.ApellidoMaterno = ((ML.Usuario)result.Object).ApellidoMaterno;
                usuario.Email = ((ML.Usuario)result.Object).Email;
                usuario.Contrasenia = ((ML.Usuario)result.Object).Contrasenia;
                usuario.Sexo = ((ML.Usuario)result.Object).Sexo;
                usuario.Telefono = ((ML.Usuario)result.Object).Telefono;
                usuario.Celular = ((ML.Usuario)result.Object).Celular;
                usuario.FechaDeNacimiento = ((ML.Usuario)result.Object).FechaDeNacimiento;
                usuario.CURP = ((ML.Usuario)result.Object).CURP;
                usuario.Rol.IdRol = ((ML.Usuario)result.Object).Rol.IdRol;
                usuario.Imagen = ((ML.Usuario)result.Object).Imagen;
                usuario.Estatus = ((ML.Usuario)result.Object).Estatus;
                usuario.Direccion.IdDireccion = ((ML.Usuario)result.Object).Direccion.IdDireccion;
                usuario.Direccion.Calle = ((ML.Usuario)result.Object).Direccion.Calle;
                usuario.Direccion.NumeroInterior = ((ML.Usuario)result.Object).Direccion.NumeroInterior;
                usuario.Direccion.NumeroExterior = ((ML.Usuario)result.Object).Direccion.NumeroExterior;
                usuario.Direccion.Colonia.IdColonia = ((ML.Usuario)result.Object).Direccion.Colonia.IdColonia;
                usuario.Direccion.Colonia.Nombre = ((ML.Usuario)result.Object).Direccion.Colonia.Nombre;
                usuario.Direccion.Colonia.Municipio.IdMunicipio = ((ML.Usuario)result.Object).Direccion.Colonia.Municipio.IdMunicipio;
                usuario.Direccion.Colonia.Municipio.Nombre = ((ML.Usuario)result.Object).Direccion.Colonia.Municipio.Nombre;
                usuario.Direccion.Colonia.Municipio.Estado.IdEstado = ((ML.Usuario)result.Object).Direccion.Colonia.Municipio.Estado.IdEstado;
                usuario.Direccion.Colonia.Municipio.Estado.Nombre = ((ML.Usuario)result.Object).Direccion.Colonia.Municipio.Estado.Nombre;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = ((ML.Usuario)result.Object).Direccion.Colonia.Municipio.Estado.Pais.IdPais;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = ((ML.Usuario)result.Object).Direccion.Colonia.Municipio.Estado.Pais.Nombre;

                usuario = FillDropDownList(usuario);

                return View(usuario);
            }
        }

        public ActionResult UpdateEstatus(int? IdUsuario, bool Status)
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetByIdLinQ((int)IdUsuario);

            if (result.Correct)
            {
                usuario = ((ML.Usuario)result.Object);
                usuario.Estatus = Status ? false : true;

                ML.Result resulCambio = BL.Usuario.UpdateEF(usuario);
            }
           
            return View();

        }

        public JsonResult Update(int? IdUsuario, bool Status)
        {
            ML.Result result = new ML.Result();
            return Json(result.Objects);
        }
        public JsonResult EstadoGetByIdPais(int IdPais)
        {
            ML.Result result = BL.Estado.GetByIdPais(IdPais);
            return Json(result.Objects);
        }

        public JsonResult MunicipioGetEstado(int IdEstado)
        {
            ML.Result result = BL.Municipio.GetByIdEstado(IdEstado);
            return Json(result.Objects);
        }

        public JsonResult ColoniaGetByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = BL.Colonia.GetByIdMunicipio(IdMunicipio);
            return Json(result.Objects);
        }


        [HttpPost] //AGREGAR DATOS
        public ActionResult Form(ML.Usuario usuario, HttpPostedFileBase fuImagen, ML.Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                if (fuImagen != null) //IMAGEN
                {
                    usuario.Imagen = this.ConvertToBytes(fuImagen);
                }

                if (usuario.IdUsuario == 0) //Agregar DIRECCION
                {
                    ML.Result result = BL.Usuario.AddEF(usuario);

                    if (result.Correct)
                    {
                        ML.Result resultDireccion = BL.Direccion.Add(usuario.Direccion, (int)result.Object);
                        if (resultDireccion.Correct)
                        {
                            ViewBag.Mensaje = "Usuario agregado exitosamente";
                        }
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se ha ingresado correctamente el usuario. Error: " + result.ErrorMessage;
                    }
                }

                else //UPDATE
                {
                    ML.Result result = BL.Usuario.UpdateEF(usuario);

                    if (result.Correct)
                    {
                        ML.Result resultDireccion = BL.Direccion.DireccionUpdate(direccion, usuario);

                        if (resultDireccion.Correct)
                        {
                            ViewBag.Mensaje = "Se ha actualizado correctamente";
                        }

                    }
                    else
                    {
                        ViewBag.Mensaje = "No se ha podido actualizar correctamente. Error: " + result.ErrorMessage;
                    }
                }
                return PartialView("Modal");
            }

            usuario = FillDropDownList(usuario);
            return View(usuario);
        }



        private ML.Usuario FillDropDownList(ML.Usuario usuario) //LLENADO DE LISTA
        {
            ML.Result resultPaises = new ML.Result();
            resultPaises = BL.Pais.PaisGet();

            ML.Result resultEstados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
            ML.Result resultMunicipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
            ML.Result resultColonias = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);

            usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;
            usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;
            usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;
            usuario.Direccion.Colonia.Colonias = resultColonias.Objects;

            ML.Result resultRoles = BL.Rol.GetAllLinQ();
            usuario.Rol.Rols = resultRoles.Objects;

            return usuario;
        }


        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;

        }

        public ActionResult Delete(ML.Usuario usuario)
        {
            ML.Result resulDireccion = BL.Direccion.DireccionDeleteEF(usuario);

            if (resulDireccion.Correct)
            {
                ML.Result result = BL.Usuario.DeleteEF(usuario);
                if (result.Correct)
                {
                    ViewBag.Mesanje = "Se ha eliminado correctamente";

                }
                else
                {
                    ViewBag.Mensaje = "No se ha podido eliminar el usuario. Error:" + result.ErrorMessage;
                }

            }

            return PartialView("Modal");
        }




    }
}
