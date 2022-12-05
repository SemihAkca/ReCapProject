﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        void Add(T entity);
        List<T> GetAll(Expression<Func<T,bool>>filter = null);
        T Get(Expression<Func<T,bool>>filter);
        void Update(T entity);
        void Delete(T entity);
    }
}
