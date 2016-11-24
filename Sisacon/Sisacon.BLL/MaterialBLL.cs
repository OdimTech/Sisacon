using Sisacon.Domain;
using Sisacon.Infra;
using System;
using System.Linq;

namespace Sisacon.BLL
{
    public class MaterialBLL
    {
        public MaterialDAL materialDAL { get; set; }

        public MaterialBLL()
        {
            materialDAL = new MaterialDAL();
        }

        public ResponseMessage<Material> save(Material material)
        {
            var response = new ResponseMessage<Material>();

            try
            {
                material.CodMaterial = new AutomaticCode().createAutomaticCode(material, material.User.Id);
                material.RegistrationDate = DateTime.Now;

                response.Quantity = materialDAL.save(material);

                if(response.Quantity > 0)
                {
                    response.Value = material;
                    response.Message = Msg.SucInsertMaterial;
                }
                else
                {
                    response.Value = material;
                    response.Message = Msg.ErrInsertMaterial;
                }
            }
            catch(Exception ex)
            {
                return LogBLL<Material>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<Material> update(Material material)
        {
            var response = new ResponseMessage<Material>();

            try
            {
                response.Quantity = materialDAL.update(material);

                if(response.Quantity > 0)
                {
                    response.Message = Msg.SucUpdMaterial;
                    response.Value = material;
                }
                else
                {
                    response.Message = Msg.ErrUpdMaterial;
                    response.Value = material;
                }
            }
            catch(Exception ex)
            {
                return LogBLL<Material>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<Material> delete(int id)
        {
            var response = new ResponseMessage<Material>();

            try
            {
                var material = getMaterialById(id).Value;

                if(material != null)
                {
                    material.ExclusionDate = DateTime.Now;

                    response.Quantity = materialDAL.update(material);

                    if(response.Quantity > 0)
                    {
                        response.Message = Msg.SucDeleteMaterial;
                        response.Value = material;
                    }
                    else
                    {
                        response.Message = Msg.ErrDeleteMaterial;
                        response.Value = material;
                    }
                }
            }
            catch(Exception ex)
            {
                return LogBLL<Material>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<Material> getMaterialsByUserId(int id)
        {
            var response = new ResponseMessage<Material>();

            try
            {
                response.ValueList = materialDAL.getMaterialsByUserId(id).OrderBy(x => x.Desc).ToList();
            }
            catch(Exception ex)
            {
                return LogBLL<Material>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<Material> getMaterialById(int id)
        {
            var response = new ResponseMessage<Material>();

            try
            {
                response.Value = materialDAL.getMaterialById(id);
            }
            catch(Exception ex)
            {
                return LogBLL<Material>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<Material> getMaterialsByCategory(int categoryId)
        {
            var response = new ResponseMessage<Material>();

            try
            {
                response.ValueList = materialDAL.getMaterialsByCategory(categoryId);
            }
            catch(Exception ex)
            {
                return LogBLL<Material>.createLog(ex);
            }

            return response;
        }
    }
}
