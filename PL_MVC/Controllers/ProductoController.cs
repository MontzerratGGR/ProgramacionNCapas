using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Xml.Schema;

namespace PL_MVC.Controllers
{
    public class ProductoController : Controller
    {
        [HttpGet] //GETALL
        public ActionResult GetAll()
        {
            ML.Producto producto = new ML.Producto();

            producto.Productos = new List<object>();

            //DDL Area-Departamento
            producto.Departamento = new ML.Departamento();
            producto.Departamento.Area = new ML.Area();

            producto.Nombre = "";
            producto.IdDepartamento = 0;
            ML.Result resultArea = BL.Area.GetAll();
            producto.Departamento.Area.Areas = resultArea.Objects;


            ML.Result result = BL.Producto.GetAll(producto);
            if (result.Correct)
            {
                producto.Productos = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(producto);
        }

        [HttpPost] //GETALL
        public ActionResult GetAll(ML.Producto productoBusqueda)
        {

            ML.Producto producto = new ML.Producto();
            producto.Productos = new List<object>();

            //DDL Area-Departamento
            producto.Departamento = new ML.Departamento();
            producto.Departamento.Area = new ML.Area();

            productoBusqueda.Nombre = (productoBusqueda.Nombre == null) ? "" : productoBusqueda.Nombre;
            producto.IdDepartamento = 0;
            ML.Result resultArea = BL.Area.GetAll();
            producto.Departamento.Area.Areas = resultArea.Objects;

            ML.Result result = BL.Producto.GetAll(productoBusqueda);
            if (result.Correct)
            {
                producto.Productos = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(producto);
        }

        [HttpGet] //GETBYID
        public ActionResult FormProducto(int? IdProducto, int? IdArea)
        {

            ML.Producto producto = new ML.Producto();

            //DDL Area-Departamento
            producto.Departamento = new ML.Departamento();
            producto.Departamento.Area = new ML.Area();


            ML.Result resultArea = BL.Area.GetAll();
            producto.Departamento.Area.Areas = resultArea.Objects;

            //Proveedores DDL
            ML.Result resulProveedor = BL.Proveedor.GetAll();
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.Provedores = resulProveedor.Objects;


            //Datos cargados
            if (IdProducto == null)
            {
                return View(producto);
            }
            else
            {
                //ServiceProducto.ProductoClient productoService = new ServiceProducto.ProductoClient();
                //var result = productoService.GetById((int)IdProducto);
                ML.Result result = BL.Producto.GetById((int)IdProducto); // Instancia BL
                //producto = FillDropDownList(producto);

                producto.IdProducto = ((ML.Producto)result.Object).IdProducto;
                producto.Nombre = ((ML.Producto)result.Object).Nombre;
                producto.PrecioUnitario = ((ML.Producto)result.Object).PrecioUnitario;
                producto.Stock = ((ML.Producto)result.Object).Stock;
                producto.Proveedor.IdProveedor = ((ML.Producto)result.Object).Proveedor.IdProveedor;
                producto.Proveedor.Nombre = ((ML.Producto)result.Object).Proveedor.Nombre;
                producto.Departamento.IdDepartamento = ((ML.Producto)result.Object).Departamento.IdDepartamento;
                producto.Departamento.Nombre = ((ML.Producto)result.Object).Departamento.Nombre;
                producto.Departamento.Area.IdArea = ((ML.Producto)result.Object).Departamento.Area.IdArea;
                producto.Departamento.Area.Nombre = ((ML.Producto)result.Object).Departamento.Area.Nombre;
                producto.Descripcion = ((ML.Producto)result.Object).Descripcion;
                producto.Imagen = ((ML.Producto)result.Object).Imagen;

                producto = FillDropDownList(producto);
                return View(producto);
            }

        }

        public JsonResult DepartamentoGetByIdArea(int IdArea)
        {
            ML.Result result = BL.Departamento.GetById(IdArea);
            return Json(result.Objects);
        }

        [HttpGet] //VISTA DE CARGA
        public ActionResult Carga()
        {
            ML.Producto carga = new ML.Producto();

            return View(carga);
        }

        public static ML.Producto Previsualizar(ML.Producto producto, HttpPostedFileBase fuTxtCargaMasivaProducto)
        {
            producto.Productos = new List<object>();

            using (StreamReader file = new StreamReader(fuTxtCargaMasivaProducto.InputStream))
            {
                int counter = 0;
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    if (counter > 0)
                    {
                        var datos = ln.Split('|');

                        ML.Producto productoItem = new ML.Producto();
                        productoItem.Nombre = datos[0];
                        productoItem.PrecioUnitario = decimal.Parse(datos[1]);
                        productoItem.Stock = int.Parse(datos[2]);
                        productoItem.Proveedor = new ML.Proveedor();
                        productoItem.Proveedor.IdProveedor = int.Parse(datos[3]);
                        productoItem.Departamento = new ML.Departamento();
                        productoItem.Departamento.IdDepartamento = int.Parse(datos[4]);
                        productoItem.Descripcion = datos[5];

                        producto.Productos.Add(productoItem);

                    }
                    counter++;
                }
            }

            return producto;
        }

        public ML.Producto PrevisualizarExcel(ML.Producto producto, string RutaExcel, string CadenaConexion)
        {
            try
            {
                using (OleDbConnection context = new OleDbConnection(CadenaConexion + RutaExcel))
                {
                    string query = "SELECT * FROM [Sheet1$]";
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;

                        OleDbDataAdapter da = new OleDbDataAdapter();
                        da.SelectCommand = cmd;
                        DataTable tableProducto = new DataTable();

                        try
                        {
                            da.Fill(tableProducto);

                        }
                        catch (Exception ex)
                        {

                        }
                        if (tableProducto.Rows.Count > 0)
                        {
                            producto.Productos = new List<object>();

                            foreach (DataRow row in tableProducto.Rows)
                            {
                                ML.Producto productoItem = new ML.Producto();

                                productoItem.Nombre = row[0].ToString();
                                productoItem.PrecioUnitario = decimal.Parse(row[1].ToString());
                                productoItem.Stock = int.Parse(row[2].ToString());
                                productoItem.Proveedor = new ML.Proveedor();
                                productoItem.Proveedor.IdProveedor = int.Parse(row[3].ToString());
                                productoItem.Departamento = new ML.Departamento();
                                productoItem.Departamento.IdDepartamento = int.Parse(row[4].ToString());
                                productoItem.Descripcion = row[5].ToString();

                                producto.Productos.Add(productoItem);

                            }

                        }
                    }
                }

            }
            catch (Exception)
            {

            }

            return producto;
        }


