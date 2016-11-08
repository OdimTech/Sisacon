using Sisacon.Domain;
using Sisacon.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sisacon.Infra
{
    public class EquipmentDAL
    {
        public int save(Equipment equipment)
        {
            var addedLines = 0;

            try
            {
                using(var context = new SisaconDbContext())
                {
                    context.User.Attach(equipment.User);
                    context.Equipment.Add(equipment);

                    addedLines = context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return addedLines;
        }

        public int update(Equipment equipament)
        {
            var updatedLines = 0;

            try
            {
                using(var context = new SisaconDbContext())
                {
                    context.Entry(equipament).State = EntityState.Modified;

                    updatedLines = context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return updatedLines;
        }

        public List<Equipment> getEquipmetsByUserId(int userId)
        {
            var equipments = new List<Equipment>();

            try
            {
                using(var context = new SisaconDbContext())
                {
                    equipments = context.Equipment.Where(x => x.User.Id == userId && x.ExcluisionDate == null).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return equipments;
        }

        public Equipment getEquipmetById(int id)
        {
            var equipment = new Equipment();

            try
            {
                using(var context = new SisaconDbContext())
                {
                    equipment = context.Equipment.Where(x => x.Id == id && x.ExcluisionDate == null).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return equipment;
        }
    }
}
