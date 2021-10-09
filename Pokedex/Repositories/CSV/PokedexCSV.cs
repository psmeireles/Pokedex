using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            using var reader = new StreamReader("D:/Projects/Pokedex/Pokedex/Repositories/CSV/Database.csv");
            // skip first line with column names
            reader.ReadLine();
            uint seqId = 1;
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
                    Id = seqId,
                    Number = uint.Parse(values[0]),
                    Name = values[1],
                    Type1 = Enum.Parse<Type>(values[2]),
                    Type2 = values[3] == string.Empty ? null : Enum.Parse<Type>(values[3]),
                    Total = uint.Parse(values[4]),
                    HP = uint.Parse(values[5]),
                    Attack = uint.Parse(values[6]),
                    Defense = uint.Parse(values[7]),
                    SpAtk = uint.Parse(values[8]),
                    SpDef = uint.Parse(values[9]),
                    Speed = uint.Parse(values[10]),
                    Generation = uint.Parse(values[11]),
                    Legendary = values[12] == "True",
                });
                seqId++;
            }

            return list;
        }
        
        public PokedexCSV()
        {
            _database = InitializeDatabase();
        }

        public Pokemon Create(Pokemon obj)
        {
            var id = _database.Count == 0 ? 1 : _database.Last().Id + 1;
            obj.Id = id;
            _database.Add(obj);
            return obj;
        }

        public void Update(Pokemon obj)
        {
            var id = obj.Id;
            if (id < 1 || id > _database.Count)
                return;
            var currentIndex = _database.FindIndex(pokemon => pokemon.Id == id);
            if (currentIndex == -1)
                return;
            _database[currentIndex] = obj;
        }

        public IEnumerable<Pokemon> GetPaged(int pageNumber, int pageSize) => 
            _database.Skip(pageNumber * pageSize).Take(pageSize);

        public int GetCount() => _database.Count;

        public Pokemon GetById(uint id)
        {
            if (id < 1 || id > _database.Count)
                return null;
            return _database.Find(pokemon => pokemon.Id == id);
        }

        public void Delete(uint id)
        {
            if (id < 1)
                return;
            var index = _database.FindIndex(pokemon => pokemon.Id == id);
            if (index == -1)
                return;
            _database.RemoveAt(index);
        }
    }
}