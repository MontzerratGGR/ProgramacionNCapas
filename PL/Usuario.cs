using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
//    public class Usuario
//    {
//        public static void Menu()
//        {
//            Console.Clear();

//            Console.WriteLine("--- MENU ---");
//            Console.WriteLine("\n Elija la opcion a la que quiere acceder: ");
//            Console.WriteLine("\n1.- Agregar Usuarios a la Base de Datos.");
//            Console.WriteLine("2.- Editar Usuarios de la Base de Datos.");
//            Console.WriteLine("3.- Eliminar Usuarios de la Base de Datos");
//            Console.WriteLine("4.- Ver la Base de Datos completa");
//            Console.WriteLine("5.- Consultar un Registro de la Base de Datos");
//            Console.WriteLine("6.- Salir\n\n");
//            int acceder = 0;
//            do
//            {
//                acceder = int.Parse(Console.ReadLine());

//                switch (acceder)
//                {
//                    case 1:
//                        Console.WriteLine("\n-- Agregar Usuario Nuevo --\n");
//                        AddLinQ();

//                        break;

//                    case 2:
//                        Console.WriteLine("\n-- Editar Datos --\n");
//                        UpdateLinQ();
//                        break;

//                    case 3:
//                        Console.WriteLine("\n-- Eliminar Usuario --\n");
//                        DeleteLinQ();
//                        break;

//                    case 4:
//                        Console.WriteLine("\n-- Tabla Usuario --\n");
//                        GetAllLinQ();
//                        break;

//                    case 5:
//                        Console.WriteLine("\n-- Ver Registro Unico --\n");
//                        GetByIdLinQ();
//                        break;
//                    case 6:
//                        Console.WriteLine("\n-- Salir --\n");
//                        Environment.Exit(0);
//                        break;

//                    default:
//                        Console.WriteLine("--No seleccionó una opcion valida--\n");
//                        break;
//                }
//                Console.ReadKey();

//            } while (acceder != 6);

//        }

//        //_________________________________________________________________________
//        //--ADD
//        //public static void Add()
//        //{
//        //    ML.Usuario usuario = new ML.Usuario();


//        //    Console.WriteLine("Ingrese el nombre de usuario: ");
//        //    usuario.UserName = Console.ReadLine();

//        //    Console.WriteLine("Nombre real: ");
//        //    usuario.Nombre = Console.ReadLine();

//        //    Console.WriteLine("Apellido Paterno: ");
//        //    usuario.ApellidoPaterno = Console.ReadLine();

//        //    Console.WriteLine("Apellido Materno: ");
//        //    usuario.ApellidoMaterno = Console.ReadLine();

//        //    Console.WriteLine("Email: ");
//        //    usuario.Email = Console.ReadLine();

//        //    Console.WriteLine("Ingrese una Contraseña: ");
//        //    usuario.Contrasenia = Console.ReadLine();

//        //    Console.WriteLine("Sexo (H - M): ");
//        //    usuario.Sexo = Console.ReadLine();

//        //    Console.WriteLine("Telefono: ");
//        //    usuario.Telefono = Console.ReadLine();

//        //    Console.WriteLine("Celular: ");
//        //    usuario.Celular = Console.ReadLine();

//        //    Console.WriteLine("Fecha de Nacimiento (Año-Mes-Día): ");
//        //    usuario.FechaDeNacimiento = DateTime.Parse(Console.ReadLine());

//        //    Console.WriteLine("CURP: ");
//        //    usuario.CURP = Console.ReadLine();

//        //    //Console.WriteLine("Cargar Imagen: ");
//        //    //usuario.Imagen = Console.ReadLine();

//        //    Console.WriteLine("Id Rol: ");
//        //    usuario.Rol = new ML.Rol();
//        //    usuario.Rol.IdRol = int.Parse(Console.ReadLine());


//        //    ML.Result result = BL.Usuario.Add(usuario);

//        //    if (result.Correct)
//        //    {
//        //        Console.WriteLine("El usuario se Agregó correctamente");
//        //    }
//        //    else
//        //    {
//        //        Console.WriteLine("Ocurrio un error al Agregar al usuario" + result.ErrorMessage);
//        //        Console.WriteLine(result.Ex);
//        //    }
//        //    Console.ReadKey();
            
//        //}


//        ////__________________________________________________________________________

