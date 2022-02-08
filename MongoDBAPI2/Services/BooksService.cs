using MongoDBAPI2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBAPI2.Services
{
    public class BooksService
    {
        private readonly IMongoCollection<Libro> _booksCollection;

        public BooksService(
            IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<Libro>(
                bookStoreDatabaseSettings.Value.BooksCollectionName);
        }

        public async Task<List<Libro>> GetAsync() =>
            await _booksCollection.Find(_ => true).ToListAsync();

        public async Task<Libro> GetAsync(string id) =>
            await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Libro libro) =>
            await _booksCollection.InsertOneAsync(libro);

        public async Task UpdateAsync(string id, Libro libro) =>
            await _booksCollection.ReplaceOneAsync(x => x.Id == id, libro);

        public async Task RemoveAsync(string id) =>
            await _booksCollection.DeleteOneAsync(x => x.Id == id);
    }
}
