using KQ.CommonLib.Models.Incidencia;
using KQ.CommonLib.Models.Usuario;
using System;

namespace KQ.Service.Models
{
    public class IncidenciaRepository : BaseRepository<Incidencia>
    {


        public IncidenciaRepository()
        {
            Add(new Incidencia { Id = 1, Titulo = "Casco caducado", Descripcion = "Por favor necesito otro casco", IdUsuario = 1, FechaPublicacion = DateTime.Parse ("12/10/2019") });
            Add(new Incidencia { Id = 2, Titulo = "Ausencia el viernes", Descripcion = "El viernes necesito cogerlo por asuntos personales", IdUsuario = 2, FechaPublicacion = DateTime.Parse("14/10/2019") });
            Add(new Incidencia { Id = 3, Titulo = "Baja médica", Descripcion = "Estoy con fiebre, me dió la baja el médico", IdUsuario = 3, FechaPublicacion = DateTime.Parse("21/10/2019") });

        }


    }
}
