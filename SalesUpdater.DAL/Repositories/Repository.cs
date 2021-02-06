using AutoMapper;
using SalesStatisticsService.DataAccessLayer.Support;
using SalesUpdater.Entity;
using SalesUpdater.Interfaces.Core.DataTransferObject;
using SalesUpdater.Interfaces.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SalesUpdater.DAL.Repositories
{
    public abstract class Repository<TDTO, TEntity> : IRepository<TDTO>
        where TDTO : DataTransferObject where TEntity : class
    {
        protected readonly SalesContext _context;

        protected readonly IDbSet<TEntity> DbSet;

        protected readonly IMapper _mapper;

        protected Repository(SalesContext context, IMapper mapper)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
            _mapper = mapper;
        }

        protected virtual TEntity DTOtoEntity(TDTO dto)
        {
            return _mapper.Map<TEntity>(dto);
        }

        public void Add(params TDTO[] models)
        {
            foreach (var model in models)
            {
                var entity = DTOtoEntity(model);
                DbSet.Add(entity);
                _context.Entry(entity).State = EntityState.Added;
            }
        }

        public void Remove(params TDTO[] models)
        {
            foreach(var model in models)
            {
                var entity = DTOtoEntity(model);
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    DbSet.Attach(entity);
                }
                DbSet.Remove(entity);
                _context.Entry(entity).State = EntityState.Deleted;
            }
        }

        public void Update(params TDTO[] entities)
        {
            foreach (var model in entities)
            {
                var entity = DTOtoEntity(model);
                DbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        public TDTO Get(int ID)
        {
            return _mapper.Map<TDTO>(DbSet.Find(ID));
        }

        public IEnumerable<TDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<TDTO>>(DbSet.AsNoTracking());
        }

        public IEnumerable<TDTO> Find(Expression<Func<TDTO, bool>> predicate)
        {
            var newPredicate = predicate.GetPredicate<TDTO, TEntity>();

            return _mapper.Map<IEnumerable<TDTO>>(DbSet.AsNoTracking().Where(newPredicate));
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
