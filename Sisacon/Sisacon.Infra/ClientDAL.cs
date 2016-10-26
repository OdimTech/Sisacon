using Sisacon.Domain;
using Sisacon.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sisacon.Infra
{
    public class ClientDAL
    {
        /// <summary>
        /// Insere um novo cliente no banco de dados
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public int save(Client client)
        {
            var addedLines = 0;

            try
            {
                using(var context = new SisaconDbContext())
                {
                    context.User.Attach(client.User);
                    context.Client.Add(client);

                    addedLines = context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return addedLines;
        }

        /// <summary>
        /// Obtem uma lista de clientes cadastrados de acordo com o id do usuario logado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Client> getClientListByUser(int id)
        {
            var clientList = new List<Client>();

            try
            {
                using(var context = new SisaconDbContext())
                {
                    clientList = context.Client
                        .Include("Address")
                        .Include("Contact")
                        .Where(x => x.User.Id == id && x.ExclusionDate == null)
                        .ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return clientList;
        }

        /// <summary>
        /// Obtem um cliente pelo id informado
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public Client getClientById(int clientId)
        {
            var client = new Client();

            try
            {
                using(var context = new SisaconDbContext())
                {
                    client = context.Client
                        .Include("Address")
                        .Include("Contact")
                        .Where(x => x.Id == clientId && x.ExclusionDate == null)
                        .FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return client;
        }

        /// <summary>
        /// Atualiza os dados do cliente
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public int update(Client client)
        {
            int updatedLines = 0;

            try
            {
                using(var context = new SisaconDbContext())
                {
                    context.Entry(client.Address).State = EntityState.Modified;
                    context.Entry(client.Contact).State = EntityState.Modified;
                    context.Entry(client).State = EntityState.Modified;

                    updatedLines = context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return updatedLines;
        }
    }
}
