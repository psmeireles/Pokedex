using Pokedex.Data;
using Pokedex.Repositories;

namespace Pokedex.Services
{
    public class PokedexService
    {
        private readonly IRepository<Pokemon> _repository;  
  
        public PokedexService(IRepository<Pokemon> repository) => _repository = repository;

        public Pokemon GetById(int id) => _repository.GetById(id);
        
        public void DeleteById(int id) => _repository.Delete(id);
    }
}