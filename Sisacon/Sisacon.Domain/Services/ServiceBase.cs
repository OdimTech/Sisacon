using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces;
using Sisacon.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Sisacon.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : BaseEntity
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public void delete(int id)
        {
            try
            {
                _repository.delete(id);
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
                return _repository.getAll();
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
                return _repository.getById(id);
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
                _repository.save(obj);
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
                _repository.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
