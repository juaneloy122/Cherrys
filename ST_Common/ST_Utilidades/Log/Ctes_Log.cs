using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Utilidades.Log
{
   
    public class Ctes_Log
    {
        #region Constantes

        public static int ESPACIOS_TAB =21;
        public const int ESPACIOS_LABEL = 15;
        public const string LABEL_FLECHITA = " --> ";
        public const string LABEL_ERROR = "***********    ";
        #endregion

        #region Propiedades
        /// <summary>
        /// "\n" + espacios_tab
        /// </summary>
        public static string N_TAB
        {
            get
            {
                return string.Format("\n{0," + ESPACIOS_TAB + "}", " ");
            }
        }  

        /// <summary>
        /// \n******************** -->
        /// </summary>
        public static string ERROR
        {
            get
            {
                return N_TAB + string.Format("{0," + ESPACIOS_LABEL + "}" + LABEL_FLECHITA, LABEL_ERROR);
            }
        }

        /// <summary>
        /// \n       INIT -->
        /// </summary>
        public static string INIT
        {
            get
            {
                return N_TAB + string.Format("{0," + ESPACIOS_LABEL + "}" + LABEL_FLECHITA, "INIT");
            }
        }

        /// <summary>
        /// \n       CONFIG -->
        /// </summary>
        public static string CONFIG
        {
            get
            {
                return N_TAB + string.Format("{0," + ESPACIOS_LABEL + "}" + LABEL_FLECHITA, "CONFIG");
            }
        }

        /// <summary>
        /// \n       DEBUG -->
        /// </summary>
        public static string DEBUG
        {
            get
            {
                return N_TAB + string.Format("{0," + ESPACIOS_LABEL + "}" + LABEL_FLECHITA, "DEBUG");
            }
        }
        /// <summary>
        /// \n       TRACE -->
        /// </summary>
        public static string TRACE
        {
            get
            {
                return N_TAB + string.Format("{0," + ESPACIOS_LABEL + "}" + LABEL_FLECHITA, "TRACE");
            }
        }

        /// <summary>
        /// \n        -->
        /// </summary>
        public static string PROCESO
        {
            get
            {
                return N_TAB + string.Format("{0," + ESPACIOS_LABEL + "}" + LABEL_FLECHITA, " ");
            }
        }


        #endregion
       
    }

}
