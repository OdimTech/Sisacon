﻿using System;
using System.Collections.Generic;

namespace Sisacon.Domain.Interfaces
{
    public interface IRepositoryBase<T> : IDisposable where T : class
    {
        void attach(T obj);
        void add(T obj);
        void update(T obj);
        void delete(int id);
        T getById(int id);
        List<T> getAll();
        int commit();
        void commitAsync();
        void rollback();
    }
}
