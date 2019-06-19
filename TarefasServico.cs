using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ConectandoServicoRest.Model;
using System.Threading.Tasks;
using System.Net.Http;

namespace ConectandoServicoRest.Servico
{

   public class TarefasServico
    {

        HttpClient client = new HttpClient();
            private static string EnderecoBase = "http://localhost:51708/api/";
            public async Task<List<Tarefas>> GetTarefasAsync()
            {
                var URL = EnderecoBase + "/tarefas";

                HttpClient requisicao = new HttpClient();
                HttpResponseMessage resposta = await requisicao.GetAsync(URL);

                if (resposta.StatusCode == HttpStatusCode.OK)
                {
                    string conteudo = await resposta.Content.ReadAsStringAsync();

                    if (conteudo.Length > 2)
                    {
                        List<Tarefas> lista = JsonConvert.DeserializeObject<List<Tarefas>>(conteudo);
                        return lista;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception("Código de Erro HTTP: " + resposta.StatusCode);
                }
            }
            
        }
    }