//        //public static void Update()
//        //{
//        //    ML.Usuario usuario = new ML.Usuario();

//        //    Console.WriteLine("----- ACTUALIZAR DATOS -----\n\n");

//        //    Console.WriteLine("Ingrese el ID del usuario que desea Actualizar:");
//        //    usuario.IdUsuario = int.Parse(Console.ReadLine());

//        //    Console.WriteLine("Ingrese el nombre de usuario: ");
//        //    usuario.UserName = Console.ReadLine();

//        //    Console.WriteLine("Nombre real: ");
//        //    usuario.Nombre = Console.ReadLine();

//        //    Console.WriteLine("Apellido Paterno: ");
//        //    usuario.ApellidoPaterno = Console.ReadLine();

//        //    Console.WriteLine("Apellido Materno: ");
//        //    usuario.ApellidoMaterno = Console.ReadLine();

//        //    Console.WriteLine("Email: ");
//        //    usuario.Email = Console.ReadLine();

//        //    Console.WriteLine("Ingrese una Contraseña: ");
//        //    usuario.Contrasenia = Console.ReadLine();

//        //    Console.WriteLine("Sexo (H - M): ");
//        //    usuario.Sexo = Console.ReadLine();

//        //    Console.WriteLine("Telefono: ");
//        //    usuario.Telefono = Console.ReadLine();

//        //    Console.WriteLine("Celular: ");
//        //    usuario.Celular = Console.ReadLine();

//        //    Console.WriteLine("Fecha de Nacimiento (Año-Mes-Día): ");
//        //    usuario.FechaDeNacimiento = DateTime.Parse(Console.ReadLine());

//        //    Console.WriteLine("CURP: ");
//        //    usuario.CURP = Console.ReadLine();

//        //    //Console.WriteLine("Cargar Imagen: ");
//        //    //usuario.Imagen = Console.ReadLine();

//        //    Console.WriteLine("Id Rol: ");
//        //    usuario.Rol = new ML.Rol();
//        //    usuario.Rol.IdRol = int.Parse(Console.ReadLine());
//        //    ML.Result result = BL.Usuario.Update(usuario);

//        //    if (result.Correct)
//        //    {
//        //        Console.WriteLine("El usuario se actualizó correctamente");
//        //    }
//        //    else
//        //    {
//        //        Console.WriteLine("Ocurrio un error al actualizar al usuario" + result.ErrorMessage);
//        //        Console.WriteLine(result.Ex);

//        //    }
//        //    Console.ReadKey();
//        //}


//        ////__________________________________________________________________________

//        //public static void Delete()

//        //{
//        //    ML.Usuario usuario = new ML.Usuario();

//        //    Console.WriteLine("Ingrese el ID del usuario que desea eliminar:");
//        //    usuario.IdUsuario = int.Parse(Console.ReadLine());


//        //    ML.Result result = BL.Usuario.Delete(usuario);

//        //    if (result.Correct)
//        //    {
//        //        Console.WriteLine("El usuario se eliminó correctamente");
//        //    }
//        //    else
//        //    {
//        //        Console.WriteLine("Ocurrio un error al eliminar al usuario" + result.ErrorMessage);
//        //        Console.WriteLine(result.Ex);
//        //    }

//        //    Console.ReadKey();
//        //}


//        ////---------------------------------------------------------------------------

//        //public static void GetAll()
//        //{
//        //    ML.Result result = BL.Usuario.GetAll();

//        //    if (result.Correct)
//        //    {
//        //        foreach (ML.Usuario usuario in result.Objects)
//        //        {
//        //            Console.WriteLine(usuario.IdUsuario);
//        //            Console.WriteLine(usuario.UserName);
//        //            Console.WriteLine(usuario.Nombre);
//        //            Console.WriteLine(usuario.ApellidoPaterno);
//        //            Console.WriteLine(usuario.ApellidoMaterno);
//        //            Console.WriteLine(usuario.Email);
//        //            Console.WriteLine(usuario.Contrasenia);
//        //            Console.WriteLine(usuario.Sexo);
//        //            Console.WriteLine(usuario.Telefono);
//        //            Console.WriteLine(usuario.Celular);
//        //            Console.WriteLine(usuario.FechaDeNacimiento);
//        //            Console.WriteLine(usuario.CURP);
//        //            //Console.WriteLine(usuario.Imagen);
//        //            Console.WriteLine(usuario.Rol.IdRol);
//        //        }
//        //    }
//        //    else
//        //    {
//        //        Console.WriteLine("No se encontraron registros " + result.ErrorMessage);
//        //    }
//        //    Console.ReadKey();
//        //}

