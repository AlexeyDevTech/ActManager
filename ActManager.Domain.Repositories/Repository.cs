using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ActManager.Domain.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _entities;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public T Get(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate).ToList();
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Attach<TAttach>(T entity, TAttach attachedEntity, Expression<Func<T, object>> navigationProperty)
    where TAttach : class
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (attachedEntity == null) throw new ArgumentNullException(nameof(attachedEntity));
            if (navigationProperty == null) throw new ArgumentNullException(nameof(navigationProperty));

            var dbContext = _context as DbContext ?? throw new InvalidOperationException("DbContext is not initialized");

            var entityEntry = dbContext.Entry(entity);
            if (entityEntry.State == EntityState.Detached)
            {
                dbContext.Set<T>().Attach(entity);
            }

            var attachedEntry = dbContext.Entry(attachedEntity);
            if (attachedEntry.State == EntityState.Detached)
            {
                dbContext.Set<TAttach>().Attach(attachedEntity);
            }

            try
            {
                // Получаем MemberExpression напрямую
                MemberExpression memberExpression;
                if (navigationProperty.Body is UnaryExpression unaryExpression)
                {
                    memberExpression = (MemberExpression)unaryExpression.Operand;
                }
                else
                {
                    memberExpression = navigationProperty.Body as MemberExpression
                        ?? throw new ArgumentException("Navigation property must be a property expression");
                }

                var propertyInfo = (PropertyInfo)memberExpression.Member;
                propertyInfo.SetValue(entity, attachedEntity);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to set navigation property", ex);
            }
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _entities.AddRange(entities);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
            _context.SaveChanges();
        }
    }
}
