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
                new Anuncio { Id = 1, Titulo = "Visita a Kikiricoop", Descripcion="This is an item description." },
                new Anuncio { Id = 2, Titulo = "Local de Noreña concedido", Descripcion="This is an item description." },
                new Anuncio { Id = 3, Titulo = "Fran ya tiene una FPGA para pruebas",Descripcion="This is an item description." },
               
            };

            foreach (var Anuncio in mockItems)
            {
                Anuncios.Add(Anuncio);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            Anuncios.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = Anuncios.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            Anuncios.Remove(oldItem);
            Anuncios.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = Anuncios.Where((Item arg) => arg.Id == id).FirstOrDefault();
            Anuncios.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(Anuncios.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Anuncios);
        }
    }
}