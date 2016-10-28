using Sisacon.Domain;
using Sisacon.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sisacon.Infra
{
    public class UserDAL
    {
        /// <summary>
        /// Retorna um usuário de acordo com o Id informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User getUserById(int id)
        {
            var user = new User();

            try
            {
                using (var context = new SisaconDbContext())
                {
                    user = context.User.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }

        /// <summary>
        /// Valida o acesso do usuario ao sistema
        /// </summary>
        /// <param name="pass">Senha criptografada</param>
        /// <param name="email">Email</param>
        /// <returns></returns>
        public User logon(string pass, string email)
        {
            var user = new User();

            try
            {
                using (var context = new SisaconDbContext())
                {
                    user = context.User.Where(x => x.Password == pass && x.Email == email).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }

        /// <summary>
        /// Insere um novo usuário no Sistema
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Quantidade de registros inseridos no banco de dados</returns>
        public int registerUser(User user)
        {
            int addedLines = 0;

            try
            {
                using (var context = new SisaconDbContext())
                {
                    context.User.Add(user);

                    addedLines = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return addedLines;
        }

        /// <summary>
        /// Obtem do banco de dados os email de usuários já cadastrados
        /// </summary>
        /// <returns></returns>
        public List<string> getUsedEmail()
        {
            var emailList = new List<string>();

            try
            {
                using (var context = new SisaconDbContext())
                {
                    emailList = context.User
                        .Where(x => x.Active == true && x.ExclusionDate == null)
                        .Select(x => x.Email)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return emailList;
        }

        /// <summary>
        /// Atualiza as informações do Usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Quantidade de linhas alteradas</returns>
        public int update(User user)
        {
            int updatedRows = 0;

            try
            {
                using (var context = new SisaconDbContext())
                {
                    context.Entry(user).State = EntityState.Modified;
                    updatedRows = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return updatedRows;
        }
    }
}
