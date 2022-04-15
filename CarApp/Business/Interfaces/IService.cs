using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IService<T> where T : IEntity
    {
        T Create(T entity);
        T Update(T entity, int id);
        T Delete (int id);
        T GetOne(int id);
        List<T> GetAll();
    }
}
