using SalesUpdater.Interfaces.Core.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SalesUpdater.Interfaces.DAL.Repositories
{
    public interface IRepository<TDTO> where TDTO:DataTransferObject
    {
        void Add(params TDTO[] models);

        void Remove(params TDTO[] models);

        void Update(params TDTO[] models);

        TDTO Get(int ID);

        IEnumerable<TDTO> GetAll();

        IEnumerable<TDTO> Find(Expression<Func<TDTO, bool>> predicate);

        void Save();
    }
}
