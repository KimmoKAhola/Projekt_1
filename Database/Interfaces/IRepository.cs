using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Database.Interfaces
{
    public interface IRepository<T> where T : IDatabaseEntity
    {
        T? Get(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void SoftDelete(int id);
        void Save();
    }
}