//        ////---------------------------------------------------------------------------

//        //public static void GetById()
//        //{
//        //    ML.Usuario usuario = new ML.Usuario();


//        //    Console.WriteLine("Ingrese el Id del usuario que desea ver: ");
//        //    usuario.IdUsuario = int.Parse(Console.ReadLine());

//        //    ML.Result result = BL.Usuario.GetById(usuario.IdUsuario);

//        //    if (result.Correct)
//        //    {
//        //        usuario = (ML.Usuario)result.Object;
//        //        Console.WriteLine(usuario.IdUsuario);
//        //        Console.WriteLine(usuario.UserName);
//        //        Console.WriteLine(usuario.Nombre);
//        //        Console.WriteLine(usuario.ApellidoPaterno);
//        //        Console.WriteLine(usuario.ApellidoMaterno);
//        //        Console.WriteLine(usuario.Email);
//        //        Console.WriteLine(usuario.Contrasenia);
//        //        Console.WriteLine(usuario.Sexo);
//        //        Console.WriteLine(usuario.Telefono);
//        //        Console.WriteLine(usuario.Celular);
//        //        Console.WriteLine(usuario.FechaDeNacimiento);
//        //        Console.WriteLine(usuario.CURP);
//        //        //Console.WriteLine(usuario.Imagen);
//        //        Console.WriteLine(usuario.Rol.IdRol);

//        //    }
//        //    else
//        //    {
//        //        Console.WriteLine("No se encontraron registros " + result.ErrorMessage);
//        //    }

//        //    Console.ReadKey();
//        //}


//        //------------------------------------------ENTITY FRAMEWORK---------------------------------------------------------
//   //---ADD
       
       
//        public static void AddEF()
//        {
//            ML.Usuario usuario = new ML.Usuario();


//            Console.WriteLine("Ingrese el nombre de usuario: ");
//            usuario.UserName = Console.ReadLine();

//            Console.WriteLine("Nombre real: ");
//            usuario.Nombre = Console.ReadLine();

//            Console.WriteLine("Apellido Paterno: ");
//            usuario.ApellidoPaterno = Console.ReadLine();

//            Console.WriteLine("Apellido Materno: ");
//            usuario.ApellidoMaterno = Console.ReadLine();

//            Console.WriteLine("Email: ");
//            usuario.Email = Console.ReadLine();

//            Console.WriteLine("Ingrese una Contraseña: ");
//            usuario.Contrasenia = Console.ReadLine();

//            Console.WriteLine("Sexo (H - M): ");
//            usuario.Sexo = Console.ReadLine();

//            Console.WriteLine("Telefono: ");
//            usuario.Telefono = Console.ReadLine();

//            Console.WriteLine("Celular: ");
//            usuario.Celular = Console.ReadLine();

//            Console.WriteLine("Fecha de Nacimiento (Año-Mes-Día): ");
//            usuario.FechaDeNacimiento = DateTime.Parse(Console.ReadLine());

//            Console.WriteLine("CURP: ");
//            usuario.CURP = Console.ReadLine();

//            //Console.WriteLine("Cargar Imagen: ");
//            //usuario.Imagen = Console.ReadLine();

//            Console.WriteLine("Id Rol: ");
//            usuario.Rol = new ML.Rol();
//            usuario.Rol.IdRol = int.Parse(Console.ReadLine());


//            ML.Result result = BL.Usuario.Add(usuario);

//            if (result.Correct)
//            {
//                Console.WriteLine("El usuario se Agregó correctamente");
//            }
//            else
//            {
//                Console.WriteLine("Ocurrio un error al Agregar al usuario" + result.ErrorMessage);
//                Console.WriteLine(result.Ex);
//            }
//            Console.ReadKey();

//        }


//  //---UPDATE

//        public static void UpdateEF()
//        {
//            ML.Usuario usuario = new ML.Usuario();

//            Console.WriteLine("----- ACTUALIZAR DATOS -----\n\n");

//            Console.WriteLine("Ingrese el ID del usuario que desea Actualizar:");
//            usuario.IdUsuario = int.Parse(Console.ReadLine());

