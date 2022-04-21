using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using TestFuncComEF.Domain.DataAcces;
using System.Text.Json;
using TestFuncComEF.Domain.Models;

namespace TestFuncComEF.API
{
    public static class Function1
    {
        [Function("Salvar")]
        public static HttpResponseData Salvar([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {

            try
            {

                var repo = new ContatoRepository();
                string conteudo = new StreamReader(req.Body).ReadToEnd();
                repo.Salvar(JsonSerializer.Deserialize<Contato>(conteudo));

                var response = req.CreateResponse(HttpStatusCode.OK);
                response.Headers.Add("Content-Type", "application/json");                

                return response;

            }
            catch (System.Exception ex)
            {

                HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
                response.WriteString(ex.Message);
                return response;
            }
        }

        [Function("Excluir/{id}")]
        public static HttpResponseData Excluir([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req, int id)
        {

            try
            {
                var repo = new ContatoRepository();
                repo.Excluir(id);

                var response = req.CreateResponse(HttpStatusCode.OK);
                response.Headers.Add("Content-Type", "application/json");
                
                return response;
            }
            catch (System.Exception ex)
            {

                HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
                response.WriteString(ex.Message);
                return response;
            }
        }

        [Function("ObterPor/{id}")]
        public static HttpResponseData ObterPor([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req, int id)
        {
            try
            {

                var repo = new ContatoRepository();
                string conteudo = JsonSerializer.Serialize<Contato>(repo.ObterPor(id));

                var response = req.CreateResponse(HttpStatusCode.OK);
                response.Headers.Add("Content-Type", "application/json");

                response.WriteString(conteudo);

                return response;
            }
            catch (System.Exception ex)
            {

                HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
                response.WriteString(ex.Message);
                return response;
            }
        }


        [Function("ObterTodos")]
        public static HttpResponseData ObterTodos([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            try
            {

                var repo = new ContatoRepository();
                string conteudo = JsonSerializer.Serialize<List<Contato>>(repo.ObterTodos());

                var response = req.CreateResponse(HttpStatusCode.OK);
                response.Headers.Add("Content-Type", "application/json");

                response.WriteString(conteudo);

                return response;

            }
            catch (System.Exception ex)
            {

                HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
                response.WriteString(ex.Message);
                return response;
            }
        }
    }
}
