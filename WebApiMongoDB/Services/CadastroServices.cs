using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApiMongoDB.Models;

namespace WebApiMongoDB.Services
{
    public class CadastroServices
    {
        private readonly IMongoCollection<Cadastro> _cadastroCollection;

        public CadastroServices(IOptions<CadastroDatabaseSettings> cadastroServices)
        {
            
            var mongoClient = new MongoClient(cadastroServices.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(cadastroServices.Value.DatabaseName);

            _cadastroCollection = mongoDatabase.GetCollection<Cadastro>
                (cadastroServices.Value.CadastroCollectionName);

        }
       
        public async Task<List<Cadastro>> GetAsync() =>
            await _cadastroCollection.Find(x => true).ToListAsync();

        public async Task<Cadastro> GetAsync(string id) =>
           await _cadastroCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Cadastro cadastro)
        {
            var cadastrofound = await _cadastroCollection
                .Find(x => x.CPF == cadastro.CPF || x.Email == cadastro.Email)
                .FirstOrDefaultAsync();

            if (cadastrofound != null)
            {
                throw new Exception("Já existe cadastro no CPF ou E-mail cadastrado");
            }
            await _cadastroCollection.InsertOneAsync(cadastro);

        }

        public async Task UpdateAsync(string id, Cadastro cadastro) =>
           await _cadastroCollection.ReplaceOneAsync(x => x.Id == id, cadastro);

        public async Task RemoveAsync(string id) =>
            await _cadastroCollection.DeleteOneAsync(x => x.Id == id);
    }
}