//            Console.WriteLine("Ingrese el nombre de usuario: ");
//            usuario.UserName = Console.ReadLine();

//            Console.WriteLine("Nombre real: ");
//            usuario.Nombre = Console.ReadLine();

//            Console.WriteLine("Apellido Paterno: ");
//            usuario.ApellidoPaterno = Console.ReadLine();

//            Console.WriteLine("Apellido Materno: ");
//            usuario.ApellidoMaterno = Console.ReadLine();

//            Console.WriteLine("Email: ");
//            usuario.Email = Console.ReadLine();

//            Console.WriteLine("Ingrese una Contraseña: ");
//            usuario.Contrasenia = Console.ReadLine();

//            Console.WriteLine("Sexo (H - M): ");
//            usuario.Sexo = Console.ReadLine();

//            Console.WriteLine("Telefono: ");
//            usuario.Telefono = Console.ReadLine();

//            Console.WriteLine("Celular: ");
//            usuario.Celular = Console.ReadLine();

//            Console.WriteLine("Fecha de Nacimiento (Año-Mes-Día): ");
//            usuario.FechaDeNacimiento = DateTime.Parse(Console.ReadLine());

//            Console.WriteLine("CURP: ");
//            usuario.CURP = Console.ReadLine();

//            //Console.WriteLine("Cargar Imagen: ");
//            //usuario.Imagen = Console.ReadLine();

//            Console.WriteLine("Id Rol: ");
//            usuario.Rol = new ML.Rol();
//            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

//            ML.Result result = BL.Usuario.Update(usuario);

//            if (result.Correct)
//            {
//                Console.WriteLine("El usuario se actualizó correctamente");
//            }
//            else
//            {
//                Console.WriteLine("Ocurrio un error al actualizar al usuario" + result.ErrorMessage);
//                Console.WriteLine(result.Ex);

//            }
//            Console.ReadKey();
//        }

// //---DELETE 
//        public static void DeleteEF()
//        {
//            ML.Usuario usuario = new ML.Usuario();

//            Console.WriteLine("Ingrese el ID del usuario que desea eliminar:");
//            usuario.IdUsuario = int.Parse(Console.ReadLine());


//            ML.Result result = BL.Usuario.Delete(usuario);

//            if (result.Correct)
//            {
//                Console.WriteLine("El usuario se eliminó correctamente");
//            }
//            else
//            {
//                Console.WriteLine("Ocurrio un error al eliminar al usuario" + result.ErrorMessage);
//                Console.WriteLine(result.Ex);
//            }

//            Console.ReadKey();
//        }

////GETALL
//        public static void GetAllEF() 
//        {
//            ML.Result result = BL.Usuario.GetAll();

//            if (result.Correct)
//            {
//                foreach (ML.Usuario usuario in result.Objects)
//                {
//                    Console.WriteLine(usuario.IdUsuario);
//                    Console.WriteLine(usuario.UserName);
//                    Console.WriteLine(usuario.Nombre);
//                    Console.WriteLine(usuario.ApellidoPaterno);
//                    Console.WriteLine(usuario.ApellidoMaterno);
//                    Console.WriteLine(usuario.Email);
//                    Console.WriteLine(usuario.Contrasenia);
//                    Console.WriteLine(usuario.Sexo);
//                    Console.WriteLine(usuario.Telefono);
//                    Console.WriteLine(usuario.Celular);
//                    Console.WriteLine(usuario.FechaDeNacimiento);
//                    Console.WriteLine(usuario.CURP);
//                    //Console.WriteLine(usuario.Imagen);
//                    Console.WriteLine(usuario.Rol.IdRol);
//                }
//            }
//            else
//            {
//                Console.WriteLine("No se encontraron registros " + result.ErrorMessage);
//            }
//            Console.ReadKey();
//        }


// //---GetById

//        public static void GetByIdEF() 
//        {

//            ML.Usuario usuario = new ML.Usuario();


//            Console.WriteLine("Ingrese el Id del usuario que desea ver: ");
//            usuario.IdUsuario = int.Parse(Console.ReadLine());

//            ML.Result result = BL.Usuario.GetById(usuario.IdUsuario);

