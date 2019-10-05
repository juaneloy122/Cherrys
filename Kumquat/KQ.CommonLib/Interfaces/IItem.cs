namespace KQ.CommonLib.Interfaces
{
    public interface IItem
    {
        int Id { get; set; }

        void Validar();

        //string Titulo { get; set; }

        //string Descripcion { get; set; }

        ///// <summary>
        ///// Quien crea el item
        ///// </summary>
        //string IdUsuario { get; set; }
    }
}

