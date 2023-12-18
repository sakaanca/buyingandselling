using Project.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstracts
{
    public interface IManager <T> where T: class,IEntity
    {
        // List Commands
        // Bunlar bizim raporlarımıza destek verecek olan metodlar
        IQueryable<T> GetAll();
        IQueryable<T> GetActives();
        IQueryable<T> GetModifieds();
        IQueryable<T> GetPassives();

        //Modifay Commands
        //Veri tabanımızda değişiklik yapacak olan metodlar
        // Task Add(); burada ki task geriye değer döndürmediğini ifade ediyor

        string Add(T item);

        Task AddAsync(T item);
        void AddRange(List<T> list);
        Task AddRangeAsync(List<T> list);
        Task Update(T item);
        Task UpdateRange(List<T> list);
        // Belirli öğeyi silmek için kullanılır
        void Delete(T item);
        void DeleteRange(List<T> list);
        // Nesneyi silmek için kullanılır
        void Destroy(T item);// Todo : RemoveAsync varsa metodu Task cevirelim
        void DestroyRange(List<T> list);
        //Linq Commands
        IQueryable<T> Where(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp);
        IQueryable<X> Select<X>(Expression<Func<T, X>> exp);
        //Find
        Task<T> FindAsync(int id);


    }
}
