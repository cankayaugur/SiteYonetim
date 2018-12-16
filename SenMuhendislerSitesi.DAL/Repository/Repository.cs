using SenMuhendislerSitesi.DAL.Context;
using SenMuhendislerSitesi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Repository
{
    public class Repository<TEntity> where TEntity : BaseModel
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(UnitOfWork.UnitOfWork uow)//UnitOfWork'e gidiyor.
        {
            _context = uow.GetContext();//UnitOfWorkden gelen database bağlantısını dışdaki _context'e atıyor.
            _dbSet = _context.Set<TEntity>();
        }
        public virtual void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + "boş olamaz");
            }
            entity.SilindiMi = false;
            _dbSet.Add(entity);
        }
        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(typeof(TEntity).Name + " boş olamaz.");

            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(typeof(TEntity).Name + " boş olamaz.");

            entity.SilindiMi = true;
            entity.Durum = false;
            Update(entity);
        }
        public virtual void Delete(Expression<Func<TEntity, bool>> query)
        {
            if (query == null) throw new ArgumentNullException(typeof(TEntity).Name + " sorgu boş olamaz.");

            ICollection<TEntity> list = GetList(query).ToList();
            foreach (var item in list)
            {
                item.SilindiMi = true;
                item.Durum = false;
                Update(item);
            }
        }
        public virtual TEntity Get(Expression<Func<TEntity, bool>> query, params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            var newquery = _dbSet.Where(x => x.SilindiMi == false);

            if (includeExpressions.Any())
                newquery = includeExpressions.Aggregate(newquery, (current, includeExpression) => current.Include(includeExpression));

            var result = newquery.FirstOrDefault(query);

            return result;
        }
        public virtual IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> query = null, params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            var newquery = _dbSet.Where(x => x.SilindiMi == false);

            if (query != null)
                newquery = newquery.Where(query);

            if (includeExpressions.Any())
                newquery = includeExpressions.Aggregate(newquery, (current, includeExpression) => current.Include(includeExpression));


            return newquery;
        }
        public virtual int GetCount(Expression<Func<TEntity, bool>> query = null)
        {
            return query == null ? _dbSet.Count(x => x.SilindiMi == false) : _dbSet.Where(x => x.SilindiMi == false).Count(query);
        }
        public virtual bool Any(Expression<Func<TEntity, bool>> query = null)
        {
            return query == null ? _dbSet.Any(x => x.SilindiMi == false) : _dbSet.Where(x => x.SilindiMi == false).Any(query);
        }

    }
}
