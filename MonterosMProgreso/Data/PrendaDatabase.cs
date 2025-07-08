using SQLite;
using MonterosMProgreso.Models;

namespace MonterosMProgreso.Data
{
    public class PrendaDatabase
    {
        private readonly SQLiteAsyncConnection _database;
        public PrendaDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Prenda>().Wait();
        }
        public Task<List<Prenda>> GetPrendasAsync() => _database.Table<Prenda>().ToListAsync();
        public Task<int> SavePrendaAsync(Prenda prenda) => _database.InsertAsync(prenda);
    }
}