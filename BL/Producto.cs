using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MGonzalezProgramacionNCapas2Entities context = new DL_EF.MGonzalezProgramacionNCapas2Entities())
                {
                    var query = context.ProductoAdd(producto.Nombre, producto.PrecioUnitario, producto.Stock, 
                                producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento, producto.Descripcion, producto.Imagen);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudieron agregar los productos";
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

        public static ML.Result GetAll(ML.Producto productoBusqueda)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MGonzalezProgramacionNCapas2Entities context = new DL_EF.MGonzalezProgramacionNCapas2Entities())
                {
                    var query = context.ProductoGetAll(productoBusqueda.Nombre, productoBusqueda.Departamento.IdDepartamento).ToList();
                    
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Producto producto = new ML.Producto();

                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.ProductoNombre;
                            producto.PrecioUnitario= obj.PrecioUnitario;
                            producto.Stock = obj.Stock;

                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = (int)obj.IdProveedor;
                            producto.Proveedor.Nombre = obj.ProveedorNombre;

                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = (int)obj.IdDepartamento;
                            producto.Departamento.Nombre = obj.DepartamentoNombre;

                            producto.Departamento.Area = new ML.Area();
                            producto.Departamento.Area.IdArea = obj.IdArea;
                            producto.Departamento.Area.Nombre = obj.AreaNombre;

                            producto.Descripcion= obj.Descripcion;
                            producto.Imagen = obj.Imagen;

                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay productos existentes";
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

        public static ML.Result Update(ML.Producto producto) 
        { 
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MGonzalezProgramacionNCapas2Entities context = new DL_EF.MGonzalezProgramacionNCapas2Entities()) 
                { 
                    var query = context.ProductoUpdate(producto.IdProducto, producto.Nombre, producto.PrecioUnitario, producto.Stock,
                                        producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento, producto.Descripcion, producto.Imagen);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo agregar el producto";
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


        public static ML.Result GetById(int IdProducto) 
        { 
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MGonzalezProgramacionNCapas2Entities context = new DL_EF.MGonzalezProgramacionNCapas2Entities())
                {
                    var query = context.ProductoGetById(IdProducto).FirstOrDefault();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        ML.Producto producto = new ML.Producto();

                        producto.IdProducto = query.IdProducto;
                        producto.Nombre = query.Nombre;
                        producto.PrecioUnitario = query.PrecioUnitario;
                        producto.Stock = query.Stock;
                      
                        producto.Proveedor = new ML.Proveedor();
                        producto.Proveedor.IdProveedor = (int)query.IdProveedor;
                        
                        producto.Departamento = new ML.Departamento();
                        producto.Departamento.IdDepartamento = (int)query.IdDepartamento;

                        producto.Departamento.Area = new ML.Area();
                        producto.Departamento.Area.IdArea = (int)query.IdArea;

                        producto.Descripcion = query.Descripcion;
                        producto.Imagen = query.Imagen;

                        result.Objects.Add(producto);
                        result.Object = producto;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron datos que mostrar";
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

        public static ML.Result Delete(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MGonzalezProgramacionNCapas2Entities context = new DL_EF.MGonzalezProgramacionNCapas2Entities())
                {
                    var query = context.ProductoDelete(producto.IdProducto);
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

        




    }
    
}
