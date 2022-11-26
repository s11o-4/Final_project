using System;
using DateComprobation;
using Bank;
using PasswordValidation;
using CVCValidation;
using Options;

namespace Cards
{
    public class InicioDeSesion
    {
        public static long cardNumber;
        public static string name = "";
        bool pass = false;
        int password = 0;
        int CVC = 0;
        public static double money;
        public static DateTime date = DateTime.MinValue;

        //nuestro metodo CardVerify
        public void CardVerify()
        {
            //Llamamos a la clase FechaC, PassV y CVCV
            FechaC recibiendo = new FechaC();
            PassV recibiendo2 = new PassV();
            CVCV recibiendo3 = new CVCV();
            //contador
            int i = 0;
            //hacer mientras
            do
            {
                Console.WriteLine("Hola, ingrese su número " +
                                  "de tarjeta para iniciar sesión:");
                cardNumber = Int64.Parse(Console.ReadLine());
                //Encuentra si el numero es alguno de estos casos
                switch (cardNumber)
                {
                    case 4242424242424240:
                        pass = true;
                        name = "Juan Montes";
                        //el contador se vuelve 4 por lo que cuando                            //llegue a while no se cumplira la condicion 
                        ///y saldra del ciclo
                        i = 4;
                        //fecha de vencimiento del usuario
                        date = new DateTime(2023, 9, 4);
                        //Contraseña
                        password = 1247;
                        //CVC
                        CVC = 584;
                        //saldo
                        money = 53564;
                        break;
                    case 4000056655665550:
                        pass = true;
                        name = "Pedro Zapata";
                        date = new DateTime(2020, 4, 6);
                        password = 8642;
                        CVC = 875;
                        money = 63000;
                        i = 4;
                        break;
                    case 5555555555554440:
                        pass = true;
                        name = "Ana Martinez";
                        date = new DateTime(2024, 8, 21);
                        password = 9545;
                        CVC = 950;
                        money = 8228;
                        i = 4;
                        break;
                    case 2223003122003220:
                        pass = true;
                        name = "Rogelio Guerra";
                        date = new DateTime(2023, 1, 13);
                        password = 3089;
                        CVC = 210;
                        money = 10567;
                        i = 4;
                        break;
                    default:
                        Console.WriteLine("Numero de tarjeta " +
                                          " inexistente, intente" +
                                          " nuevamente");
                        break;
                }

                if (pass)
                {
                    Console.WriteLine("Bienvenido " + name);
                }
                //contador +1  
                i++;
            } while (i < 3);
            //3 intentos permitiodos, si el contador es menor a 3 se               //repite el ciclo

            //Si el usuario llego a los 3 intentos lo sacara de la 
            //sesión
            if (i == 3)
            {
                Console.WriteLine("Numero de intentos excedido. " +
                                  "Sesión cerrada. Gracias y " +
                                  "lindo día");
                //esta funcion detiene al programa de continuar
                Environment.Exit(0);
            }
            //Recibimos la informacion de FechaC
            string gbye = "Sesión cerrada. Gracias " +
                          "y lindo día";
            pass = recibiendo.Comparando(date);
            if (pass == false)
            {
                Console.WriteLine(gbye);
                Environment.Exit(0);

            }
            pass = recibiendo2.ComparePass(password);
            if (pass == false)
            {
                Console.WriteLine(gbye);
                Environment.Exit(0);
            }
            pass = recibiendo3.CompareCVC(CVC);
            if (pass == false)
            {
                Console.WriteLine(gbye);
                Environment.Exit(0);
            }

            //Todo fue verificado
            var instance = new Menu();
            instance.Options();
        }
    }
}