        public void CargarDatos(ML.Producto producto)
        {
            List<string> listResult = new List<string>();

            foreach (ML.Producto productoItem in producto.Productos)
            {
                ML.Result result = BL.Producto.Add(productoItem);

                if (result.Correct)
                {
                    listResult.Add("La insercción del producto" + producto.Nombre + "Fue exitoso");
                }
                else
                {
                    listResult.Add("Hubo un error al ingresar el producto: " + producto.Nombre + "Error: " + result.ErrorMessage);


                }
            }
            var fecha = DateTime.Now.ToString("dd-MM-yyyy HHmmss");
            string path = Server.MapPath("~/CargaMasiva/TXT" + "CargaMasivaTXT_" + fecha + ".txt");


            using (StreamWriter archivoErrores = System.IO.File.CreateText(path))
            {
                foreach (string mensaje in listResult)
                {
                    archivoErrores.WriteLine(mensaje);

                }
            }

        }

        [HttpPost]
        public ActionResult Carga(ML.Producto producto, HttpPostedFileBase fuTxtCargaMasivaProducto)
        {
            //Validar archivo
            string extension = Path.GetExtension(fuTxtCargaMasivaProducto.FileName);
            if (extension == ".txt")
            {
                if (Session["ListProductos"] == null)
                {
                    producto = Previsualizar(producto, fuTxtCargaMasivaProducto);
                    Session["ListProductos"] = producto.Productos;
                }
                else
                {
                    var x = (List<object>)Session["ListProductos"];
                    producto.Productos = x;
                    CargarDatos(producto);
                }

            }
            else
            {
                if (extension == ".xlsx")
                {
                    if (Session["ListProductos"] == null)
                    {
                        string conexionExcel = System.Configuration.ConfigurationManager.AppSettings["ConexionExcel"];

                        var fecha = DateTime.Now.ToString("dd-MM-yyyy HHmmss");
                        string direccionExcel = Server.MapPath("~/CargaMasiva/Excel/") + Path.GetFileNameWithoutExtension(fuTxtCargaMasivaProducto.FileName) + '-' + fecha + ".xlsx";

                        try
                        {
                            fuTxtCargaMasivaProducto.SaveAs(direccionExcel);
                            producto = PrevisualizarExcel(producto, direccionExcel, conexionExcel);
                            Session["ListProductos"] = producto.Productos;
                        }
                        catch (Exception)
                        {

                        }
                    }
                    else
                    {
                        var x = (List<object>)Session["ListProductos"];
                        producto.Productos = x;
                        CargarDatos(producto);
                        return PartialView("Modal");
                    }

                }
            }

            return View(producto);
        }

