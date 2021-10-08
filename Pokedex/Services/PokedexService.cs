using Pokedex.Data;
using Pokedex.Repositories;

namespace Pokedex.Services
{
    public class PokedexService
    {
        private readonly IRepository<Pokemon> _repository;  
  
        public PokedexService(IRepository<Pokemon> repository) => _repository = repository;

        public Pokemon GetById(int id) => _repository.GetById(id);
        
        public Pokemon Create(CreatePokemonRequest request)
        {
            var created = _repository.Create(new Pokemon
            {
                Name = request.Name,
                Type1 = request.Type1,
                Type2 = request.Type2,
                Total = request.Total,
                HP = request.HP,
                Attack = request.Attack,
                Defense = request.Defense,
                SpAtk = request.SpAtk,
                SpDef = request.SpDef,
                Speed = request.Speed,
                Generation = request.Generation,
                Legendary = request.Legendary,
            });
            return created;
        }
        
        public void Update(int id, UpdatePokemonRequest request) =>
            _repository.Update(new Pokemon
            {
                Id = id,
                Name = request.Name,
                Type1 = request.Type1,
                Type2 = request.Type2,
                Total = request.Total,
                HP = request.HP,
                Attack = request.Attack,
                Defense = request.Defense,
                SpAtk = request.SpAtk,
                SpDef = request.SpDef,
                Speed = request.Speed,
                Generation = request.Generation,
                Legendary = request.Legendary,
            });

        public void DeleteById(int id) => _repository.Delete(id);
    }
}