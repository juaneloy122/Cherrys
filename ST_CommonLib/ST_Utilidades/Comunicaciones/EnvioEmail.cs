using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace ST.Utilidades.Comunicaciones
{     

    /// <summary>
    /// Clase que se utiliza para el envío de correos electrónicos.
    /// </summary>
    public class EnvioMail
    {     
        #region PROPIEDADES DE LA CLASE
        /// <summary>
        /// Direcciones a la que se envía el email.
        /// </summary>
        public string[] DireccionesReceptores { get; set; }

        /// <summary>
        /// Direcciones a la que se envía el email de forma oculta (CO).
        /// </summary>
        public string[] DireccionesReceptoresOcultos { get; set; }

       
        /// <summary>
        /// Nombre que se muestra como remitente.
        /// </summary>
        public string DisplayName { get; set; } = "Corales Design";

        /// <summary>
        /// Nombre de usuario que envia el correo
        /// </summary>
        public string DireccionServidor { get; set; } = "sistemas@coralesdesign.es";

        /// <summary>
        /// Clave de gmail.
        /// </summary>
        public string ClaveServidor { get; set; } = "corales0224";

        /// <summary>
        /// Puerto de envío.
        /// </summary>
        public int PuertoEnvio { get; set; } = 26;

        /// <summary>
        /// Servidor de correo SMTP
        /// </summary>
        public string Host { get; set; } = "mail.coralesdesign.es";
               
        /// <summary>
        /// Asunto del email
        /// </summary>
        public string Asunto { get; set; }

        /// <summary>
        /// Cuerpo del email
        /// </summary>
        public string Cuerpo { get; set; }

        /// <summary>
        /// Lista con los paths de los ficheros que se pretenden adjuntar al email.
        /// </summary>
        private string[] RutasAdjuntos { get; set; }

        /// <summary>
        /// Lista con los ficheros que se pretenden adjuntar al email, sólo pueden ser texto plano.
        /// </summary>
        public System.IO.Stream[] FicherosAdjuntos { get; set; }
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa la clase para el envío de email con lo básico
        /// </summary>
        /// <param name="direccion"> dirección de email a la que se pretende enviar el correo</param>
        /// <param name="asunto">Asunto del correo</param>
        /// <param name="mensaje">Cuerpo del email</param>
        public EnvioMail(string direccion, string asunto, string mensaje)
        {
            DireccionesReceptores = new string[] { direccion };
            Asunto = asunto;
            Cuerpo = mensaje;
        }

        /// <summary>
        /// Inicializa la clase para el envío de email con lo básico
        /// </summary>
        /// <param name="direcciones">Varias direcciones a las que se envía el correo</param>
        /// <param name="asunto">asunto del correo</param>
        /// <param name="mensaje">Cuerpo del email</param>
        public EnvioMail(string[] direcciones, string asunto, string mensaje)
        {
            DireccionesReceptores = direcciones;
            Asunto = asunto;
            Cuerpo = mensaje;

        }

        /// <summary>
        /// Inicializa la clase para el envío de email con lo básico
        /// </summary>
        /// <param name="direcciones">Varias direcciones a las que se envía el correo</param>
        /// <param name="asunto">asunto del correo</param>
        /// <param name="mensaje">Cuerpo del email</param>
        /// <param name="rutaAdjunto">Ruta del fichero que se adjunta</param>
        public EnvioMail(string[] direcciones, string asunto, string mensaje, string rutaAdjunto)
        {
            DireccionesReceptores = direcciones;
            Asunto = asunto;
            Cuerpo = mensaje;
            RutasAdjuntos = new string[1] { rutaAdjunto };

        }

        public EnvioMail()
        {

        }

        #endregion

        #region Métodos publicos
        public bool EnviarEmail()
        {
            MailMessage msg = new MailMessage();
            return enviarEmail(msg);
        }

        /// <summary>
        /// Envia un email con conexión segura.
        /// Por defecto se manda al puerto y servidor de gmail, a la dirección antonioastur@gmail.com
        /// </summary>
        public bool EnviarEmail(string[] direcciones, string asunto, string mensaje)
        {
            DireccionesReceptores = direcciones;
            Asunto = asunto;
            Cuerpo = mensaje;

            return EnviarEmail();
        }

        /// <summary>
        /// Envia un email con conexión segura.
        /// Por defecto se manda al puerto y servidor de gmail, a la dirección antonioastur@gmail.com
        /// </summary>
        public bool EnviarEmail(string[] direcciones, string[] direccionesOcultas, string asunto, string mensaje)
        {
            DireccionesReceptores = direcciones;
            DireccionesReceptoresOcultos = direccionesOcultas;
            Asunto = asunto;
            Cuerpo = mensaje;

            return EnviarEmail();
        }

        /// <summary>
        /// Envia un email con conexión segura.
        /// Por defecto se manda al puerto y servidor de gmail, a la dirección antonioastur@gmail.com
        /// </summary>
        public bool EnviarEmail(string direccion, string asunto, string mensaje)
        {
            DireccionesReceptores = new string[] { direccion };
            Asunto = asunto;
            Cuerpo = mensaje;

            return EnviarEmail();
        }

        /// <summary>
        /// Envia un email con conexión segura.
        /// Por defecto se manda al puerto y servidor por defecto
        /// conexionSegura: se realiza conexión SSL
        /// credenciales: si es true, se meten credenciales al servidor
        /// </summary>
        private bool enviarEmail(MailMessage msg)
        {
            //1º.Configuramos el email            

            if (DireccionesReceptores == null && DireccionesReceptoresOcultos == null)
                throw new Exception("Es necesario indicar las direcciones de correo a las que se envía el email.");

           


            foreach (string dire in DireccionesReceptores)
            {
                try
                {
                    validarDireccion(dire);
                    string[] arrayDirecciones = dire.Trim ().Split(';');
                    foreach (string d in arrayDirecciones)
                        if(!string.IsNullOrEmpty (d))
                            msg.To.Add(d.Trim());
                }
                catch (Exception ex3)
                {

                    throw new Exception("Error al añadir esta dirección: " + dire, ex3);
                }

            }

            if (DireccionesReceptoresOcultos != null && DireccionesReceptoresOcultos.Length > 0)
            {
                foreach (string dire in DireccionesReceptoresOcultos)
                {
                    try
                    {
                        validarDireccion(dire);
                        msg.Bcc.Add(dire.Trim());
                    }
                    catch (Exception ex4)
                    {

                        throw new Exception("Error al añadir esta dirección oculta: " + dire, ex4);
                    }

                }
            }

            msg.From = new MailAddress(DireccionServidor, DisplayName, System.Text.Encoding.UTF8);

            configurarCuerpoYAsunto(ref msg, Asunto, Cuerpo);
                       
            //Servidor de correo
            SmtpClient client = new SmtpClient
            {
                Credentials = new System.Net.NetworkCredential(DireccionServidor, ClaveServidor),
                Port = PuertoEnvio,
                Host = Host,
                EnableSsl = false,
                Timeout = 10000
            };

            try
            {               
                client.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                //Mandamos el email uno a uno por si se diese el caso que la excepción halla sido provocada por una dirección mal escrita que no tire abajo todo el correo.
                string mensajeError = "No se ha podido mandar el email:\n" + ex.Message;
                foreach (string dire in DireccionesReceptores)
                {
                    msg.To.Clear();
                    msg.To.Add(dire.Trim());

                    try
                    {
                        client.Send(msg);
                    }
                    catch (Exception ex2)
                    {
                        mensajeError += "\n" + ex2.Message;
                    }

                }
                throw new Exception(mensajeError);
            }
        }

        public bool EnviarEmail(List<Attachment> adjuntos)
        {
            MailMessage msg = new MailMessage();
            foreach (Attachment atacheado in adjuntos)
                msg.Attachments.Add(atacheado);

            return enviarEmail(msg);
        }

       

        private void validarDireccion(string direccion)
        {
            if (string.IsNullOrEmpty (direccion) || direccion.Length < 6)
                throw new Exception("La dirección " + direccion + " no es válida");

            if (!direccion.Contains("@"))
                throw new Exception ("La dirección " + direccion + " no es válida");

            if (!direccion.Contains("."))
                throw new Exception("La dirección " + direccion + " no es válida");

            if(direccion.Substring (direccion.IndexOf (".")).Length < 2)
                throw new Exception("La dirección " + direccion + " no es válida");
        }

        private void configurarCuerpoYAsunto(ref MailMessage msg, string asunto, string cuerpo)
        {
            //Asunto
            msg.Subject = asunto;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Body
            msg.Body = cuerpo;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
        }

        public List <Attachment > AdjuntarArchivos(string[] adjuntos, string mediaType )
        {
            if (adjuntos == null || adjuntos.Length == 0)
                return null;

            List<Attachment> atacheados = new List<Attachment>();
            foreach (string adjunto in adjuntos)
            {
                //En vez de abjuntar el archivo directamente, lo cargamos en memoria, porque si se adjunta directamente deja el fichero pillado. 
                atacheados.Add(new Attachment(getStreamFile(adjunto), Path.GetFileName(adjunto), mediaType));
            }

            return atacheados;

        }

        private Stream getStreamFile(string filePath)
        {
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                MemoryStream memStream = new MemoryStream();
                memStream.SetLength(fileStream.Length);
                fileStream.Read(memStream.GetBuffer(), 0, (int)fileStream.Length);

                return memStream;
            }
        }

        private void adjuntarArchivos(ref MailMessage msg, System.IO.Stream[] adjuntos, string mediaType = MediaTypeNames.Text.Plain)
        {
            if (adjuntos != null)
            {
                foreach (System.IO.Stream adjunto in adjuntos)
                {
                    Attachment archivo = new Attachment(adjunto, new ContentType(mediaType));
                    //Se le puede dar un nombre al archivo para que quede bonito, ej. archivo.Name = "Resolucion.pdf";
                    msg.Attachments.Add(archivo);
                }
            }
        }

       

        
               
        #endregion
    }
}

