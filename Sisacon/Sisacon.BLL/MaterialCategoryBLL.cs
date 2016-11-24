using Sisacon.Domain;
using Sisacon.Infra;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sisacon.BLL
{
    public class MaterialCategoryBLL
    {
        public MaterialCategoryDal MaterialCategoryDAL { get; set; }

        public MaterialCategoryBLL()
        {
            MaterialCategoryDAL = new MaterialCategoryDal();
        }

        public ResponseMessage<MaterialCategory> save(MaterialCategory materialGategory)
        {
            var response = new ResponseMessage<MaterialCategory>();

            try
            {
                response.Quantity = MaterialCategoryDAL.save(materialGategory);

                if(response.Quantity > 0)
                {
                    response.Message = Msg.SucInsertMaterialCategory;
                    response.Value = materialGategory;
                }
            }
            catch(Exception ex)
            {
                return LogBLL<MaterialCategory>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<MaterialCategory> saveList(List<MaterialCategory> listCategories)
        {
            var response = new ResponseMessage<MaterialCategory>();

            try
            {
                MaterialCategoryDAL.saveList(listCategories);
            }
            catch(Exception ex)
            {
                return LogBLL<MaterialCategory>.createLog(ex);
            }

            return response;
        }
        

        public ResponseMessage<MaterialCategory> update(MaterialCategory materialCategory)
        {
            var response = new ResponseMessage<MaterialCategory>();

            try
            {
                response.Quantity = MaterialCategoryDAL.update(materialCategory);

                if(response.Quantity > 0)
                {
                    response.Message = Msg.SucUpdMaterialCategory;
                    response.Value = materialCategory;
                }
            }
            catch(Exception ex)
            {
                return LogBLL<MaterialCategory>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<MaterialCategory> delete(int categoryId)
        {
            var response = new ResponseMessage<MaterialCategory>();

            try
            {
                if(categoryId > 0)
                {
                    var category = getCategoriesById(categoryId);

                    if(category != null)
                    {
                        if(validateBeforeDelete(category.Value))
                        {
                            category.Value.ExclusionDate = DateTime.Now;

                            response.Quantity = MaterialCategoryDAL.update(category.Value);

                            if(response.Quantity > 0)
                            {
                                response.Message = Msg.SucDeleteMaterialCategory;
                            }
                            else
                            {
                                response.Message = Msg.ErrDeleteMaterialCategory;
                            }
                        }
                        else
                        {
                            response.Message = Msg.ErrMaterialCategoryInUse;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return LogBLL<MaterialCategory>.createLog(ex);
            }

            return response;
        }

        /// <summary>
        /// Valida se existe algum material utilizando esta categoria, caso exista não será possível deleta-la
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        private bool validateBeforeDelete(MaterialCategory category)
        {
            var isValid = true;

            var materials = new MaterialDAL().getMaterialsByCategory(category.Id);

            if(materials.Count > 0)
            {
                isValid = false;
            }

            return isValid;
        }

        public ResponseMessage<MaterialCategory> getCategoriesById(int categoryId)
        {
            var response = new ResponseMessage<MaterialCategory>();

            try
            {
                response.Value = MaterialCategoryDAL.getCategoryById(categoryId);
            }
            catch(Exception ex)
            {
                return LogBLL<MaterialCategory>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<MaterialCategory> getCategoriesByUserId(int userid)
        {
            var response = new ResponseMessage<MaterialCategory>();

            try
            {
                response.ValueList = MaterialCategoryDAL.getCategoriesByUserId(userid).OrderBy(x => x.Description).ToList();
            }
            catch(Exception ex)
            {
                return LogBLL<MaterialCategory>.createLog(ex);
            }

            return response;
        }
    }
}
