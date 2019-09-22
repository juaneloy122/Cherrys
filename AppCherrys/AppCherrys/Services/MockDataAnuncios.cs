using AppCherrys.MockDataStore;
using AppCherrys.Models.Tablon;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCherrys.Services
{
    public class MockDataAnuncios:MockDataStore<Anuncio>
    {
        public MockDataAnuncios()
        {
            Items = new List<Anuncio>();
            var mockItems = new List<Anuncio>
            {
                new Anuncio { Id = 1, Titulo = "Visita a Kikiricoop", Descripcion="Los chic@s de esta cooperativa asturiana nos muestran su proceso industrial y estudiamos las posibilidades de mejora.", IdUsuario = "Jose", FechaPublicacion = DateTime.Now.AddDays (-3) },
                new Anuncio { Id = 2, Titulo = "Local de Noreña concedido", Descripcion="A la cuarta, por fín Juan consiguió poner el papel en su lugar ;)." , IdUsuario = "Toño", FechaPublicacion = DateTime.Now.AddMonths (-1) },
                new Anuncio { Id = 3, Titulo = "Fran ya tiene una FPGA para pruebas",Descripcion="Fran libera Trello y hace focus en FPGA + Microchip with Wifi." , IdUsuario = "Javi", FechaPublicacion = DateTime.Now.AddDays (-7) }

            };

            foreach (var Anuncio in mockItems)
            {
                Items.Add(Anuncio);
            }
        }
    }
}
