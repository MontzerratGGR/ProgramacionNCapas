using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Producto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Producto.svc or Producto.svc.cs at the Solution Explorer and start debugging.
    public class Producto : IProducto
    {
        public SL_WCF.Result Update(ML.Producto producto)
        {
            ML.Result result = BL.Producto.Update(producto);
            SL_WCF.Result resultSL = new SL_WCF.Result();

            resultSL.Correct = result.Correct;
            resultSL.ErrorMessage = result.ErrorMessage;
            resultSL.Ex = result.Ex;

            return resultSL;
        }

        public SL_WCF.Result Add(ML.Producto producto)
        {
            ML.Result result = BL.Producto.Add(producto);
            SL_WCF.Result resultSL = new SL_WCF.Result();

            resultSL.Correct = result.Correct;
            resultSL.ErrorMessage = result.ErrorMessage;
            resultSL.Ex = result.Ex;

            return resultSL;
        }

        public SL_WCF.Result Delete(int producto)
        {
            ML.Producto productoItem = new ML.Producto();
            productoItem.IdProducto =  producto;

            ML.Result result = BL.Producto.Delete(productoItem);
            SL_WCF.Result resultSL = new SL_WCF.Result();

            resultSL.Correct = result.Correct;
            resultSL.ErrorMessage = result.ErrorMessage;
            resultSL.Ex = result.Ex;

            return resultSL;
        }

        public SL_WCF.Result GetAll(ML.Producto productoBusqueda)
        {
            ML.Result result = BL.Producto.GetAll(productoBusqueda);

            SL_WCF.Result resultSL = new SL_WCF.Result();
            resultSL.Correct = result.Correct;
            resultSL.ErrorMessage = result.ErrorMessage;
            resultSL.Ex = result.Ex;

            return resultSL;
        }

        public SL_WCF.Result GetById(int IdProducto)
        { 
            ML.Producto producto = new ML.Producto();
            producto.IdProducto = IdProducto;

            //ML.Result result = BL.Producto.GetById(IdProducto);
            ML.Result result = BL.Producto.GetById((int)IdProducto);

            SL_WCF.Result resultSL = new SL_WCF.Result();

            resultSL.Correct = result.Correct;
            resultSL.ErrorMessage = result.ErrorMessage;
            resultSL.Ex = result.Ex;
            resultSL.Objects = new List<object>();

            return resultSL;
        }
    }
}
