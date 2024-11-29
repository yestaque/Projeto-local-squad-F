using CadastroPrefeitura.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace CadastroPrefeitura.Domain
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IMongoDatabase _database;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            var client = new MongoClient("mongodb+srv://root:admin@cisreg.kzr70.mongodb.net/?retryWrites=true&w=majority&appName=CisReg");
            _database = client.GetDatabase("cisreg");
        }

        public IMongoCollection<Prefeitura> Prefeituras => _database.GetCollection<Prefeitura>("prefeituras");
        public IMongoCollection<PrefeituraModel> PrefeituraModels => _database.GetCollection<PrefeituraModel>("prefeituraModels");
    }
}
