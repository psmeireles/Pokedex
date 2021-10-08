using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokedex.Repositories
{
    public interface IRepository<T>  
    {  
        public T Create(T obj);
  
        public void Update(T obj);  
  
        public IEnumerable<T> GetAll();  
  
        public T GetById(int id);
  
        public void Delete(int id);  
  
    }  
}