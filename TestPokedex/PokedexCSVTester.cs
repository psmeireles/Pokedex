using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pokedex.Data;
using Pokedex.Repositories;
using Pokedex.Repositories.CSV;

namespace TestPokedex
{
    [TestClass]
    public class PokedexCSVTester
    {
        private IRepository<Pokemon> _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            _repository = new PokedexCSV();
            Assert.AreEqual(_repository.GetCount(), 800);
        }

        [DataRow(1)]
        [DataRow(10)]
        [DataRow(100)]
        [DataRow(721)]
        [DataTestMethod]
        public void GetById_Success(int id)
        {
            var uintId = (uint) id;
            var pokemon = _repository.GetById(uintId);
            Assert.AreEqual(pokemon.Id, uintId);
        }
        
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(722)]
        [DataTestMethod]
        public void GetById_DoesNotExist_ReturnsNull(int id)
        {
            var uintId = (uint) id;
            var pokemon = _repository.GetById(uintId);
            Assert.IsNull(pokemon);
        }

        [TestMethod]
        public void Delete_Success_DecreasesCount()
        {
            var previousCount = _repository.GetCount();
            _repository.Delete(1);
            var newCount = _repository.GetCount();
            Assert.AreEqual(previousCount - 1, newCount);
        }
        
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(722)]
        [DataTestMethod]
        public void Delete_PokemonNotExists_NothingHappens(int id)
        {
            var previousCount = _repository.GetCount();
            var uintId = (uint) id;
            _repository.Delete(uintId);
            var newCount = _repository.GetCount();
            Assert.AreEqual(previousCount, newCount);
        }
        
        [TestMethod]
        public void GetById_AfterDelete_ReturnsNull()
        {
            _repository.Delete(1);
            var pokemon = _repository.GetById(1);
            Assert.IsNull(pokemon);
        }
        
        [TestMethod]
        public void Create_Success_IncreasesCount()
        {
            var pokemon = new Pokemon
            {
                Name = "TestPokemon",
                Generation = 1
            };
            var previousCount = _repository.GetCount();
            _repository.Create(pokemon);
            var newCount = _repository.GetCount();
            Assert.AreEqual(previousCount + 1, newCount);
        }
    }
}