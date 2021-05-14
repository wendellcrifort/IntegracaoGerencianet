using Domain.Contracts;
using Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Repository
{
    public class BaseIntegracao : IBaseIntegracao
    {
        //é altamente recomendável que estas informações estejam em uma tabela de controle e não fixas no código
        //private readonly string _baseUrl = "https://api-pix.gerencianet.com.br";
        //private readonly string _clientId = "Client_Id_fornecido pela gerencianet";
        //private readonly string _secret = "Client_Secret_Fornecido pela gerencianet";
        //private readonly string _pathCertificado = "caminho do certificado fornecido pela gerencia net";


        public string PagarPorPix(CobrancaRequest cobranca, string txId, Credenciais credenciais)
        {
            string token = JObject.Parse(Authorize(credenciais))["access_token"].ToString();
            int location = GerarCobrnca(token, cobranca, txId, credenciais.BaseUrl, credenciais.PathCertificado);
            return ObterQrCode(token, location, credenciais.BaseUrl, credenciais.PathCertificado);
        }

        public string Authorize(Credenciais credenciais)
        {
            var authorization = Base64Encode($@"{credenciais.ClientId}:{credenciais.Secret}");
            var client = new RestClient(@$"{credenciais.BaseUrl}/oauth/token");
            var request = new RestRequest(Method.POST);

            ObterCertificado(client, credenciais.PathCertificado);

            request.AddHeader("Authorization", "Basic " + authorization);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n    \"grant_type\": \"client_credentials\"\r\n}", ParameterType.RequestBody);

            IRestResponse restResponse = client.Execute(request);
            return restResponse.Content;
        }

        public int GerarCobrnca(string token, CobrancaRequest cobranca, string txId, string baseUrl, string pathCertificado)
        {
            var client = new RestClient(@$"{baseUrl}/v2/cob/{txId}");
            client.Timeout = -1;
            ObterCertificado(client, pathCertificado);

            var request = new RestRequest(Method.PUT);
            request.AddHeader("authorization", @$"bearer {token}");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-client-cert-pem", "{{X-Certificate-Pem}}");
            request.AddParameter("application/json", JsonConvert.SerializeObject(cobranca), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                CobrancaResponse location = JsonConvert.DeserializeObject<CobrancaResponse>(response.Content);
                return location.loc.id;
            }

            return 0;
        }

        public string ObterQrCode(string token, int location, string baseUrl, string pathCertificado)
        {
            var client = new RestClient(@$"{baseUrl}/v2/loc/{location}/qrcode");
            client.Timeout = -1;
            ObterCertificado(client, pathCertificado);
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", @$"bearer {token}");
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return JObject.Parse(response.Content)["imagemQrcode"].ToString();
            return "Não encontrado.";
        }

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        private void ObterCertificado(RestClient client, string pathCertificado)
        {
            X509Certificate2 uidCert = new X509Certificate2(pathCertificado, "");
            client.ClientCertificates = new X509CertificateCollection() { uidCert };
        }
    }
}
