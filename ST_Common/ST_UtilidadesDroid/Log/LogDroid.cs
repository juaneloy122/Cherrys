using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Serilog;
using ST_Utilidades.Comunicaciones;
using ST_Utilidades.Constantes;
using ST_Utilidades.Log;
using ST_UtilidadesDroid.IO;
using static Android.Provider.SyncStateContract;

namespace ST_UtilidadesDroid.Log
{
    public static class Log 
    {
        public static string PathLogs { get; set; } = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        #region Constructor
        const string KUMQUAT = "KUMQUAT: ";
       
        public static void InitLog(string proceso)
        {
            try
            {
                ST_Utilidades.Log.Log.NombreProceso = proceso;
                string pathLog = PathLogs;
                
                //global::Android.OS.Environment.ExternalStorageDirectory.Path

                Console.WriteLine(KUMQUAT + pathLog);
                Console.WriteLine(KUMQUAT + Path.Combine(pathLog, "Kumquat01.txt"));
                Serilog.Log.Logger = new LoggerConfiguration()
                             .WriteTo.File(Path.Combine(pathLog, "Kumquat-{Date}.txt")
                             //.WriteTo.File(Path.Combine(pathLog, "Kumquat01.txt")
                            , outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] [{SourceContext}] {Message}{NewLine}{Exception}")
                            .WriteTo.AndroidLog()
                            .CreateLogger();
            }
            catch
            {
                Console.Error.WriteLine(KUMQUAT + "Error al inicializar el log");
            }

        }

        public static void CloseAndFlush()
        {
            Serilog.Log.Information("Se cierra el log y se vacía");
            Serilog.Log.CloseAndFlush();
        }
        #endregion

        #region Metodos publicos

        #region Alertas


        /// <summary>
        /// Manda un email al usuario indicado con ese asunto y ese mensaje, es necesario que la propiedad "LanzarAlertas" este a true
        /// </summary>
        public static void AddAlerta(EnumAdministradoresCherrys user, string asunto, string mensaje, bool nombreProcesoEnElasunto = false, bool nombreConFechaEnCuerpo = false)
        {
            ST_Utilidades.Log.Log.AddAlerta(user,  asunto,  mensaje,  nombreProcesoEnElasunto ,  nombreConFechaEnCuerpo );
        }

        /// <summary>
        /// Manda un email al usuario indicado con ese asunto y ese mensaje, es necesario que la propiedad "LanzarAlertas" este a true
        /// </summary>
        /// <param name="user">Usuario al que se envía la alerta</param>
        /// <param name="asunto">Asunto del mensaje</param>
        /// <param name="mensaje">Cuerpo del email</param>
        /// <param name="nombreProcesoEnElasunto">Por defecto no pone en el asunto el nombre del proceso que está lanzando la alerta</param>
        /// <param name="nombreConFechaEnCuerpo">Por defecto no pone el nombre del proceso y la fecha en el cuerpo</param>
        public static void AddAlerta(List<string> direccionesEmail, string asunto, string mensaje, bool nombreProcesoEnElasunto = false, bool nombreConFechaEnCuerpo = false)
        {
            ST_Utilidades.Log.Log.AddAlerta(direccionesEmail, asunto, mensaje, nombreProcesoEnElasunto, nombreConFechaEnCuerpo);
        }
       
        #endregion

        #region Critical        
        /// <summary>
        /// Añade una traza de error formateando un poco la traza
        /// </summary>
        public static void AddCritical(string mensaje, Exception ex)
        {
            ST_Utilidades.Log.Log.AddCritical(mensaje, ex);
        }

        /// <summary>
        /// Añade una traza de error
        /// </summary>
        public static void AddCritical(string mensaje)
        {
            ST_Utilidades.Log.Log.AddCritical(mensaje);
        }
        #endregion


        #region Normal

        /// <summary>
        /// Añade líneas en blanco, tantas como se indique en el argumento
        /// </summary>
        public static void AddLineasVacias(int nLineas)
        {
            ST_Utilidades.Log.Log.AddLineasVacias(nLineas);
        }
        /// <summary>
        /// Añade una traza normal
        /// </summary>
        public static void AddNormal(string mensaje)
        {
            ST_Utilidades.Log.Log.AddNormal(mensaje);

        }

        /// <summary>
        /// Añade una traza normal
        /// </summary>
        public static void AddNormal(string metodo, string mensaje)
        {
            ST_Utilidades.Log.Log.AddNormal(metodo, mensaje);
        }

        #endregion

        #region Debug


        /// <summary>
        /// Añade una traza de debug
        /// </summary>
        public static void AddDebug(string mensaje)
        {
            ST_Utilidades.Log.Log.AddDebug(mensaje);

        }

        /// <summary>
        /// Pone un mensaje donde incluye la diferencia de tiempo actual con la que se pasa como referencia
        /// </summary>
        public static void AddDiffTime(string mensaje, DateTime tiempoRef)
        {
            ST_Utilidades.Log.Log.AddDiffTime(mensaje, tiempoRef);
        }

        #endregion

        #region Trace


        /// <summary>
        /// Añade una traza de tipo trace
        /// </summary>
        public static void AddAvertencia(string mensaje)
        {
            ST_Utilidades.Log.Log.AddAvertencia(mensaje);
        }

        #endregion

        #region High


        /// <summary>
        /// Añade una traza de tipo High
        /// </summary>
        public static void AddHigh(string mensaje)
        {
           
            try
            {
                CloseAndFlush();   

                ST_Utilidades.Log.Log.AddHigh(mensaje);

                //Adjuntamos el log en un fichero y lo mandamos por email y al servidor
                string fileZip = getZipLogFiles();
                mandarLogsPorEmail(fileZip);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine ("Logger was unable to upload the log files.", ex);
            }
            
        }

        private static void mandarLogsPorEmail(string fileZip)
        {
            EnvioMail mail = new EnvioMail();
            List<Attachment> adjuntos = mail.AdjuntarArchivos(new string[] { fileZip }, "application/zip");
            string direccion = Administradores.GetEmailAdministradorCherry(EnumAdministradoresCherrys.Todos);
            mail.DireccionesReceptores = new string[] { direccion };
            mail.Asunto = "Error Fatal en " + ST_Utilidades.Log.Log.NombreProceso;
            mail.Cuerpo = "Se adjuntan los ficheros con el log";

            mail.EnviarEmail(adjuntos);
        }

        #endregion


        #region Funciones privadas
        private static string getZipLogFiles()
        {
            string fileZip = Path.Combine(PathLogs, "Prueba.zip");
            string fileLog = Path.Combine(PathLogs, "Kumquat01.txt");

            FileManager fileManager = new FileManager();
            fileManager.ZipFiles(fileZip, new List<string> { fileLog }).Wait();

            return fileZip;
        }
        #endregion

        #endregion
    }
}