using Moq;
using Sample.Domain.Abstract;
using Sample.Domain.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Sample.Infrastructure
{
    public class EntityRepository<T> : IEntityRepository<T>
    where T : class, new()
    {
        readonly DbContext _entitiesContext;

        public EntityRepository(DbContext entitiesContext)
        {
            //_entitiesContext = entitiesContext ?? throw new ArgumentNullException("entitiesContext");

            // Create mock data
            DbSet<SampleData> mockedDbSet = new FakeDbSet<SampleData>();
            for (int i = 0; i < 10; i++)
            {
                mockedDbSet.Add(new SampleData() { Message = "hello world" });
            }

            var mockedContext = new Mock<EntitiesContext>();
            mockedContext.Setup(c => c.Set<SampleData>()).Returns(mockedDbSet);
            mockedContext.Setup(c => c.SampleData).Returns(mockedDbSet);
            _entitiesContext = mockedContext.Object;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _entitiesContext.Set<T>();
        }
        public virtual IQueryable<T> All
        {
            get
            {
                return GetAll();
            }
        }
        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _entitiesContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _entitiesContext.Set<T>().Where(predicate);
        }
        
        public virtual void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = _entitiesContext.Entry<T>(entity);
            _entitiesContext.Set<T>().Add(entity);
        }

        public virtual void Edit(T entity)
        {
            DbEntityEntry dbEntityEntry = _entitiesContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = _entitiesContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual void Save()
        {
            _entitiesContext.SaveChanges();
        }
    }
}
