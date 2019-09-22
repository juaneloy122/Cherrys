using AppCherrys.MockDataStore;
using AppCherrys.Models.Tarea;
using System;
using System.Collections.Generic;

namespace AppCherrys.Services
{

    public class MockDataTareas : MockDataStore<Tarea>
    {
        public MockDataTareas()
        {
            Items = new List<Tarea>();
            var mockItems = new List<Tarea>
            {
                new Tarea { Id = 1, Titulo = "Crear la estructura de la aplicación", Descripcion="Se trata de crear la estructura de carpetas, de capas, y de aplicación inicial para construir sobre ella", IdUsuario = "Toño",FechaInicio = DateTime.Now.AddDays (-3), FechaPrevistaFin = DateTime.Now.AddDays (5) },
                new Tarea { Id = 2, Titulo = "Instalar Components Design", Descripcion="Instalar este componente y definir el diseño de colores de la aplicación, modo light y nocturno" , IdUsuario = "Juan", FechaInicio = DateTime.Now.AddMonths (-1), FechaPrevistaFin = DateTime.Now.AddDays (5) },
                new Tarea { Id = 3, Titulo = "Crear pantalla de login",Descripcion="Pantalla sencillina de login para logearse al entrar en la aplicación" , IdUsuario = "Josu", FechaInicio = DateTime.Now.AddDays (-7), FechaPrevistaFin = DateTime.Now.AddDays (5) }

            };

            foreach (var item in mockItems)
            {
                Items.Add(item);
            }
        }
    }
}
