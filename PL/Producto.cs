using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PL
{
    internal class Producto
    {
        public static void ReadTXT() 
        {
            List<string> listResult = new List<string>();

            using (StreamReader file = new StreamReader("C:\\Users\\digis\\Documents\\Montzerrat Guadalupe Gonzalez Rivera\\CargaProducto.txt"))
            {
                int counter = 0;
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    if (counter > 0)
                    {
                        var datos = ln.Split('|');
                        Console.WriteLine(ln);

                        ML.Producto producto = new ML.Producto();

                        producto.Nombre = datos[0];
                        producto.PrecioUnitario = decimal.Parse(datos[1]);
                        producto.Stock = int.Parse(datos[2]);
                        producto.IdProveedor = int.Parse(datos[3]);
                        producto.IdDepartamento = int.Parse(datos[4]);
                        producto.Descripcion = datos[5];

                        ML.Result result = BL.Producto.Add(producto);

                        if (result.Correct)
                        {
                           listResult.Add("Se ha agregado el producto: " + producto.Nombre + " Correctamente");
                        }
                        else
                        {
                            listResult.Add("Hubo un error al agregarse el producto: " + producto.Nombre + "Error: " + result.ErrorMessage);
                        }
                    }
                    counter++;
                }
            }
            WriteResult(listResult);
        }


        public static void WriteResult(List<string> listResult) 
        { 
            using(StreamWriter outputFile = new StreamWriter("C:\\Users\\digis\\Documents\\Montzerrat Guadalupe Gonzalez Rivera\\Historial.txt"))
            {
                foreach (string line in listResult)
                {
                    outputFile.WriteLine(line);
                }
            }
        
        }
    }
}
