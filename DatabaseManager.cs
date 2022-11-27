using System;
using System.IO;

namespace Verify
{
    public class DatabaseManager
    {
        // string path = "..\\Ev3\\database.txt";
        string path = "C:\\Users\\rbnsi\\Downloads\\Final_project\\Final_project-main\\database.txt";

        //Data search no es el dato es el nombre del dato que quiero obtener
        public string GetData(string card_number, string data_search)
        {
            string data = null;
            try
            {
                StreamReader reader = new StreamReader(path);
                data = reader.ReadLine();
                while(data != null)
                {
                    if(data == card_number)
                    {
                        //Leo todo el contenido del usuario una vez que lo identifique por su numero de tarjeta 
                        while(data != "end")
                        {
                            if(data == data_search)
                            {
                                //Leo la siguiente linea para obtener el dato
                                data = reader.ReadLine();
                                reader.Close();
                                return data;
                            }
                            data = reader.ReadLine();
                        }
                        reader.Close();
                        break;
                    }
                    data = reader.ReadLine();   
                }
                reader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return data;
        }
        public void ModDatabase(string CardNumber, string data_mod)
        {
            string db = File.ReadAllText(path);
            //obtengo primero el valor del dato que quiero cambiar y luego lo reemplazo
            db = db.Replace(GetData(CardNumber, "saldo_disp"), data_mod);
            File.WriteAllText(path, db);
        }
    }
}