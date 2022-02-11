using MongoDBAPI2.IU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBAPI2.IU.Servicios
{
    public interface ICiudadServicio
    {
        Task<IEnumerable<Ciudad>> ObtenerTodosCiudades();
        //Task<Libro> ObtenerLibro(String id);
        //Task GuardarLibro(Libro libro);
        //Task BorrarLibro(String id);
    }
}

