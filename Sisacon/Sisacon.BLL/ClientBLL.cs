using Sisacon.Domain;
using Sisacon.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using static Sisacon.Domain.ValueObjects;

namespace Sisacon.BLL
{
    public class ClientBLL
    {
        public ClientDAL clientDAL { get; set; }

        public ClientBLL()
        {
            clientDAL = new ClientDAL();
        }

        /// <summary>
        /// Insere um novo cliente no banco de dados
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public ResponseMessage<Client> save(Client client)
        {
            var response = new ResponseMessage<Client>();

            try
            {
                client.RegistrationDate = DateTime.Now;

                if(client.CodCliente == null || client.CodCliente == string.Empty)
                {
                    client.CodCliente = new AutomaticCode().createAutomaticCode(client, client.User.Id);
                }
                response.Quantity = clientDAL.save(client);

                if(response.Quantity > 0)
                {
                    response.LogicalTest = true;
                    response.Message = Msg.SucInsertClient;
                    response.eOperationType = eOperationType.Insert;
                    response.Value = client;
                }
                else
                {
                    response.LogicalTest = false;
                    response.Message = Msg.ErrInsertClient;
                }

                response.Value = client;
            }
            catch(Exception ex)
            {
                return LogBLL<Client>.createLog(ex);
            }

            return response;
        }

        /// <summary>
        /// Obtem um cliente pelo id informado
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public ResponseMessage<Client> getClientById(int id)
        {
            var response = new ResponseMessage<Client>();

            try
            {
                response.Value = clientDAL.getClientById(id);

                if(response.Value != null)
                {
                    response.LogicalTest = true;
                }
                else
                {
                    response.LogicalTest = false;
                    response.Message = "Cliente não encontrado";
                }
            }
            catch(Exception ex)
            {
                return LogBLL<Client>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<List<Client>> getClientListByUser(int idUser)
        {
            var response = new ResponseMessage<List<Client>>();
            response.ValueList = new List<List<Client>>();

            try
            {
                var clientList = clientDAL.getClientListByUser(idUser);
                var clientsF = clientList.Where(x => x.ePersonType == ePersonType.Fisica).ToList();
                var clientsJ = clientList.Where(x => x.ePersonType == ePersonType.Juridica).ToList();

                response.Value = clientList;
                response.ValueList.Add(clientsF);
                response.ValueList.Add(clientsJ);


                if(response.ValueList.Count > 0)
                {
                    response.LogicalTest = true;
                }
                else
                {
                    response.LogicalTest = true;
                }
            }
            catch(Exception ex)
            {
                return LogBLL<List<Client>>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<Client> update(Client client)
        {
            var response = new ResponseMessage<Client>();

            try
            {
                response.Quantity = clientDAL.update(client);

                if(response.Quantity > 0)
                {
                    response.Message = Msg.SucUpdateClient;
                    response.LogicalTest = true;
                    response.eOperationType = eOperationType.Update;
                    response.Value = client;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = Msg.ErrUpdateClient;
                    response.LogicalTest = false;
                }
            }
            catch(Exception ex)
            {
                return LogBLL<Client>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<Client> delete(int idClient)
        {
            var response = new ResponseMessage<Client>();

            try
            {
                var client = getClientById(idClient).Value;

                if(client != null)
                {
                    client.ExclusionDate = DateTime.Now;

                    response = update(client);

                    if(response.Quantity > 0)
                    {
                        response.Message = Msg.SucDeleteClient;
                        response.LogicalTest = true;
                    }
                    else
                    {
                        response.StatusCode = HttpStatusCode.BadRequest;
                        response.Message = Msg.ErrDeleteClient;
                    }
                }
                else
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = Msg.ErrDeleteClient;
                }
            }
            catch(Exception ex)
            {
                return LogBLL<Client>.createLog(ex);
            }

            return response;
        }
    }
}
