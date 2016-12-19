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

        public void add(T obj)
        {
            try
            {
                _serviceBase.add(obj);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void attach(T obj)
        {
            try
            {
                _serviceBase.attach(obj);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void commit()
        {
            try
            {
                _serviceBase.commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void commitAsync()
        {
            try
            {
                _serviceBase.commitAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
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

        public void Dispose()
        {
            try
            {
                _serviceBase.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<T> getAll()
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

        public void rollback()
        {
            try
            {
                _serviceBase.rollback();
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
                _serviceBase.add(obj);
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
