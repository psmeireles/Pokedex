using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Pokedex.Data;
using Type = Pokedex.Data.Type;

namespace Pokedex.Repositories.CSV
{
    public class PokedexCSV : IRepository<Pokemon>
    {
        private List<Pokemon> _database;

        private List<Pokemon> InitializeDatabase()
        {
            var list = new List<Pokemon>();
            using var reader = new StreamReader("Repositories/CSV/Database.csv");
            // skip first line with column names
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line is null)
                    throw new Exception("Error on database initialization");
                    
                var values = line.Split(',');
                if (values.Length != 13)
                    throw new Exception("Error on database initialization");
                    
                list.Add(new Pokemon
                {
                    Id = int.Parse(values[0]),
                    Name = values[1],
                    Type1 = Enum.Parse<Type>(values[2]),
                    Type2 = values[3] == string.Empty ? null : Enum.Parse<Type>(values[3]),
                    Total = int.Parse(values[4]),
                    HP = int.Parse(values[5]),
                    Attack = int.Parse(values[6]),
                    Defense = int.Parse(values[7]),
                    SpAtk = int.Parse(values[8]),
                    SpDef = int.Parse(values[9]),
                    Speed = int.Parse(values[10]),
                    Generation = int.Parse(values[11]),
                    Legendary = values[12] == "True",
                });
            }

            return list;
        }
        
        public PokedexCSV()
        {
            _database = InitializeDatabase();
        }
        
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