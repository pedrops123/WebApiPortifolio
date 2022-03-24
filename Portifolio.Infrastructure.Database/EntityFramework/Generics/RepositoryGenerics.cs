using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Portifolio.Domain.Generics;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Portifolio.Infrastructure.Database.EntityFramework.Generics
{
    public class RepositoryGenerics<T> : IGenericRepository<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<AppDbContext> _OptionsBuilder;

        public RepositoryGenerics()
        {
            _OptionsBuilder = new DbContextOptions<AppDbContext>();
        }

        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public virtual async Task Add(T Objeto)
        {
            using (var data = new AppDbContext(_OptionsBuilder))
            {
                Objeto.GetType().GetProperty("InsertDate").SetValue(Objeto, DateTime.Now);
                await data.Set<T>().AddAsync(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public virtual async Task Update(T Objeto)
        {
            using (var data = new AppDbContext(_OptionsBuilder))
            {
                Objeto.GetType().GetProperty("UpdateDate").SetValue(Objeto, DateTime.Now);
                data.Set<T>().Update(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public virtual async Task AddRange(List<T> ListObject)
        {
            using (var data = new AppDbContext(_OptionsBuilder))
            {
                foreach (var item in ListObject)
                {
                    item.GetType().GetProperty("InsertDate").SetValue(item, DateTime.Now);
                }

                await data.Set<T>().AddRangeAsync(ListObject);
                await data.SaveChangesAsync();
            }
        }

        public virtual async Task RemoveRange(List<T> ListObject)
        {
            using (var data = new AppDbContext(_OptionsBuilder))
            {
                data.Set<T>().RemoveRange(ListObject);
                await data.SaveChangesAsync();
            }
        }

        public virtual async Task Delete(T Objeto)
        {
            using (var data = new AppDbContext(_OptionsBuilder))
            {
                data.Set<T>().Remove(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public virtual async Task<T> GetEntityById(int id)
        {
            using (var data = new AppDbContext(_OptionsBuilder))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public virtual async Task<List<T>> List()
        {
            using (var data = new AppDbContext(_OptionsBuilder))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }


        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
    }
}