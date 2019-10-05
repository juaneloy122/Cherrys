using System;
using System.Collections.Generic;
using System.Text;

namespace ST.Utilidades.Log
{
    public class MsgLog
    {
        #region Atributos y propiedades
        public string Msg = string.Empty;
        enum TipoLog { Normal, Debug, Error, Advertencia, Fatal };
        TipoLog Tipo { get; set; } = TipoLog.Normal;
        #endregion

        #region Constructor
        public MsgLog() { }
        public MsgLog(string titulo)
        {
            Msg = titulo;
        }
        #endregion

        #region Metodos publicos
        #region Normal
        /// <summary>
        /// inserta una línea en blanco
        /// </summary>
        public void AddLinea()
        {
            Msg += "\n";
        }

        /// <summary>
        /// inserta una línea 
        /// </summary>
        public void AddLinea(object msg)
        {
            AddLinea(msg.ToString());
        }

        /// <summary>
        /// inserta una línea 
        /// </summary>
        public void AddLinea(string msg)
        {
            Msg += Ctes_Log.PROCESO + msg;
        }

        /// <summary>
        /// inserta una línea [identificador] + msg
        /// </summary>
        public void AddLinea(string identificador, string msg)
        {
            AddLinea ($"[{identificador}] {msg}");
        }

        /// <summary>
        /// inserta una línea que empieza por un mensaje personal
        /// Msg += Log.Personal (identificador) + msg;
        /// </summary>
        public void AddLinea(object identificador, string msg)
        {
            AddLinea(identificador.ToString(), msg);
        }

        /// <summary>
        /// inserta una línea de titulo si no hay y sino una linea de info normal
        /// 
        /// </summary>
        public void AddLineaOTitulo(string msg)
        {
            if (string.IsNullOrEmpty(Msg))
                Msg = msg;
            else
                AddLinea(msg);
        }

        // <summary>
        /// inserta una el titulo si no hay todavía, si ya hay no hace nada
        /// 
        /// </summary>
        public void AddTituloSinoHay(string msg)
        {
            if (string.IsNullOrEmpty(Msg))
                Msg = msg;
        }
        #endregion

        #region Init

        /// <summary>
        /// inserta una línea con prefijo "INIT"
        /// </summary>
        public void AddInit(string msg)
        {
            Msg += Ctes_Log.INIT + msg;
        }

        /// <summary>
        /// inserta una línea con prefijo "INIT"
        /// INIT --> [identificador] + msg
        /// </summary>
        public void AddInit(string identificador, string msg)
        {
            AddInit ( $"[{identificador}] {msg}");
        }
        #endregion

        #region Config

        /// <summary>
        /// inserta una línea de debug que empieza por un mensaje personal
        /// Msg += LogProcesos.Debug (identificador) + msg;
        /// </summary>
        public void AddConfig(string msg)
        {
            Msg += Ctes_Log.CONFIG + msg;
        }

        /// <summary>
        /// inserta una línea debug que empieza por un mensaje personal
        /// Msg += Log.PersonalDebug (identificador) + msg;
        /// </summary>
        public void AddConfig(string identificador, string msg)
        {           
            AddConfig($"[{identificador}] {msg}");
        }
        #endregion

        #region Debug

        /// <summary>
        /// inserta una línea de debug que empieza por un mensaje personal
        /// Msg += LogProcesos.Debug (identificador) + msg;
        /// </summary>
        public void AddDebug(string msg)
        {
            if (Tipo == TipoLog.Normal)
                Tipo = TipoLog.Debug;

            Msg += Ctes_Log.DEBUG + msg;
        }

        /// <summary>
        /// inserta una línea debug que empieza por un mensaje personal
        /// Msg += Log.PersonalDebug (identificador) + msg;
        /// </summary>
        public void AddDebug(string identificador, string msg)
        {           
            AddDebug($"[{identificador}] {msg}");
        }
        #endregion

        #region Trace

        /// <summary>
        /// inserta una línea de debug que empieza por un mensaje personal
        /// Msg += LogProcesos.Debug (identificador) + msg;
        /// </summary>
        public void AddAdvertencia(string msg)
        {
            if (Tipo == TipoLog.Normal || Tipo == TipoLog.Debug)
                Tipo = TipoLog.Advertencia;

            Msg += Ctes_Log.TRACE + msg;
        }

        /// <summary>
        /// inserta una línea debug que empieza por un mensaje personal
        /// Msg += Log.PersonalDebug (identificador) + msg;
        /// </summary>
        public void AddAdvertencia(string identificador, string msg)
        {           
            AddAdvertencia($"[{identificador}] {msg}");
        }
        #endregion

        #region Error

        /// <summary>
        /// inserta una línea debug que empieza por un mensaje personal
        /// Msg += Log.ExceptionError(identificador,e);
        /// </summary>
        public void AddError(string identificador, Exception e)
        {
            AddError(Log.GetExceptionError(identificador, e));
        }

        /// <summary>
        /// inserta una línea debug que empieza por un mensaje personal
        /// Msg += LogProcesos.Error + msg;
        /// </summary>
        public void AddError(string msg)
        {
            if (Tipo != TipoLog.Fatal)
                Tipo = TipoLog.Error;

            Msg += Ctes_Log.ERROR + msg;
        }

        /// <summary>
        /// inserta una línea debug que empieza por un mensaje personal
        /// Msg += Log.PersonalError(identificador) + msg;
        /// </summary>
        public void AddError(object identificador, string msg)
        {
            identificador = identificador == null ? "Null" : identificador.ToString();           
            AddError($"[{identificador}] {msg}");
        }

        /// <summary>
        /// inserta una línea debug que empieza por un mensaje personal
        /// Msg += Log.PersonalError(identificador) + msg;
        /// </summary>
        public void AddError(string identificador, string msg, string exMsg)
        {  
            AddError($"[{identificador}] {msg}\n{exMsg}");
        }
        #endregion

        /// <summary>
        /// Escribe el mensaje en el log
        /// </summary>
        public void Escribir()
        {
            switch (Tipo)
            {
                case TipoLog.Normal:
                    Log.AddNormal(Msg);
                    break;
                case TipoLog.Debug:
                    Log.AddDebug(Msg);
                    break;
                case TipoLog.Error:
                    Log.AddCritical(Msg);
                    break;
                case TipoLog.Fatal:
                    Log.AddHigh(Msg);
                    break;
                case TipoLog.Advertencia:
                    Log.AddAvertencia(Msg);
                    break;
                default:
                    Log.AddNormal(Msg);
                    break;
            }

            Msg = string.Empty;
            Tipo = TipoLog.Normal;
        }

        /// <summary>
        /// Escribe el mensaje en el log
        /// </summary>
        public void Escribir(string titulo)
        {
            if (!String.IsNullOrEmpty(Msg))
                Msg = titulo + Msg;

            Escribir();
        }

        public bool EstaVacio()
        {
            return (String.IsNullOrEmpty(Msg));
        }
        #endregion

    }
}
