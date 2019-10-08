using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using KQ.CommonLib.Models.Tablon;
using KQ.CommonLib.Models.Usuario;
using System.Linq;

namespace KQ.Service.Models
{
    public class UsuarioRepository :BaseRepository <Usuario>
    {
        

        public UsuarioRepository()
        {
            Add(new Usuario { Id = 1, DNI = "63052727K", Nombre = "Antoñito", Apellidos = "Fernandez", FechaAlta = DateTime.Parse("01/02/2004"),Email ="antonio@dt.com",Alias="Toñito",PWD ="1" });
            Add(new Usuario { Id = 2, DNI = "60529446R", Nombre = "Virgilio", Apellidos = "García", FechaAlta = DateTime.Parse("11/03/2004"), Email = "virgilio@dt.com", Alias = "Vigi", PWD = "1" });      
            Add(new Usuario { Id = 3, DNI = "93074746W", Nombre = "Pepe",     Apellidos = "López", FechaAlta = DateTime.Parse("05/04/2004"),Email ="pepe@dt.com",Alias="botica",PWD ="1" });
                      
        }

        public Usuario Get(string email, string pwd)
        {
            return Items.Values.Where(x => x.Email.ToUpper () == email.ToUpper () && x.PWD == pwd).FirstOrDefault();
        }
    }
}
