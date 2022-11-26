using System;
using Cards;
using Bank;
namespace CVCValidation
{
    public class CVCV
    {
        public bool CompareCVC(int CVCUser)
        {
            int enteredCVC;
            int contadorCVC = 0;
            bool pass4 = true;
            do
            {
                Console.WriteLine("Ingrese su CVC para continuar");
                enteredCVC = Int32.Parse(Console.ReadLine());
                if (enteredCVC == CVCUser)
                {
                    contadorCVC = 4;
                    pass4 = true;
                }
                else
                {
                    Console.WriteLine("CVC incorrecto, " +
                                      "intente nuevamente");
                    contadorCVC++;
                }
            } while (contadorCVC < 3);

            if (contadorCVC == 3)
            {
                pass4 = false;
            }

            return pass4;
        }
    }
}