using CommonLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCherrys.Models.Calendario
{
    /// <summary>
    /// Evento de calendario
    /// </summary>
    public class Evento : IItem
    {
        public string Cabecera => FechaInicio.ToShortDateString() + " - " + FechaFin.ToShortDateString() + " (" + IdUsuario + ") " + Titulo;
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public string FechaInicioFechaFIn => FechaInicio.ToShortDateString() + " - " + FechaFin.ToShortDateString();

        /// <summary>
        /// Quien crea el evento
        /// </summary>
        public string IdUsuario { get; set; }

        private DateTime _fechaInicio;
        public DateTime FechaInicio
        {
            get
            {
                return _fechaInicio;
            }

            set
            {
                if (value == DateTime.MinValue)
                    value = System.DateTime.Now;

                _fechaInicio = value;
            }

        }

        private DateTime _fechaFin;
        public DateTime FechaFin
        {
            get
            {
                return _fechaFin;
            }

            set
            {
                if (value == DateTime.MinValue)
                    value = System.DateTime.Now;

                _fechaFin = value;
            }
        }
    }
}
