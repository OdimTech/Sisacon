using System;
using static Sisacon.Domain.ValueObjects;

namespace Sisacon.BLL
{
    public static class MsgFormater
    {
        /// <summary>
        /// Cria a mensagem que será exibida no toastr para o cliente nas operaçõs de CRUD
        /// </summary>
        /// <param name="operationType">Tipo de operaçã - INSERT, DELETE, UPDATE</param>
        /// <param name="sex">Sexo da mensagem</param>
        /// <param name="entity">Entidade que está sendo manipulada Ex: Material, Fornecedor</param>
        /// <returns></returns>
        public static string createClientCrudMessage(eOperationType operationType, eSex sex, string entity)
        {
            string message = string.Empty;

            try
            {
                switch(operationType)
                {
                    case eOperationType.Insert:
                        {
                            var messageF = "A {0} foi Salva com Sucesso!";
                            var messageM = "O {0} foi Salvo com Sucesso!";

                            message = createMessageBySex(messageF, messageM, sex, entity);
                        }
                        break;
                    case eOperationType.Update:
                        {
                            var messageF = "A {0} foi Atualizada com Sucesso!";
                            var messageM = "O {0} foi Atualizada com Sucesso!";

                            message = createMessageBySex(messageF, messageM, sex, entity);
                        }
                        break;
                    case eOperationType.Select:
                        {
                            var messageF = "A {0} foi Carregada com Sucesso!";
                            var messageM = "O {0} foi Carregado com Sucesso!";

                            message = createMessageBySex(messageF, messageM, sex, entity);
                        }
                        break;
                    case eOperationType.Delete:
                        {
                            var messageF = "A {0} foi Excluída com Sucesso!";
                            var messageM = "O {0} foi Excluído com Sucesso!";

                            message = createMessageBySex(messageF, messageM, sex, entity);
                        }
                        break;
                    default:
                        {
                            return "Operação realizada com Sucesso!";
                        }
                }
            }
            catch(Exception ex)
            {
               return LogBLL<string>.createLog(ex).Message;
            }

            return message;
        }

        public static string createErrorCrudMessage()
        {
            var errorMessage = "Não foi possível concluir a operação. Tente novamente mais tarde.";

            return errorMessage;
        }

        /// <summary>
        /// Formata a mensagem de acordo com o gênero 
        /// </summary>
        /// <param name="messageF">Mensagem para gênero masculino</param>
        /// <param name="messageM">Mensagem para gênero feminino</param>
        /// <param name="sex">genero da entidade que está sendo manipulada</param>
        /// <param name="entity">Entidade</param>
        /// <returns></returns>
        private static string createMessageBySex(string messageF, string messageM, eSex sex, string entity)
        {
            var messageFormated = string.Empty;

            switch(sex)
            {
                case eSex.Feminino:
                    {
                        messageFormated = string.Format(messageF, entity);
                    }
                    break;
                case eSex.Masculino:
                    {
                        messageFormated = string.Format(messageM, entity);
                    }
                    break;
            }

            return messageFormated;
        }
    }
}
