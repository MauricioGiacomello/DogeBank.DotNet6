using DOB.ApiDotNet6.Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOB.ApiDotNet6.Infra.Data.Services
{
    public class ProdutoServices
    {
        private readonly IMongoCollection<Usuario> _produtoCollection;

        public ProdutoServices(IOptions<ProdutoDatabaseSettings> produtoServices)
        {
            var mongoClient = new MongoClient(produtoServices.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(produtoServices.Value.DatabaseName);

            _produtoCollection = mongoDatabase.GetCollection<Usuario>
                (produtoServices.Value.ProdutoCollectionName);
        }

        public async Task<List<Usuario>> GetAsync()
        { 
            return await _produtoCollection.Find(x => true).ToListAsync();        
        }

        public async Task<Usuario> GetAsync(string id)
        { 
            return  await _produtoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Usuario produto) 
        {         
            await _produtoCollection.InsertOneAsync(produto);
        }

        public async Task UpdateAsync(string id, Usuario produto) 
        { 
           await _produtoCollection.ReplaceOneAsync(x => x.Id == id, produto);
        }

        public async Task RemoveAsync(string id) 
        { 
            await _produtoCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