//            if (result.Correct)
//            {
//                usuario = (ML.Usuario)result.Object;
//                Console.WriteLine(usuario.IdUsuario);
//                Console.WriteLine(usuario.UserName);
//                Console.WriteLine(usuario.Nombre);
//                Console.WriteLine(usuario.ApellidoPaterno);
//                Console.WriteLine(usuario.ApellidoMaterno);
//                Console.WriteLine(usuario.Email);
//                Console.WriteLine(usuario.Contrasenia);
//                Console.WriteLine(usuario.Sexo);
//                Console.WriteLine(usuario.Telefono);
//                Console.WriteLine(usuario.Celular);
//                Console.WriteLine(usuario.FechaDeNacimiento);
//                Console.WriteLine(usuario.CURP);
//                //Console.WriteLine(usuario.Imagen);
//                Console.WriteLine(usuario.Rol.IdRol);

//            }
//            else
//            {
//                Console.WriteLine("No se encontraron registros " + result.ErrorMessage);
//            }

//            Console.ReadKey();
//        }


//        //-----------------------------------------LINQ---------------------------------------------------------

//        //---ADD
//        public static void AddLinQ()
//        {
//            ML.Usuario usuario = new ML.Usuario();


//            Console.WriteLine("Ingrese el nombre de usuario: ");
//            usuario.UserName = Console.ReadLine();

//            Console.WriteLine("Nombre real: ");
//            usuario.Nombre = Console.ReadLine();

//            Console.WriteLine("Apellido Paterno: ");
//            usuario.ApellidoPaterno = Console.ReadLine();

//            Console.WriteLine("Apellido Materno: ");
//            usuario.ApellidoMaterno = Console.ReadLine();

//            Console.WriteLine("Email: ");
//            usuario.Email = Console.ReadLine();

//            Console.WriteLine("Ingrese una Contraseña: ");
//            usuario.Contrasenia = Console.ReadLine();

//            Console.WriteLine("Sexo (H - M): ");
//            usuario.Sexo = Console.ReadLine();

//            Console.WriteLine("Telefono: ");
//            usuario.Telefono = Console.ReadLine();

//            Console.WriteLine("Celular: ");
//            usuario.Celular = Console.ReadLine();

//            Console.WriteLine("Fecha de Nacimiento (Año-Mes-Día): ");
//            usuario.FechaDeNacimiento = DateTime.Parse(Console.ReadLine());

//            Console.WriteLine("CURP: ");
//            usuario.CURP = Console.ReadLine();

//            //Console.WriteLine("Cargar Imagen: ");
//            //usuario.Imagen = Console.ReadLine();

//            Console.WriteLine("Id Rol: ");
//            usuario.Rol = new ML.Rol();
//            usuario.Rol.IdRol = int.Parse(Console.ReadLine());


//            ML.Result result = BL.Usuario.Add(usuario);

//            if (result.Correct)
//            {
//                Console.WriteLine("El usuario se Agregó correctamente");
//            }
//            else
//            {
//                Console.WriteLine("Ocurrio un error al Agregar al usuario" + result.ErrorMessage);
//                Console.WriteLine(result.Ex);
//            }
//            Console.ReadKey();

//        }


//        //---UPDATE

//        public static void UpdateLinQ()
//        {
//            ML.Usuario usuario = new ML.Usuario();

//            Console.WriteLine("----- ACTUALIZAR DATOS -----\n\n");

//            Console.WriteLine("Ingrese el ID del usuario que desea Actualizar:");
//            usuario.IdUsuario = int.Parse(Console.ReadLine());

//            Console.WriteLine("Ingrese el nombre de usuario: ");
//            usuario.UserName = Console.ReadLine();

//            Console.WriteLine("Nombre real: ");
//            usuario.Nombre = Console.ReadLine();

//            Console.WriteLine("Apellido Paterno: ");
//            usuario.ApellidoPaterno = Console.ReadLine();

//            Console.WriteLine("Apellido Materno: ");
//            usuario.ApellidoMaterno = Console.ReadLine();

//            Console.WriteLine("Email: ");
//            usuario.Email = Console.ReadLine();

//            Console.WriteLine("Ingrese una Contraseña: ");
//            usuario.Contrasenia = Console.ReadLine();

//            Console.WriteLine("Sexo (H - M): ");
//            usuario.Sexo = Console.ReadLine();

//            Console.WriteLine("Telefono: ");
//            usuario.Telefono = Console.ReadLine();

