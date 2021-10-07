using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pokedex.Data;

namespace Pokedex.Repositories.CSV
{
    public class PokedexCSV : IRepository<Pokemon>
    {
        public Task<Pokemon> Create(Pokemon obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Pokemon obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pokemon> GetAll()
        {
            throw new NotImplementedException();
        }

        public Pokemon GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}