using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new() //Where buraya sadece veritabanı nesneleri gelebilir demek
    {
        Task<T> GetAsync(Expression<Func<T,bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<IList<T>> GetAllSync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties); //Predicate null gelirse tüm verileri getir null değilse uygulanan filtreye göre getir.
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    }
}
