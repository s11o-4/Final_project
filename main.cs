using System;
using Cards;
using DateComprobation;
using PasswordValidation;
using CVCValidation;
//ubicacion logica
namespace Bank
{
    //clase de programa
    class Program
    {
        //metodo o funcion
        static void Main(string[] args)
        {
            //variable del metodo o funcion
            //Aqui llamamos a la clase de IniScio de sesion
            InicioDeSesion call = new InicioDeSesion();
            //Aqui se va ejecutar el metodo de CardVerify
            call.CardVerify();
        }
    }
}