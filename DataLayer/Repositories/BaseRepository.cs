using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class BaseRepository<T> where T: class
    {
        protected readonly AgileScrumContext _context = new AgileScrumContext();

        //public BaseRepository(){
        //    _context.Configuration.LazyLoadingEnabled = true;
        //}

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public ICollection<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}
