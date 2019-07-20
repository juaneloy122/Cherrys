using AppCherrys.Models.Acta;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCherrys.Services
{
    
    public class MockDataActas : MockDataStore<Acta>
    {
        public MockDataActas()
        {
            Items = new List<Acta>();
            var mockItems = new List<Acta>
            {
                //new Acta { Id = 1, Titulo = "Visita a Kikiricoop", Descripcion="Los chic@s de esta cooperativa asturiana nos muestran su proceso industrial y estudiamos las posibilidades de mejora.", IdUsuarioPublicacion = "Jose", FechaPublicacion = DateTime.Now.AddDays (-3) },
                //new Acta { Id = 2, Titulo = "Local de Noreña concedido", Descripcion="A la cuarta, por fín Juan consiguió poner el papel en su lugar ;)." , IdUsuarioPublicacion = "Toño", FechaPublicacion = DateTime.Now.AddMonths (-1) },
                //new Acta { Id = 3, Titulo = "Fran ya tiene una FPGA para pruebas",Descripcion="Fran libera Trello y hace focus en FPGA + Microchip with Wifi." , IdUsuarioPublicacion = "Javi", FechaPublicacion = DateTime.Now.AddDays (-7) }

            };

            foreach (var acta in mockItems)
            {
                Items.Add(acta);
            }
        }
    }
}
