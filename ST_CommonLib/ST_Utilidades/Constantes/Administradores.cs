using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ST.Utilidades.Constantes
{
    public enum EnumAdministradoresCherrys { Josu, Alfonso, Javi, Javichu, Jose, Juan, Moises, Tonyo, Todos}
       

    public class Administradores
    {
        public static string GetEmailAdministradorCherry(EnumAdministradoresCherrys admin)
        {            
            switch (admin)
            {
                case EnumAdministradoresCherrys.Josu:
                    return "";
                case EnumAdministradoresCherrys.Alfonso:
                    return "";
                case EnumAdministradoresCherrys.Javi:
                    return "";
                case EnumAdministradoresCherrys.Javichu:
                    return "";
                case EnumAdministradoresCherrys.Jose:
                    return "";
                case EnumAdministradoresCherrys.Juan:
                    return "";
                case EnumAdministradoresCherrys.Tonyo:
                    return EMAIL_TONYO;
                case EnumAdministradoresCherrys.Todos:
                    return EMAIL_TONYO +";" + EMAIL_JOSU + ";" + EMAIL_ALFONSO + ";" + EMAIL_JAVI + ";" + EMAIL_JAVICHU+ ";" + EMAIL_JUAN + ";" + EMAIL_MOISES + ";" + EMAIL_JOSE;
                default:
                    throw new ArgumentException("[ST_Utilidades.Constantes.GetEmailAdministradorCherry] se ha pasado un argumnento invalido al método: " + admin.ToString());
            }
        }
        

        public const string EMAIL_TONYO = "antonioastur@gmail.com";
        public const string EMAIL_JOSU = "";
        public const string EMAIL_ALFONSO = "";
        public const string EMAIL_JAVI = "";
        public const string EMAIL_JAVICHU = "";
        public const string EMAIL_JUAN = "";
        public const string EMAIL_MOISES = "";
        public const string EMAIL_JOSE = "";

    }
}
