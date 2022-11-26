using System;
using Cards;
using Bank;
namespace PasswordValidation
{
    public class PassV
    {
        public bool ComparePass(int passwordUser)
        {
            int enteredPassword;
            int contadorPassword = 0;
            bool pass3 = true;
            do
            {
                Console.WriteLine("Ingrese su pin para continuar");
                enteredPassword = Int32.Parse(Console.ReadLine());
                if (enteredPassword == passwordUser)
                {
                    contadorPassword = 4;
                    pass3 = true;
                }
                else
                {
                    Console.WriteLine("Pin incorrecto, " +
                                      "intente nuevamente");
                    contadorPassword++;
                }
            } while (contadorPassword < 3);

            if (contadorPassword == 3)
            {
                pass3 = false;
            }

            return pass3;
        }
    }
}