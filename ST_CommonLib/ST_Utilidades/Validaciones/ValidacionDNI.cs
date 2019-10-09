using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Text;

namespace ST.Utilidades.Validaciones
{
    public class ValidacionDNI
    {
        /// <summary>
        /// Comprueba que se trate de un DNI válido, comprobando la parte numérica contra la letra de validación.
        /// </summary>
        /// <param name="dni">Número de dni con su letra, el formato puede ser:
        ///                                                         nn.nnn.nnnX
        ///                                                         nn.nnn.nnn-X
        ///                                                          n.nnn.nnnX
        ///                                                          n.nnn.nnn-X
        ///        Siendo n números y X la letra, y sin los puntos</param>
        /// <returns></returns>
        public static bool Validar(string dni)
        {
            int nDni = -1;
            string letrasValidas = "TRWAGMYFPDXBNJZSQVHLCKE"; //letras validas
            string letra = string.Empty;

            if (dni.Length < 8 || !cargaVariablesDni(dni, ref nDni, ref letra))
                return false;

            nDni = nDni % 23;//realizo el modulo 23 del número.

            if (letra == letrasValidas[nDni].ToString())
                return true;
            else
                return false;
        }

        /// <summary>
        /// Devuelve el DNI en formato xx.xxx.xxxL
        /// es decir, 9.543.212-H => 09543212H
        /// </summary>
        public static string GetDNIFormatoValido(string dni)
        {
            //Primero comprobamos si es un dni valido, sino, saca excepción de invalid formato
            if (!Validar(dni))
                throw new ValidationException($"El DNI introducido ({dni}) no tiene un formato válido");

            string letra = string.Empty;
            int numero = 0;
            cargaVariablesDni(dni, ref numero, ref letra);

            return numero.ToString("0#######") + letra.ToUpper ();
        }

        private static bool cargaVariablesDni(string dni, ref int nDni, ref string letra)
        {
            //si tiene puntos tipo 9.431.321-G, se los quitamos
            dni = dni.Replace(".", "");
            switch (dni.Length)
            {
                case 8:
                    if (!int.TryParse(dni.Substring(0, 7), out nDni))
                        return false;
                    else
                    {
                        letra = dni.Substring(7);
                        return true;
                    }

                case 9:
                    letra = dni.Substring(8);
                    if (!int.TryParse(dni.Substring(0, 8), out nDni))
                        if (!int.TryParse(dni.Substring(0, 7), out nDni))
                            return false;

                    return true;

                case 10:
                    letra = dni.Substring(9);
                    if (!int.TryParse(dni.Substring(0, 9), out nDni))
                        if (!int.TryParse(dni.Substring(0, 8), out nDni))
                            return false;
                                        
                    return true;

                case 11:
                    letra = dni.Substring(10);
                    if (!int.TryParse(dni.Substring(0, 10), out nDni))
                        if (!int.TryParse(dni.Substring(0, 9), out nDni))
                            return false;
                    
                    return true;

                default:
                    return false;
            }
        }
    }
}
