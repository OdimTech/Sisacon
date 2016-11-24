using Sisacon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sisacon.BLL
{
    public class AutomaticCode
    {
        public string createAutomaticCode(object obj, int idUser)
        {
            var newCode = string.Empty;
            var randomNumber = Utilities.createRandonNumber();

            try
            {
                //CLIENTE
                if(obj.GetType() == typeof(Client))
                {
                    var clients = new ClientBLL().getClientListByUser(idUser).Value;

                    newCode = "CLT" + randomNumber.ToString();

                    if(clients == null || clients.Count == 0)
                    {
                        return newCode;
                    }

                    if(validateNewCode(clients.Select(x => x.CodCliente).ToList(), newCode))
                    {
                        return newCode;
                    }
                    else
                    {
                        createAutomaticCode(new Client(), idUser);
                    }
                }
                //PROVIDER
                else if(obj.GetType() == typeof(Provider))
                {
                    var providers = new ProviderBLL().getProvidersByUserId(idUser).Value;

                    newCode = "FRN" + randomNumber.ToString();

                    if(providers == null || providers.Count == 0)
                    {
                        return newCode;
                    }

                    if(validateNewCode(providers.Select(x => x.CodProvider).ToList(), newCode))
                    {
                        return newCode;
                    }
                    else
                    {
                        createAutomaticCode(new Provider(), idUser);
                    }
                }
                //EQUIPMENT
                else if(obj.GetType() == typeof(Equipment))
                {
                    var equipments = new EquipmentBLL().getEquipmentsByUserId(idUser).ValueList;

                    newCode = "EQP" + randomNumber.ToString();

                    if(equipments == null || equipments.Count == 0)
                    {
                        return newCode;
                    }

                    if(validateNewCode(equipments.Select(x => x.CodEquipment).ToList(), newCode))
                    {
                        return newCode;
                    }
                    else
                    {
                        createAutomaticCode(new Equipment(), idUser);
                    }
                }
                //MATERIAL
                else if(obj.GetType() == typeof(Material))
                {
                    var materials = new MaterialBLL().getMaterialsByUserId(idUser).ValueList;

                    newCode = "MAT" + randomNumber.ToString();

                    if(materials == null || materials.Count == 0)
                    {
                        return newCode;
                    }

                    if(validateNewCode(materials.Select(x => x.CodMaterial).ToList(), newCode))
                    {
                        return newCode;
                    }
                    else
                    {
                        createAutomaticCode(new Equipment(), idUser);
                    }
                }
            }
            catch(Exception ex)
            {
                LogBLL<string>.createLogNoResponse(ex);
            }

            return newCode;
        }

        private bool validateNewCode(List<string> listCodes, string newCode)
        {
            var codeValid = true;

            if(listCodes.Contains(newCode))
            {
                codeValid = false;
            }

            return codeValid;
        }
    }
}
