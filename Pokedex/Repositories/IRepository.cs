using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokedex.Repositories
{
    public interface IRepository<T>  
    {  
        public T Create(T obj);
  
        public void Update(T obj);
  
        public IEnumerable<T> GetPaged(int pageNumber, int pageSize);
  
        public T GetById(uint id);
  
        public void Delete(uint id);
  
    }  
}