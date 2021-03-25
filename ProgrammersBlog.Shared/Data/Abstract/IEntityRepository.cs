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
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties); //Predicate null gelirse tüm verileri getir null değilse uygulanan filtreye göre getir.

        Task<T> AddAsync(T entity); // <T> ekledik, kategori eklediğimizde bize kategori dönsün diye, ajax işlemlerinde bu dönüşe ihtiyacımız var
        Task<T> UpdateAsync(T entity); // Buna da <T> ekledik
        Task DeleteAsync(T entity);
        // Predicateleri liste halinde aldık ki opsiyonel olarak alabilelim, öbür türlü her biri girilmek zorunda kalırdı kullanıcı tarafından
        Task<IList<T>> SearhAsync(IList<Expression<Func<T, bool>>> predicates, params Expression<Func<T, object>>[] includeProperties);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
    }
}
