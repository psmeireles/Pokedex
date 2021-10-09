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
        
        private const uint LAST_ID = 800;

        [TestInitialize]
        public void TestInitialize()
        {
            _repository = new PokedexCSV();
            Assert.AreEqual(_repository.GetCount(), 800);
        }

        [DataRow(1)]
        [DataRow(10)]
        [DataRow(100)]
        [DataRow(800)]
        [DataTestMethod]
        public void GetById_Success_ReturnsPokemonWithRequestedId(int id)
        {
            var uintId = (uint) id;
            var pokemon = _repository.GetById(uintId);
            Assert.AreEqual(pokemon.Id, uintId);
        }
        
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(801)]
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
        [DataRow(801)]
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
                Number = 1,
                Name = "TestPokemon",
                Generation = 1
            };
            var previousCount = _repository.GetCount();
            _repository.Create(pokemon);
            var newCount = _repository.GetCount();
            Assert.AreEqual(previousCount + 1, newCount);
        }
        
        [DataRow("TestPokemon")]
        [DataRow("TestPokemon2")]
        [DataTestMethod]
        public void Create_Success_ReturnsCreatedPokemonWithSameNameAndNumber(string name)
        {
            var pokemon = new Pokemon
            {
                Number = 1,
                Name = name,
                Generation = 1
            };
            var newPokemon = _repository.Create(pokemon);
            Assert.AreEqual(pokemon.Name, newPokemon.Name);
            Assert.AreEqual(pokemon.Number, newPokemon.Number);
        }
        
        [TestMethod]
        public void Create_Success_ReturnsPokemonWithIdEqualsLastIdPlusOne()
        {
            var pokemon = new Pokemon
            {
                Number = 1,
                Name = "TestPokemon",
                Generation = 1
            };
            var newPokemon = _repository.Create(pokemon);
            Assert.AreEqual(LAST_ID + 1, newPokemon.Id);
        }
        
        [TestMethod]
        public void Create_AfterDeleteLast_ReturnsWithIdEqualsToLast()
        {
            var pokemon = new Pokemon
            {
                Number = 1,
                Name = "TestPokemon",
                Generation = 1
            };
            _repository.Delete(LAST_ID);
            var newPokemon = _repository.Create(pokemon);
            Assert.AreEqual(LAST_ID, newPokemon.Id);
        }
        
        [TestMethod]
        public void Create_AfterDeleteAll_ReturnsWithIdEquals1()
        {
            var total = _repository.GetCount();
            for (uint i = 1; i <= total; i++) 
                _repository.Delete(i);
            var pokemon = new Pokemon
            {
                Number = 1,
                Name = "TestPokemon",
                Generation = 1
            };
            var newPokemon = _repository.Create(pokemon);
            Assert.AreEqual((uint)1, newPokemon.Id);
        }
        
                
        [TestMethod]
        public void GetById_CreatedAfterDeletion_ReturnsIdBiggerThanCount()
        {
            _repository.Delete(1);
            var pokemon = new Pokemon
            {
                Number = 1,
                Name = "TestPokemon",
                Generation = 1
            };
            var newPokemon = _repository.Create(pokemon);
            var createdPokemon = _repository.GetById(newPokemon.Id);
            var count = _repository.GetCount();
            Assert.IsTrue(createdPokemon.Id > count);
        }
    }
}