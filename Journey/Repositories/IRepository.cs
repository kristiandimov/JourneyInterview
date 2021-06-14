using Journey.Models;
using Journey.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Repositories
{
    interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T add);
        void Update(T update);
        void Delete(int id);
        T GetFirstOrDefaut(T item);
        bool IsValid(T data);
    }
}
