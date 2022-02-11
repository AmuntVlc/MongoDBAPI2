using MongoDBAPI2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBAPI2.Services
{
    public class CiudadesService
    {
        private readonly IMongoCollection<Ciudad> _ciudadesCollection;

        public CiudadesService(
            IOptions<CiudadStoreDatabaseSettings> ciudadStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                ciudadStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                ciudadStoreDatabaseSettings.Value.DatabaseName);

            _ciudadesCollection = mongoDatabase.GetCollection<Ciudad>(
                ciudadStoreDatabaseSettings.Value.CiudadesCollectionName);
        }

        public async Task<List<Ciudad>> GetAsync() =>
            await _ciudadesCollection.Find(_ => true).ToListAsync();

        //public async Task<Libro> GetAsync(string id) =>
        //    await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        //public async Task CreateAsync(Libro libro) =>
        //    await _booksCollection.InsertOneAsync(libro);

        //public async Task UpdateAsync(string id, Libro libro) =>
        //    await _booksCollection.ReplaceOneAsync(x => x.Id == id, libro);

        //public async Task RemoveAsync(string id) =>
        //    await _booksCollection.DeleteOneAsync(x => x.Id == id);
    }
}
