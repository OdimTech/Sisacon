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
    public class MaterialService : ServiceBase<Material>, IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService(IMaterialRepository materialRepository) : base(materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public List<Material> getByUserId(int userId)
        {
            try
            {
                return _materialRepository.getByUserId(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