        [HttpPost]
        public ActionResult FormProducto(ML.Producto producto, HttpPostedFileBase fuImagen) 
        {
          
            if (ModelState.IsValid)
            {
                if (fuImagen != null) //IMAGEN
                {
                    producto.Imagen = this.ConvertToBytes(fuImagen);
                }

                if (producto.IdProducto == 0) //Agregar PRODUCTO
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:50593/api/");

                        var postTask = client.PostAsJsonAsync<ML.Producto>("producto/add", producto);
                        postTask.Wait();

                        var resultAdd = postTask.Result;
                        if (resultAdd.IsSuccessStatusCode)
                        {
                            return RedirectToAction("GetAll");

                        }
                        return View(producto);
                    }
                    ////Instancia de SL
                    //ServiceProducto.ProductoClient productoService = new ServiceProducto.ProductoClient();
                    //var result = productoService.Add(producto);

                    //// ML.Result result = BL.Producto.Add(producto); //INSTANCIA DE BL

                    //if (result.Correct)
                    //{
                    //    ViewBag.Mensaje = "Producto agregado exitosamente";
                    //}
                    //else
                    //{
                    //    ViewBag.Mensaje = "No se ha ingresado correctamente el producto. Error: " + result.ErrorMessage;
                    //}
                }

                else //UPDATE //PENDIENTEEE
                {
                    using (var client = new HttpClient())
                    { 
                        producto.Departamento = new ML.Departamento();
                      
                        producto.Departamento.Area = new ML.Area();

                        ML.Result resultArea = BL.Area.GetAll();
                        producto.Departamento.Area.Areas = resultArea.Objects;

                        client.BaseAddress = new Uri("http://localhost:50593/api/");

                        //HTTP POST
                        var postTask = client.PutAsJsonAsync<ML.Producto>("producto/update", producto);
                        postTask.Wait();

                        var resultUpdate = postTask.Result;
                        if (resultUpdate.IsSuccessStatusCode)
                        {
                            return RedirectToAction("GetAll");
                        }
                        producto = FillDropDownList(producto);
                    }

                }
               
                //    ServiceProducto.ProductoClient productoService = new ServiceProducto.ProductoClient();
                //        var result = productoService.Update(producto);

                //        // ML.Result result = BL.Producto.Update(producto);

                //        if (result.Correct)
                //        {
                //            ViewBag.Mensaje = "Se ha actualizado correctamente";

                //        }
                //        else
                //        {
                //            ViewBag.Mensaje = "No se ha podido actualizar correctamente. Error: " + result.ErrorMessage;
                //        }
                //    }
                //    return PartialView("Modal");
                //}

                //producto = FillDropDownList(producto);
                //return View(producto);
            }
            return RedirectToAction("GetAll");
            //return View("GetAll");
        } 

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;

        }

        [HttpDelete]
        public ActionResult Delete(ML.Producto producto)
        {
            ML.Result resultProducto = new ML.Result();
            int id = producto.IdProducto;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50593/api/");

                //HTTP POST
                var postTask = client.DeleteAsync("producto/delete/" + id);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    resultProducto = BL.Producto.GetAll(producto);
                    return RedirectToAction("GetAll", resultProducto);
                }
            }
            resultProducto = BL.Producto.GetAll(producto);

            return View("GetAll", resultProducto);
        }


        //ServiceProducto.ProductoClient productoService = new ServiceProducto.ProductoClient();
        //    var result = productoService.Delete(producto);

        //   // ML.Result result = BL.Producto.Delete(producto);

        //    if (result.Correct)
        //    {
        //        ViewBag.Mesanje = "Se ha eliminado correctamente";
        //    }

        //    else
        //    {
        //        ViewBag.Mensaje = "No se ha podido eliminar el usuario. Error:" + result.ErrorMessage;
        //    }

        //    return PartialView("Modal");
        //}


        private ML.Producto FillDropDownList(ML.Producto producto) //LLENADO DE LISTA
        {
            ML.Result resuArea = new ML.Result();
            resuArea = BL.Area.GetAll();

            ML.Result resuDepartamento = BL.Departamento.GetById(producto.Departamento.Area.IdArea);
            producto.Departamento.Area.Areas = resuArea.Objects;

            producto.Departamento.Departamentos = resuDepartamento.Objects;


            ML.Result resultProveedores = BL.Proveedor.GetAll();
            producto.Proveedor.Provedores = resultProveedores.Objects;

            return producto;
        }



    }
}