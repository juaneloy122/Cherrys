using KQ.CommonLib.Models.Calendario;
using System;
using System.Collections.Generic;

namespace KQ.Xamarin.MockDataStore
{

    public class MockDataCalendario : MockDataStore<Evento>
    {
        public MockDataCalendario()
        {
            Items = new List<Evento>();
            var mockItems = new List<Evento>
            {
                new Evento { Id = 1, Titulo = "Reunión de Cherrys", Descripcion="Reunión rutinaria", IdUsuario = "Toño",FechaInicio = DateTime.Now.AddDays (-3), FechaFin = DateTime.Now.AddDays (5) },
                new Evento { Id = 2, Titulo = "Visita Cabranes", Descripcion="Visita a Kikiricoop para que nos cuenten como hacen lo que hacen" , IdUsuario = "Juan", FechaInicio = DateTime.Now.AddMonths (-1), FechaFin = DateTime.Now.AddDays (5) },
                new Evento { Id = 3, Titulo = "Inaguración local",Descripcion="Pantalla sencillina de login para logearse al entrar en la aplicación" , IdUsuario = "Josu", FechaInicio = DateTime.Now.AddDays (-7), FechaFin = DateTime.Now.AddDays (5) }

            };

            foreach (var item in mockItems)
            {
                Items.Add(item);
            }
        }
    }
}
