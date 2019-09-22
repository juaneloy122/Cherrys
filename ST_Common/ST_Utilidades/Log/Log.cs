using System;
using System.Collections.Generic;
using System.IO;
using Serilog;
using Serilog.Core;
using ST_Utilidades.Comunicaciones;
using ST_Utilidades.Constantes;

namespace ST_Utilidades.Log
{
    public static class Log
    {
        #region Propiedades
       
        public static bool PRODUCCION = true;
        public static bool LanzarAlertas = true;

        /// <summary>
        /// Indica el nombre del proceso que está generando el log
        /// </summary>
        public static string NombreProceso = string.Empty;
        #endregion

        #region Init y Close

        public static void InitLog (string pathFichero, string proceso)
        {
            try
            {
                NombreProceso = proceso;

                Serilog.Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Console()
                    .WriteTo.File(pathFichero, rollingInterval: RollingInterval.Day)
                    .CreateLogger();

                AddLineasVacias(5);
                AddNormal("INICIANDO...");
                AddNormal("INICIANDO...");
                AddNormal("INICIANDO...");
                AddNormal("INICIANDO...");
                AddNormal("INICIANDO...");
                MsgLog msg = new MsgLog("INICIO DE PROCESO");
                msg.AddInit("Usuario: " + Environment.UserName);
                msg.Escribir();

            }
            catch 
            {
                Console.Error.WriteLine("Error al inicializar el log");
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
                List<string> direcciones = new List<string>();
                direcciones.Add(Administradores.GetEmailAdministradorCherry(user));
                            

                AddAlerta(direcciones, asunto, mensaje, nombreProcesoEnElasunto, nombreConFechaEnCuerpo);
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
                try
                {
                    if (!LanzarAlertas)
                        return;

                    string proceso = NombreProceso;
                    string onlineBackup2 = PRODUCCION ? "PRODUCCION" : "DEVELOP";
                    string procesoSinFormato = proceso + " - " + onlineBackup2;
                    string onlineBackup = PRODUCCION ? getHTML("h1", "red", "[" + proceso + " - PRODUCCION]") : getHTML("h1", "blue", "[" + proceso + " - DEVELOP]");
                    string titulo = string.Empty;
                    string fechaMasProceso = getHTML("h3", "grey", "[" + procesoSinFormato + " - " + DateTime.Now.ToString() + "]");
                    string fecha = getHTML("h3", "grey", "[" + DateTime.Now.ToString() + "]");

                    mensaje = mensaje.Replace("\\.", "");
                    mensaje = mensaje.Replace("\n", "<br>");
                    mensaje = mensaje.Replace(";", "<br>");


                    //procedimiento
                    if (mensaje.Contains("[") && mensaje.Contains("]") && mensaje.IndexOf('[') < 5)
                    {
                        int inicio = mensaje.IndexOf('[') + 1;
                        int final = mensaje.IndexOf(']');
                        titulo = getHTML("h2", "black", mensaje.Substring(inicio, final - inicio));
                        mensaje = mensaje.Substring(final + 1);
                    }

                    //mensaje = onlineBackup + titulo + mensaje + fecha;
                    mensaje = nombreConFechaEnCuerpo ? mensaje + fechaMasProceso : mensaje + fecha;
                    asunto = nombreProcesoEnElasunto ? proceso + " --> " + asunto : asunto;

                    EnvioMail envioEmail = new EnvioMail(direccionesEmail.ToArray(), asunto, mensaje);                   
                    envioEmail.DisplayName = "Log Cherrys";
                    envioEmail.EnviarEmail();

                    AddNormal("Alerta " + asunto);
                }
                catch (Exception ex)
                {
                    AddCritical("AddAlerta", ex);
                }
            }

        static Dictionary<string, DateTime> _UltimasAlertas = new Dictionary<string, DateTime>(10);
        private static void lanzarAlerta(string mensaje)
        {
            try
            {

                if (!mensaje.Contains("\\.") || !LanzarAlertas)
                    return;

                if (!comprobarUltimoEnvio(mensaje))
                    return;

                string proceso =NombreProceso;
                string onlineBackup2 = PRODUCCION ? "PRODUCCION" : "DEVELOP";
                string onlineBackup = PRODUCCION ? getHTML("h1", "red", "[" + proceso + " - ONLINE]") : getHTML("h1", "blue", "[" + proceso + " - DEVELOP]");
                string titulo = string.Empty;
                string fecha = getHTML("h3", "grey", "[" + DateTime.Now.ToString() + "]");

                mensaje = mensaje.Replace("\\.", "");
                mensaje = mensaje.Replace("\n", "<br>");
                mensaje = mensaje.Replace(";", "<br>");


                //procedimiento
                if (mensaje.Contains("[") && mensaje.Contains("]") && mensaje.IndexOf('[') < 5)
                {
                    int inicio = mensaje.IndexOf('[') + 1;
                    int final = mensaje.IndexOf(']');
                    titulo = getHTML("h2", "black", mensaje.Substring(inicio, final - inicio));
                    mensaje = mensaje.Substring(final + 1);
                }

                mensaje = onlineBackup + titulo + mensaje + fecha;
                EnvioMail envioEmail = new EnvioMail(Administradores.GetEmailAdministradorCherry(EnumAdministradoresCherrys.Todos), proceso + " --> ERROR FATAL " + onlineBackup2, mensaje);
                
                envioEmail.DisplayName = "Log Cherrys";
                envioEmail.EnviarEmail();

            }
            catch (Exception ex)
            {
                AddCritical("lanzarAlerta", ex);
            }
        }

        private static string getHTML(string etiqueta, string color, string texto)
        {
            return "<" + etiqueta + " style=\"color:" + color + ";\">" + texto + "</" + etiqueta + ">";
        }

        private static bool comprobarUltimoEnvio(string mensaje)
        {
            string clave = mensaje.Length > 22 ? mensaje.Substring(2, 20) : mensaje.Substring(2);
            if (_UltimasAlertas.ContainsKey(clave) && DateTime.Now.Subtract(_UltimasAlertas[clave]).TotalMinutes < 180)
                return false;
            else
            {
                if (_UltimasAlertas.ContainsKey(clave))
                    _UltimasAlertas[clave] = DateTime.Now;
                else
                    _UltimasAlertas.Add(clave, DateTime.Now);

                return true;
            }
        }
        #endregion

        #region Critical        
        /// <summary>
        /// Añade una traza de error formateando un poco la traza
        /// </summary>
        public static void AddCritical(string mensaje, Exception ex)
        {
            mensaje += "\n" + GetExceptionError(ex);
            Serilog.Log.Error(ex, $"[{NombreProceso}] {getMensaje(mensaje)}");
           
            lanzarAlerta(mensaje + "\n" + ex.Message);

        }

        /// <summary>
        /// Añade una traza de error
        /// </summary>
        public static void AddCritical(string mensaje)
        {
            Serilog.Log.Error(getMensaje(mensaje));
            lanzarAlerta(mensaje);
        }
        #endregion


        #region Normal
            
        /// <summary>
        /// Añade líneas en blanco, tantas como se indique en el argumento
        /// </summary>
        public static void AddLineasVacias (int nLineas)
        {
            while (nLineas >0)
            {
                Serilog.Log.Information(string.Empty);
                nLineas--;
            }
        }
        /// <summary>
        /// Añade una traza normal
        /// </summary>
        public static void AddNormal(string mensaje)
        {
            if (mensaje == string.Empty)
                return;
           
            Serilog.Log.Information( $"[{NombreProceso}] {getMensaje(mensaje)}");
            
        }

        /// <summary>
        /// Añade una traza normal
        /// </summary>
        public static void AddNormal(string metodo, string mensaje)
        {
            mensaje = "[" + metodo + "] " + mensaje;

            AddNormal(mensaje);
        }

        #endregion

        #region Debug


        /// <summary>
        /// Añade una traza de debug
        /// </summary>
        public static void AddDebug(string mensaje)
        {
            Serilog.Log.Debug($"[{NombreProceso}] {getMensaje(mensaje)}");

        }

        /// <summary>
        /// Pone un mensaje donde incluye la diferencia de tiempo actual con la que se pasa como referencia
        /// </summary>
        public static void AddDiffTime(string mensaje, DateTime tiempoRef)
        {
            AddDebug(mensaje + " TIEMPO (segundos): " + DateTime.Now.Subtract(tiempoRef).TotalSeconds);
        }

        #endregion

        #region Trace

       
        /// <summary>
        /// Añade una traza de tipo trace
        /// </summary>
        public static void AddAvertencia(string mensaje)
        {
            Serilog.Log.Warning($"[{NombreProceso}] {getMensaje(mensaje)}");
        }

        #endregion

        #region High


        /// <summary>
        /// Añade una traza de tipo High
        /// </summary>
        public static void AddHigh(string mensaje)
        {
            Serilog.Log.Fatal($"[{NombreProceso}] {getMensaje(mensaje)}");
            lanzarAlerta(mensaje);
        }

        #endregion

        ///// <summary>
        ///// Añade el texto al mensaje que ya hay, pero no lo manda al fichero ni a la BD hasta que no se hace flush.
        ///// </summary>
        ///// <param name="mensaje"></param>
        //public static void AcumulaLog(string mensaje)
        //    {
        //        MSG.Msg += mensaje;

        //        if (MSG.Msg.Length > 10000)
        //        {
        //            MSG.AddError("EL ACUMULA LOG SE ESTA EXCEDIENDO EN SU LONGITUD (" + MSG.Msg.Length + "), SE HACE EL FLUSH");
        //            MSG.Escribir();
        //        }
        //    }

        ///// <summary>
        ///// \n mensaje personal --> 
        ///// </summary>
        ///// <param name="msgPersonal"></param>
        ///// <param name="etiqueta"></param>
        ///// <returns></returns>
        //public static string GetMsgPersonal(string msgPersonal)
        //{
        //    return GetMsgPersonal(msgPersonal, NivelLog.NORMAL);
        //}

        ///// <summary>
        ///// \n Etiqueta mensaje personal --> (nivel log)
        ///// </summary>
        //public static string GetMsgPersonal(string msgPersonal, NivelLog nivel)
        //{
        //    string etiqueta = nivel == NivelLog.NORMAL ? " " : nivel.ToString();
        //    return string.Format("\n{0,-" + Ctes_Log.ESPACIOS_LABEL + "}{1," + getTabTotal(msgPersonal) + "}{2," + (-1) * msgPersonal.Length + "}", etiqueta, " ", msgPersonal) + Ctes_Log.LABEL_FLECHITA;
        //}

        /// <summary>
        /// e.message + "ERROR" + e.stacktrace
        /// </summary>
        public static string GetExceptionError(Exception e)
        {
            return e.Message + Ctes_Log.ERROR + e.StackTrace;
        }

        /// <summary>
        /// ERROR + "[metodo]" + e.message + "ERROR" + e.stacktrace
        /// </summary>        
        public static string GetExceptionError(string nombreMetodo, Exception e)
        {
            return "[" + nombreMetodo + "] " + GetExceptionError(e);
        }
        #region Funciones privadas

        private static string getMensaje(string msg)
        {
            if (String.IsNullOrEmpty(msg))
                return string.Empty;
            else
                return msg.Replace('á', 'a').Replace('é', 'e').Replace('í', 'i').Replace('ó', 'o').Replace('ú', 'u').Replace('Á', 'A').Replace('É', 'E').Replace('Í', 'I').Replace('Ó', 'O').Replace('Ú', 'U').Replace("Ñ", "NY").Replace("ñ", "ny").Replace(';', '\n');

        }



        #endregion

        #endregion
    }
}
