using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCherrys.Models;
using AppCherrys.Models.Tablon;

namespace AppCherrys.Services
{
    public class MockDataStore : IDataStore<Anuncio>
    {
        List<Anuncio> Anuncios;

        public MockDataStore()
        {
            Anuncios = new List<Anuncio>();
            var mockItems = new List<Anuncio>
            {
                new Anuncio { Id = 1, Titulo = "Visita a Kikiricoop", Descripcion="Los chic@s de esta cooperativa asturiana nos muestran su proceso industrial y estudiamos las posibilidades de mejora.", IdUsuarioPublicacion = "Jose", FechaPublicacion = DateTime.Now.AddDays (-3) },
                new Anuncio { Id = 2, Titulo = "Local de Noreña concedido", Descripcion="A la cuarta, por fín Juan consiguió poner el papel en su lugar ;)." , IdUsuarioPublicacion = "Toño", FechaPublicacion = DateTime.Now.AddMonths (-1) },
                new Anuncio { Id = 3, Titulo = "Fran ya tiene una FPGA para pruebas",Descripcion="Fran libera Trello y hace focus en FPGA + Microchip with Wifi." , IdUsuarioPublicacion = "Javi", FechaPublicacion = DateTime.Now.AddDays (-7) }

            };

            foreach (var Anuncio in mockItems)
            {
                Anuncios.Add(Anuncio);
            }
        }

        public async Task<bool> AddItemAsync(Anuncio anuncio)
        {
            Anuncios.Add(anuncio);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Anuncio anuncio)
        {
            var oldItem = Anuncios.Where((Anuncio arg) => arg.Id == anuncio.Id).FirstOrDefault();
            Anuncios.Remove(oldItem);
            Anuncios.Add(anuncio);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = Anuncios.Where((Anuncio arg) => arg.Id == id).FirstOrDefault();
            Anuncios.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Anuncio> GetItemAsync(int id)
        {
            return await Task.FromResult(Anuncios.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Anuncio>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Anuncios);
        }
    }
}