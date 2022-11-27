using System;
using Cards;
using Verify;
using DateComprobation;

namespace Options
{
    public class Menu
    {
        DatabaseManager instance = new DatabaseManager();
        int option;
        int actual_money = 0;

        //numero de tarjeta
        string cardNumber;
        bool flag = false;
        public void Options()
        {

            Console.WriteLine("Acceso Concedido, elija una opción: \n");

            while (!flag)
            {
                while(true)
                {
                    // bool verification = false;
                    Console.WriteLine("1) Consultar saldo \n" +
                                "2) Depósito \n" +
                                "3) Retirar efectivo \n" +
                                "4) Transferencia \n" +
                                "5) Salir \n");
              
                    try
                    {
                        option = Int32.Parse(Console.ReadLine());
                        break;
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("Por favor introduce solo numeros: \n");
                    }
                }
                switch (option)
                {
                    case 1:
                        // Consultar saldo
                        Console.WriteLine("Querid@ " +
                        InicioDeSesion.name + "\n");
                        Console.WriteLine("Tu saldo es de:" +
                        instance.GetData(InicioDeSesion.cardNumber,"saldo_disp"));
                        Console.WriteLine("Su tarjeta vence el: " +
                        InicioDeSesion.date.Day + "/" + InicioDeSesion.date.Month + 
                        "/" + InicioDeSesion.date.Year + "\n");
                        break;
                    case 2:
                        // Deposito
                        Console.WriteLine("Ingrese el número de la " +
                        "tarjeta a donde desea depositar el dinero.");
                        cardNumber = Console.ReadLine();
                        if (instance.GetData(cardNumber, cardNumber) != null)
                        {
                            Console.WriteLine("¿Cuánto dinero " +
                            "desea depositar? ");
                            int mon_dep;
                            try
                            {
                                mon_dep = Int32.Parse(Console.ReadLine());
                            }
                            catch (System.Exception)
                            {
                                Console.WriteLine("La cantidad máxima permitida es de 1,000,000." + "\nDeposito no realizado \n");   
                                continue;                                
                            }
                            if(mon_dep > 1000000)
                            {
                                Console.WriteLine("La cantidad máxima permitida es de 1,000,000." + "\nDeposito no realizado \n");   
                            }
                            else
                            {
                                //Obtengo el dinero con el que cuenta la persona en el momento actual
                                actual_money = Int32.Parse(instance.GetData(cardNumber, "saldo_disp"));
                                //Dinero final que tendrá
                                mon_dep = mon_dep + actual_money;
                                instance.ModDatabase(cardNumber, mon_dep.ToString());
                                Console.WriteLine("Deposito realizado con éxito! \n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error, el numero de tarjeta es incorrecto \n");
                        }
                        break;

                    case 3:
                        // Retirar efectivo
                        Console.WriteLine("¿Cuánto dinero desea retirar?: ");
                        int money_withdraw = Int32.Parse((Console.ReadLine()));
                        actual_money = Int32.Parse(instance.GetData(InicioDeSesion.cardNumber, "saldo_disp"));
                        if (money_withdraw <= actual_money)
                        {
                            int final_money = actual_money - money_withdraw;
                            instance.ModDatabase(InicioDeSesion.cardNumber, final_money.ToString());
                            Console.WriteLine("Su retiro se realizo con exito \n");
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
                        Console.WriteLine("Ingrese el número de la tarjeta a la que desea transferir ");
                        cardNumber = Console.ReadLine();
                        if(instance.GetData(cardNumber, cardNumber) != null)
                        {
                            Console.WriteLine("¿Cuánto dinero desea transferir?: \n");
                            int money_transfer = Int32.Parse((Console.ReadLine()));
                            actual_money = Int32.Parse(instance.GetData(InicioDeSesion.cardNumber, "saldo_disp"));
                            if(money_transfer <= actual_money)
                            {
                                int tran_actual_money = Int32.Parse(instance.GetData(cardNumber, "saldo_disp"));
                                //Cantidad de dinero que tendrá la persona a quien se le haga la transferencia
                                int final_money_transfer = tran_actual_money + money_transfer;
                                //Cantidad de dinero restante de la persona que hace la transferencia
                                int remaining_money = actual_money - money_transfer;
                                instance.ModDatabase(InicioDeSesion.cardNumber, remaining_money.ToString());
                                instance.ModDatabase(cardNumber, final_money_transfer.ToString());
                                Console.WriteLine("Transferencia realizada con éxito \n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error, ingrese el numero de tarjeta correctamente \n");
                        }
                        break;
                    case 5:
                        //Salir
                        Console.Write("Gracias por usar nuestros " +
                                      "servicios, hasta pronto \n");
                        Message();
                        flag = true;
                        break;
                    default:
                        Console.WriteLine("Por favor, elige una " +
                                          "opción válida \n");
                        break;
                }
            }
        }

        public void Message()
        {
            Console.WriteLine(
                @"
                

                                  \\\\\\\////
                             \\//\/\\\\\\\///
                           \\\`      \\\\\\///
                          \\       ||\      \
                          \  \\   //     _\  `\
                         /  /. \  \\    /O.    `\,
                        //  |__\\ //\         . __\
                      /`           //\\      , .\ /
                     \\\\          //\        ___|
                    ////\\            \\     `   \
                  //////////\\\\       //__       |
                 |`  \\\//////\\        \_ \______|
                 |     \\\\//\\/////\\\   \
                ./      \\\\////////\\     |\
                |        \\\\////\\//\\\\\\\\
                |          \\\///      \\\\\\
                |          \\\//         \//
                |            \/        \ |
                |             `         \|
                | |                      \                       /
                | |           \           \                     //
                | |                        \                   ////
                | |             .          `|                 /////
                | |                         `\                \\////
                 \`|                          `|              \\||/
                  | |             \            `|  ,--.         \ \,
                  |  \                          |./    `\        | |
                   |  |                                 |        | |
                   |___|            .                   |        | |
                   /   |                                |        | |
                   |    |                               ;        | |
                   |                                    |        | |
                 __|                                   /`       /` ;
                /   \                          ,      ; \     ,` ,/
                \____\              \       \,/__________|__.' ,`
                      \______________\_______________________.'
                "
            );
        }
    }
}