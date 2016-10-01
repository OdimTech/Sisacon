using Sisacon.Domain;
using Sisacon.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sisacon.Infra
{
    public class OccupationAreaDAL
    {
        public List<OccupationArea> getListOccupationArea()
        {
            var listOccupationAreas = new List<OccupationArea>();

            try
            {
                using (var context = new SisaconDbContext())
                {
                    listOccupationAreas = context.OccupationArea.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listOccupationAreas;
        }
    }
}
