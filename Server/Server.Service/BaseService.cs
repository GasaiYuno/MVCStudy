using Microsoft.EntityFrameworkCore;
using Server.IEFCoreContext;
using Server.IService;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace Server.Service
{
    public class BaseService : IBaseService
    {
        protected DbContext _dbcontext { get; private set; }

        public BaseService(IEFContext dbcontext)
        {
            _dbcontext = dbcontext.DbConnet();
        }

        public void Commit()
        {
            this._dbcontext.SaveChanges();
        }

        public void Delete<T>(int Id) where T : class
        {
            T t = this.Find<T>(Id);
            if (t == null) { throw new Exception("id is null!"); }
            this._dbcontext.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(T t) where T : class
        {
            if (t == null) { throw new Exception("t id null!"); }
            this._dbcontext.Attach(t);
            this._dbcontext.Remove(t);
            this.Commit();
        }

        public void Delete<T>(IEnumerable<T> tList) where T : class
        {
            foreach(var t in tList)
            {
                this._dbcontext.Attach(t);
            }
            this._dbcontext.RemoveRange(tList);
            this.Commit();
        }

        public T Find<T>(int id) where T : class
        {
            return this._dbcontext.Set<T>().Find(id);
        }

        public T Insert<T>(T t) where T : class
        {
            this._dbcontext.Set<T>().Add(t);
            this.Commit();
            return t;
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            this._dbcontext.Set<T>().AddRange(tList);
            this.Commit();
            return tList;
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
            return this._dbcontext.Set<T>().Where(funcWhere);
        }

        public void Update<T>(T t) where T : class
        {
            if (t == null) { throw new Exception("t is null"); }
            this._dbcontext.Set<T>().Attach(t);
            this._dbcontext.Entry<T>(t).State= EntityState.Modified;
            this.Commit();

        }

        public void Update<T>(IEnumerable<T> tList) where T : class
        {
            foreach(var t in tList)
            {
                this._dbcontext.Set<T>().Attach(t);
                this._dbcontext.Entry<T>(t).State = EntityState.Modified; 
            }
            this.Commit();
        }
        public virtual void Dispose()
        {
            if (_dbcontext != null)
            {
                _dbcontext.Dispose();
            }
        }
    }
}