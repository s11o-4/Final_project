using System;
using DateComprobation;
using Bank;
using PasswordValidation;
using CVCValidation;
using Options;
using Verify;

namespace Cards
{
    public class InicioDeSesion
    {
        public static string cardNumber;
        public static string name = "";
        bool pass = false;
        int password = 0;
        int CVC = 0;
        public static DateTime date = DateTime.MinValue;

        //nuestro metodo CardVerify
        public void CardVerify()
        {

            Console.WriteLine(
                @"
┌─────────────────────────────────────────────────────────────────────────┐
│                                                                         │
│                                                                         │
│                        Bienvenido a LionBank                            │
│                                                                         │
│                                                                         │
│    Iniciando sesión...                                                  │
│                                                                         │
                .u:o. -c:o.  ex::u.    .czeez* .edB$ e@$$eu
              e$MMMMMNu^$MMMb.#BMMM$c $MMM8P.d$RM$F4RMMMMMMRb
            A$MMMMMMMMRb^$MMMMb^$MMMP MMMMF4$MMM8'dRMMMMMMMMMN
            zMM8M***M$8M$.#8MMM$.$8M&J$M$%$RMM8*.$R8$#'''''BMM
            $$'.e@Rmu. '*M'    '    ^^             .o$$RMM$c'$
            $.$RMMMMMM$$$$ dRRRRRRRRRR$$MMMMMMRL'$$RMMMMMMMM$.
            .$MMMMMMMMM$' $RMMMMMMMMMMMMMMMMMMMMb ^4$MMMMMMMM$
            JMMMM$$**' ..$MMMMMMMMMMMMMMMMMMMMMMM$.:c  '***$MM
            $M'..oenR$'.$MMMMMMMMMMMMMMMMMMMMMMMMM$.*$$MMMRc.*
            * d$MMMM$'u$MMMMMMMMMMMMMMMMMMMMMMMMM8MRc'$MMMMM$b
            .$RMMM$# J$MF       'MMMMMMMMM   .....4M$b '$MMMM$
            dMM8P'  dMMM$ $M8P4 4MMMMMMMMM 'L'$M$ JMMMF  '*88M
            $$P\d$$ $MMMM$L..d$r4MMMMMMMMM <$$u.e$RMMMF $M$c'$
            $ zRMM& ^8MMMMMMMMMF'MMMMMMMMM 4MMMMMMMMMG  $MMM$r
             $RMMMF$f)MMMMMMMMMF'MMMMMMMMM 4MMMMMMMMMF.$'$MMMM
            'MMM$FJR$ $MMMMMMMMF4MMMMMMMMM 4MMMMMMMM$ $Rh^$MMM
            AMM8\dRMMF RMMMMMMM 4MMMMMMMMM  MMMMMMM$'.MMMRb$MM
            AM$.$MMMMF.3MMMM$P*-'*********- '*NMMMM*..RMMMM$'$
            AP.$RMMM$:$ $M$'.oM$.'$RRRRR$'.d$5u'*M$ $$?RMMMM$'
            $ $MMMM$\$Rb'P eMMMMM$c'$M8# dRMMMMRc'F4MMb^$MMMMb
             $RMMMPzRMM!  eRMMMMMMR$c' dRMMMMMMMR  'MMMR.?$MM$
             $M8$ $MMMM'x $MMMMMMMMMM ?MMMMMMMMM$ 3'$MMM$b'$MM
            ARM$.$RMMMP $$'BMMMMMMMMM 4MMMMMMMM8P4$$ $MMMM$.$M
            A$F4RMMMMf $RM  *88MMM88M J8MM888$$\ @MMMr5MMMM$.$
             $ $RMM8P.$MMMF?b.                z$F$MMMMc3BMMM$'
              4MMMM$-$RMM8F4MM$ '8MMMMMMMM$ dRMM$#8MMM$r#8MMM.
              4MMM$.$MMMM$ RMMM$ <MMMMMMMP' MMMMM>3MMMM$ 8MMM
               $MM$'MMMMP zRMMM$ .'**4P*'.$ $MMMM$'$MMMM $MM$
               4MMC'MMMM$:$MMMMPoM$b   .@$M$$MMMMRL^$MMMF$M8
                '$$'MMM$\$MMMM$ MMMM$.4RMMM$r$MMMMRr*MMMN$$'
                 'N'$MM$4$MMMMF$MMMMM$$RMMMM$4$MMMM$$MMM @
                    #$MN4MMMMMF$MMMMM$#MMMMMM RMMMM$$M$F
                     ?$$.$MMMMF$MMMMMF RMMMMM $MMMM\$MP
                       *$'$MMMb3MMMMM  RMMMMNJRMMNFJ*
                            #88$L#8MMMr RMMM$z$M8$'
                             ^*$P/*B8$$R8M'zP*'
│                                                                         │
└─────────────────────────────────────────────────────────────────────────┘

                             
                "
            );

            //Creamos una instancia a las clases FechaC, PassV, CVCV, Menu y DatabaseManager
            FechaC recibiendo = new FechaC();
            PassV recibiendo2 = new PassV();
            CVCV recibiendo3 = new CVCV();
            DatabaseManager recibiendo4 = new DatabaseManager();
            Menu recibiendo5 = new Menu();

            //contador
            int i = 0;
            //hacer mientras
            do
            {
                Console.WriteLine("Ingrese su número " +
                                  "de tarjeta para iniciar sesión:");
                cardNumber = Console.ReadLine();
                //Comprueba si el usuario existe
                if(recibiendo4.GetData(cardNumber, cardNumber) != null)
                {
                    //Si existe almacenará los datos del usuario en la sesion de programa actual
                    pass = true;
                    name = recibiendo4.GetData(cardNumber, "nombre");
                    date = Convert.ToDateTime(recibiendo4.GetData(cardNumber, "fecha_vencimiento"));
                    password = Int32.Parse(recibiendo4.GetData(cardNumber, "pin"));
                    CVC = Int32.Parse(recibiendo4.GetData(cardNumber, "cvc"));
                    i = 4;
                }
                else
                {
                     Console.WriteLine("Numero de tarjeta " +
                                          " inexistente, intente" +
                                          " nuevamente");
                }
                if (pass)
                {
                    Console.WriteLine("Bienvenido " + name);
                }
                //contador +1  
                i++;
            } while (i < 3);
            //3 intentos permitiodos, si el contador es menor a 3 se repite el ciclo

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
            recibiendo5.Options();
        }
    }
}
