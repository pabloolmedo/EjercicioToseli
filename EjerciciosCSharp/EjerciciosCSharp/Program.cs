using Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EjerciciosCSharp
{
    class Program
    {
       public static void Main(string[] args)
        {


            Hotel hotel1 = new Hotel();

            hotel1.fechaInicio = "22/03/2019";
            hotel1.nombre = "hotel san juan";
            hotel1.precioNoche = new string[] { "150", "200", "0", "500" };
            hotel1.ciudad = "Cordoba";
            hotel1.comision = "10";
            hotel1.porcentajeDescuento = "20";
            hotel1.montoTotalConDescuento = "0";

            Hotel hotel2 = new Hotel();

            hotel2.fechaInicio = "06/05/2019";
            hotel2.nombre = "hotel lpm";
            hotel2.precioNoche = new string[] { "200", "120", "130", "0", "0", "250" };
            hotel2.ciudad = "Salta";
            hotel2.comision = "50";
            hotel2.porcentajeDescuento = "26,5";
            hotel2.montoTotalConDescuento = "0";

            // Creacion de lista de hoteles
            var listaHoteles = new List<Hotel>();
            listaHoteles.Add(hotel1);
            listaHoteles.Add(hotel2);

            
           


            // Obtener fecha de salida del hotel1
            //DateTime GetFechaFinal()
            //{
            //    DateTime fechaSalida = new DateTime();
            //    //fechaSalida = Convert.toDateTime(hotel1.fechaInicio); otra manera sin definir formate de fecha.
            //    fechaSalida = DateTime.ParseExact(hotel1.fechaInicio, "dd/MM/yyyy", CultureInfo.InvariantCulture);// ver que es cultureinfo
            //    return fechaSalida.AddDays(hotel1.precioNoche.Count());
            //}

            Console.WriteLine("La fecha de salida es:  {0}{1}{2}", GetFechaFinal(hotel1), " El servicio se presto en: ", GetCity(hotel2));
            Console.WriteLine("Monto total con descuento del servicio: {0}", GetFinalPriceWithDiscount(hotel2));
            Console.ReadKey();
        }

        //Obtener nombre ciudad donde se presto el servicio de hotel2
        public static string GetCity(Hotel hotel)
        {
            string nombreCiudad = hotel.ciudad;

            return nombreCiudad;
        }

        // Obtener fecha de salida del hotel1
       public static DateTime GetFechaFinal(Hotel hotel)
        {
            DateTime fechaSalida = new DateTime();
            //fechaSalida = Convert.toDateTime(hotel1.fechaInicio); otra manera sin definir formate de fecha.
            fechaSalida = DateTime.ParseExact(hotel.fechaInicio, "dd/MM/yyyy", CultureInfo.InvariantCulture);// ver que es cultureinfo
            return fechaSalida.AddDays(hotel.precioNoche.Count());
        }

        //Obtener monto total con descuento
        public static decimal GetFinalPriceWithDiscount(Hotel hotel)
        {
            int sumTotal = 0;
            decimal descuento = 0;
            decimal montoTotalConDescuento = 0;
            
           decimal precioTotalServicio = 0;
            foreach (var item in hotel.precioNoche)
            {
                 sumTotal = Convert.ToInt32(item) + sumTotal;
                precioTotalServicio = sumTotal;
                
            }
            descuento = (Convert.ToDecimal(hotel.porcentajeDescuento) /100  ) * precioTotalServicio;
            
            montoTotalConDescuento = precioTotalServicio - Decimal.Round(descuento,1);
            

            return montoTotalConDescuento; 
        }

    }
}
