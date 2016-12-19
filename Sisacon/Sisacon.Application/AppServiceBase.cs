using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Sisacon.Application
{
    public class AppServiceBase<T> : IAppServiceBase<T> where T : BaseEntity
    {
        private readonly IServiceBase<T> _serviceBase;

        public AppServiceBase(IServiceBase<T> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void delete(int id)
        {
            try
            {
                _serviceBase.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> getAll()
        {
            try
            {
                return _serviceBase.getAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T getById(int id)
        {
            try
            {
                return _serviceBase.getById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void save(T obj)
        {
            try
            {
                _serviceBase.save(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(T obj)
        {
            try
            {
                _serviceBase.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
