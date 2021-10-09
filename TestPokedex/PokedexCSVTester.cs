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
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}