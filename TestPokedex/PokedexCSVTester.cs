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

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}