//            Console.WriteLine("Celular: ");
//            usuario.Celular = Console.ReadLine();

//            Console.WriteLine("Fecha de Nacimiento (Año-Mes-Día): ");
//            usuario.FechaDeNacimiento = DateTime.Parse(Console.ReadLine());

//            Console.WriteLine("CURP: ");
//            usuario.CURP = Console.ReadLine();

//            //Console.WriteLine("Cargar Imagen: ");
//            //usuario.Imagen = Console.ReadLine();

//            Console.WriteLine("Id Rol: ");
//            usuario.Rol = new ML.Rol();
//            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

//            ML.Result result = BL.Usuario.Update(usuario);

//            if (result.Correct)
//            {
//                Console.WriteLine("El usuario se actualizó correctamente");
//            }
//            else
//            {
//                Console.WriteLine("Ocurrio un error al actualizar al usuario" + result.ErrorMessage);
//                Console.WriteLine(result.Ex);

//            }
//            Console.ReadKey();
//        }

//        //---DELETE 
//        public static void DeleteLinQ()
//        {
//            ML.Usuario usuario = new ML.Usuario();

//            Console.WriteLine("Ingrese el ID del usuario que desea eliminar:");
//            usuario.IdUsuario = int.Parse(Console.ReadLine());


//            ML.Result result = BL.Usuario.Delete(usuario);

//            if (result.Correct)
//            {
//                Console.WriteLine("El usuario se eliminó correctamente");
//            }
//            else
//            {
//                Console.WriteLine("Ocurrio un error al eliminar al usuario" + result.ErrorMessage);
//                Console.WriteLine(result.Ex);
//            }

//            Console.ReadKey();
//        }

//        //GETALL
//        public static void GetAllLinQ()
//        {
//            ML.Result result = BL.Usuario.GetAll();

//            if (result.Correct)
//            {
//                foreach (ML.Usuario usuario in result.Objects)
//                {
//                    Console.WriteLine(usuario.IdUsuario);
//                    Console.WriteLine(usuario.UserName);
//                    Console.WriteLine(usuario.Nombre);
//                    Console.WriteLine(usuario.ApellidoPaterno);
//                    Console.WriteLine(usuario.ApellidoMaterno);
//                    Console.WriteLine(usuario.Email);
//                    Console.WriteLine(usuario.Contrasenia);
//                    Console.WriteLine(usuario.Sexo);
//                    Console.WriteLine(usuario.Telefono);
//                    Console.WriteLine(usuario.Celular);
//                    Console.WriteLine(usuario.FechaDeNacimiento);
//                    Console.WriteLine(usuario.CURP);
//                    //Console.WriteLine(usuario.Imagen);
//                    Console.WriteLine(usuario.Rol.IdRol);
//                }
//            }
//            else
//            {
//                Console.WriteLine("No se encontraron registros " + result.ErrorMessage);
//            }
//            Console.ReadKey();
//        }


//        ////---GetById

//        public static void GetByIdLinQ()
//        {

//            ML.Usuario usuario = new ML.Usuario();


//            Console.WriteLine("Ingrese el Id del usuario que desea ver: ");
//            usuario.IdUsuario = int.Parse(Console.ReadLine());

//            ML.Result result = BL.Usuario.GetById(usuario.IdUsuario);

//            if (result.Correct)
//            {
//                usuario = (ML.Usuario)result.Object;
//                Console.WriteLine(usuario.IdUsuario);
//                Console.WriteLine(usuario.UserName);
//                Console.WriteLine(usuario.Nombre);
//                Console.WriteLine(usuario.ApellidoPaterno);
//                Console.WriteLine(usuario.ApellidoMaterno);
//                Console.WriteLine(usuario.Email);
//                Console.WriteLine(usuario.Contrasenia);
//                Console.WriteLine(usuario.Sexo);
//                Console.WriteLine(usuario.Telefono);
//                Console.WriteLine(usuario.Celular);
//                Console.WriteLine(usuario.FechaDeNacimiento);
//                Console.WriteLine(usuario.CURP);
//                //Console.WriteLine(usuario.Imagen);
//                Console.WriteLine(usuario.Rol.IdRol);

//            }
//            else
//            {
//                Console.WriteLine("No se encontraron registros " + result.ErrorMessage);
//            }

//            Console.ReadKey();
//        }

//    }

}
    
   







