using System;
using Cards;
using DateComprobation;

namespace Options
{
    public class Menu
    {
        long[] card_number = { 4242424242424240, 4000056655665550, 5555555555554440, 2223003122003220 };
        int option;
        double moneyr;
        long numt;
        bool flag = false;
        public void Options()
        {

            Console.WriteLine("Acceso Concedido, elija una opción: \n");

            while (!flag)
            {
                bool verification = false;
                Console.WriteLine("1) Consultar saldo \n" +
                               "2) Depósito \n" +
                               "3) Retirar efectivo \n" +
                               "4) Transferencia \n" +
                               "5) Salir \n");
                option = Int32.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        // Consultar saldo
                        Console.WriteLine("Querid@ " +
                        InicioDeSesion.name + "\n");
                        Console.WriteLine("Su saldo es de:" +
                        InicioDeSesion.money);
                        Console.WriteLine("Su tarjeta vence el: " +
                        InicioDeSesion.date + "\n");
                        break;
                    case 2:
                        // Deposito
                        Console.WriteLine("Ingrese el número de la " +
                        "tarjeta a donde desea depositar el dinero.");
                        numt = Int64.Parse(Console.ReadLine());
                        foreach (long element in card_number)
                        {
                            if (element == numt)
                            {
                                verification = true;
                            }
                        }
                        if (verification)
                        {
                            Console.WriteLine("¿Cuánto dinero " +
                            "desea depositar? ");
                            double local_money =
                            double.Parse(Console.ReadLine());

                            Console.WriteLine("Depósito realizado " + "con éxito \n");
                        }
                        else
                        {
                            Console.WriteLine("Error, el usuario no existe \n");
                        }

                        break;
                    case 3:
                        // Retirar efectivo

                        Console.WriteLine("¿Cuánto dinero desea " +
                                          "retirar?:");
                        moneyr = double.Parse(Console.ReadLine());
                        if (moneyr < InicioDeSesion.money)
                        {
                            InicioDeSesion.money =
                            InicioDeSesion.money - moneyr;
                            Console.WriteLine("Su retiro se " +
                                              "realizo con exito");
                        }
                        else
                        {
                            Console.WriteLine("No posee los " +
                                              "fondos suficientes \n");
                            continue;
                        }
                        break;
                    case 4:
                        //Transferir
                        Console.WriteLine("Ingrese el número de la " +
                        "tarjeta a donde desea transferir el "
                        + " dinero.");
                        numt = Int64.Parse(Console.ReadLine());
                        foreach (long element in card_number)
                        {
                            if (element == numt)
                            {
                                verification = true;
                            }
                        }
                        if (verification)
                        {
                            Console.WriteLine("¿Cuanto dinero desea " +
                         "transferir?:");
                            moneyr = double.Parse(Console.ReadLine());
                            if (moneyr <= InicioDeSesion.money)
                            {
                                InicioDeSesion.money =
                                InicioDeSesion.money - moneyr;
                                Console.WriteLine("Su deposito se " +
                                                  " realizo con exito \n");
                            }
                            else
                            {
                                Console.WriteLine("No posee los " +
                                                  "fondos suficientes \n");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error, el usuario no existe \n");
                        }
                        break;
                    case 5:
                        //Salir
                        Console.Write("Gracias por usar nuestros " +
                                      "servicios, hasta pronto \n");
                        flag = true;
                        break;
                    default:
                        Console.WriteLine("Por favor, elige una " +
                                          "opción válida \n");
                        break;
                }
            }
        }
    }
}