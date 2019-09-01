using AppCherrys.Controls.Fuentes;
using AppCherrys.Models.Tablon;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppCherrys.Services
{
    public class MockDataAnuncios : MockDataStore<Anuncio>
    {
        public MockDataAnuncios()
        {
            Items = new List<Anuncio>();
            var mockItems = new List<Anuncio>
            {
                new Anuncio { Id = 1, Titulo = "Visita a Kikiricoop", Descripcion="Los chic@s de esta cooperativa asturiana nos muestran su proceso industrial y estudiamos las posibilidades de mejora.", IdUsuario = "Jose", FechaPublicacion = DateTime.Now.AddDays (-3), Imagen="fotoPerfilChico2.png", ColorIcono=Color.Green, Icono=Icon.Check },
                new Anuncio { Id = 2, Titulo = "Local de Noreña concedido", Descripcion="A la cuarta, por fín Juan consiguió poner el papel en su lugar ;)." , IdUsuario = "Toño", FechaPublicacion = DateTime.Now.AddMonths (-1), Imagen="fotoPerfilChico.png", ColorIcono=Color.Red, Icono=Icon.Check},
                new Anuncio { Id = 3, Titulo = "Fran ya tiene una FPGA para pruebas",Descripcion="Fran libera Trello y hace focus en FPGA + Microchip with Wifi." , IdUsuario = "Marina", FechaPublicacion = DateTime.Now.AddDays (-7), Imagen="FotoPerfil.png", ColorIcono=Color.Green, Icono=Icon.Check }

            };

            foreach (var Anuncio in mockItems)
            {
                Items.Add(Anuncio);
            }
        }
    }
}
