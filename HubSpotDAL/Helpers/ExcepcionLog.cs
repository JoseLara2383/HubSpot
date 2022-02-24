using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace HubSpotDAL.Helpers
{
    class ExcepcionLog
    {
        public static void WriteLog(string Metodo, Exception ex)
        {
            try
            {
                //Obtiene la fecha
                string fecha = System.DateTime.Now.ToString("yyyyMMdd");
                //Obtiene la hora
                string hora = System.DateTime.Now.ToString("HH:mm:ss");
                //Obtemos la ruta y lo concatenamos con la fecha y txt es decir diario creara un archivo pero si
                //se detoman mas de una vez solo escribe en el actual de la fecha.
                string path = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), fecha + ".txt");
                Console.WriteLine("path log::::" + path);
                // Console.ReadLine();
                //Instancia de StreamWriter
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    StackTrace stacktrace = new StackTrace();
                    //Escribimos
                    sw.WriteLine(string.Format("{0} - {1}", Metodo, hora));
                    sw.WriteLine(string.Format("{0} - {1}", stacktrace.GetFrame(1).GetMethod().Name, ex.Message));
                    sw.WriteLine("----------------------------------------------");
                    sw.Flush();
                }
            }
            catch (Exception)
            {

                //throw;
            }

        }

        public static void WriteLog(string Process, string mensaje)
        {
            try
            {
                ExcepcionLog.WriteLog(Process, new Exception(mensaje));
            }
            catch (Exception)
            {

            }
        }

    }
}
