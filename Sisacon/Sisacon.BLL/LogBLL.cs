using Sisacon.Domain;
using System;
using System.Net;

namespace Sisacon.BLL
{
    public static class LogBLL<T> where T : class
    {
        /// <summary>
        /// Cria Log de Erro do Sistema
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <returns></returns>
        public static ResponseMessage<T> createLog(Exception ex)
        {
            //Salvar log

            //Enviar email para admin

            return createResponse();
        }

        /// <summary>
        /// Cria Log de erro no sistema sem retornar nenhuma mensagem para a tela
        /// </summary>
        /// <param name="ex"></param>
        public static void createLogNoResponse(Exception ex)
        {
            //salvar log
        }

        private static ResponseMessage<T> createResponse()
        {
            var response = new ResponseMessage<T>();

            response.StatusCode = HttpStatusCode.BadRequest;
            response.Message = Msg.ProcessError;

            return response;
        }
    }
}
