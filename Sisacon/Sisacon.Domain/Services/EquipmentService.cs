using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sisacon.Domain.Interfaces;
using Sisacon.Domain.Interfaces.Repositories;

namespace Sisacon.Domain.Services
{
    public class EquipmentService : ServiceBase<Equipment>, IEquipmentService
    {
        private readonly IEquipmentRepository _repository;

        public EquipmentService(IEquipmentRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public List<Equipment> getByUserId(int userId)
        {
            var listEquipment = new List<Equipment>();

            try
            {
                listEquipment = _repository.getByUserId(userId);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listEquipment;
        }
    }
}
