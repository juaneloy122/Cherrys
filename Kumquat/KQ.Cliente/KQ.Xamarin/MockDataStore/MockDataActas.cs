using KQ.CommonLib.Models.Acta;
using System;
using System.Collections.Generic;

namespace KQ.Xamarin.MockDataStore
{

    public class MockDataActas : MockDataStore<Acta>
    {
        public MockDataActas()
        {
            Items = new List<Acta>();
            var mockItems = new List<Acta>
            {
                new Acta { Id = 1, Titulo = "Reunión Estatutos", Descripcion="Reunión rutinaria", IdUsuario = "Toño", Fecha = DateTime.Now.AddDays (-3) },
                new Acta { Id = 2, Titulo = "Reunión proyecto Intu", Descripcion="Grueso de la reunión, discusión sobre el proyecto Intu" , IdUsuario = "Juan", Fecha = DateTime.Now.AddMonths (-1) },
                new Acta { Id = 3, Titulo = "Reunión revisión local",Descripcion="Grueso de la reunión discusión sobre el local de reuniones" , IdUsuario = "Josu", Fecha = DateTime.Now.AddDays (-7) }

            };

            foreach (var acta in mockItems)
            {
                Items.Add(acta);
            }
        }
    }
}
