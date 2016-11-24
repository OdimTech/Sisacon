using Sisacon.Domain;
using Sisacon.Infra;
using System;

namespace Sisacon.BLL
{
    public class EquipmentBLL
    {
        public EquipmentDAL equipmentDAL { get; set; }

        public EquipmentBLL()
        {
            equipmentDAL = new EquipmentDAL();
        }


        public ResponseMessage<Equipment> save(Equipment equipment)
        {
            var response = new ResponseMessage<Equipment>();

            try
            {
                equipment.RegistrationDate = DateTime.Now;

                if(equipment.CodEquipment == null || equipment.CodEquipment == string.Empty)
                {
                    equipment.CodEquipment = new AutomaticCode().createAutomaticCode(equipment, equipment.User.Id);
                }

                response.Quantity = equipmentDAL.save(equipment);

                if(response.Quantity > 0)
                {
                    response.Message = Msg.SucInsertEquip;
                    response.Value = equipment;
                }
                else
                {
                    response.Message = Msg.ErrInsertEquip;
                    response.Value = equipment;
                }
            }
            catch(Exception ex)
            {
                return LogBLL<Equipment>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<Equipment> update(Equipment equipment)
        {
            var response = new ResponseMessage<Equipment>();

            try
            {
                response.Quantity = equipmentDAL.update(equipment);

                if(response.Quantity > 0)
                {
                    response.Message = Msg.SucUpdEquip;
                    response.Value = equipment;
                }
                else
                {
                    response.Message = Msg.ErrUpdateEquip;
                    response.Value = equipment;
                }
            }
            catch(Exception ex)
            {
                return LogBLL<Equipment>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<Equipment> delete(int id)
        {
            var response = new ResponseMessage<Equipment>();

            try
            {
                var equipment = getEquipmentById(id);

                if(equipment.Value != null)
                {
                    equipment.Value.ExcluisionDate = DateTime.Now;
                }

                response.Quantity = equipmentDAL.update(equipment.Value);

                if(response.Quantity > 0)
                {
                    response.Message = Msg.SucDeleteEquip;
                }
                else
                {
                    response.Message = Msg.ErrDeleteEquip;
                }
            }
            catch(Exception ex)
            {
                return LogBLL<Equipment>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<Equipment> getEquipmentsByUserId(int userId)
        {
            var response = new ResponseMessage<Equipment>();

            try
            {
                response.ValueList = equipmentDAL.getEquipmetsByUserId(userId);
            }
            catch(Exception ex)
            {
                return LogBLL<Equipment>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<Equipment> getEquipmentById(int id)
        {
            var response = new ResponseMessage<Equipment>();

            try
            {
                response.Value = equipmentDAL.getEquipmetById(id);
            }
            catch(Exception ex)
            {
                return LogBLL<Equipment>.createLog(ex);
            }

            return response;
        }
    }
}
