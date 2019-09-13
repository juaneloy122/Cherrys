using AppCherrys.ClientService;
using CommonLib.Models.Tablon;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCherrys.MockDataStore
{
    public class MockDataAnuncios : MockDataStore<Anuncio>, IClient<Anuncio>
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
