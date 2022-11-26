using System;
using Cards;
using Bank;
namespace DateComprobation
{
    public class FechaC
    {
        //en el metodo declaramos las variables de entrada
        public bool Comparando(DateTime date2)
        {
            //variable del metodo
            bool pass2;
            DateTime localDate = DateTime.Now;
            if (localDate < date2)
            {
                pass2 = true;
            }
            else
            {
                pass2 = false;
                Console.WriteLine("Su tarjeta ha expirado," +
                                  " pase a ventanilla para renovar");
            }
            //regresamos variable de salida
            return pass2;
        }

    }
}