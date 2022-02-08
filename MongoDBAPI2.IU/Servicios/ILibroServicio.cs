using MongoDBAPI2.IU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBAPI2.IU.Servicios
{
    public interface ILibroServicio
    {
            Task<IEnumerable<Libro>> ObtenerTodosLibros();
            Task<Libro> ObtenerLibro(String id);
            Task GuardarLibro(Libro libro);
            Task BorrarLibro(String id);
        }
    }

