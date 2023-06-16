using AplicatieClinicaAnalize.Models;
using System.Linq.Expressions;

namespace AplicatieClinicaAnalize.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        T GetById(int id);
        void Add(T entity);
        T Update(int id, T entity);
        void Delete(int id);
    }
}
