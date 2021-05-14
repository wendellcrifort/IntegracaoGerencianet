using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;

namespace MSTest
{
    [TestClass]
    public class ApiPixTest
    {
        private BaseIntegracao _baseIntegracao;

        [TestInitialize]
        public void InicializarTeste()
        {
            _baseIntegracao = new BaseIntegracao();
        }

        [TestMethod]
        public void PagarPorPix()
        {
            CobrancaRequest cobranca = PreencherCobranca();
            string txId = "fc9a4366ff3d4964b5dbc6c91a8722t8";

            string imgBase64 = _baseIntegracao.PagarPorPix(cobranca, txId, PreencherCredenciais());
        }

        [TestMethod]
        public void Authorize()
        {
            _baseIntegracao.Authorize(PreencherCredenciais());
        }

        [TestMethod]
        public void GerarCobranca()
        {
            CobrancaRequest cobranca = PreencherCobranca();
            string txId = "fc9a4366ff3d4964b5dbc6c91a8722t8";
            string token = "eyJhbGciOiJIUzI1NiIsI9.eyJ0eXBlIjoiYWNjZiJDbGllbnRfSWRfOThkMWmNiMWQ0NjM5YWFkOCIsImFjb3VudF9jb2RliNWEyM2I2ZTQ0ZWVkYzU1OTZjY2JhYzFhNjVlYmM3MjgiLCJzY29wZXMiOlsiY29iLnJlYWQiLCJjb2Iud3JpdGUiLCJnbi5iYWxhbmNlLnJlYWQiLCJnbi5waXguZXZwLnJlYWQiLCJnbi5waXguZXZwLndyaXRlIiwiZ24uc2V0dGluZ3MucmVhZCIsImduLnNldHRpbmdzLndyaXRlIiwicGF5bG9hZGxvY2F0aW9uLnJlYWQiLCJwYXlsb2FkbG9jYXRpb24ud3JpdGUiLCJwaXgucmVhZCIsInBpeC53cml0ZSIsIndlYmhvb2sucmVhZCIsIndlYmhvb2sud3JpdGUiXSwiZXhwaXJlc0luIjozNjAwLCJjb25maWd1cmF0aW9uIjp7Ing1dCNTMjU2IjoibnhYYUxXd0hGSGZpdXp2Mk1rck51b2I4T1psSjd4SnNzeitON1gvMGhKRT0ifSwiaWF0IjoxNjIwNzU4NzI0LCJleHAiOjE2MjA3NjIzMjR9.Vk-sW3xPds88vhlW-tItEeOgsQxPRNFXciA6KArOYcI";
            Credenciais credenciais = PreencherCredenciais();
            _baseIntegracao.GerarCobrnca(token, cobranca, txId, credenciais.BaseUrl, credenciais.PathCertificado);
        }

        [TestMethod]
        public void ObterQrCode()
        {
            string token = "eyJhbGciOiJIUzI1NiIsI9.eyJ0eXBlIjoiYWNjZiJDbGllbnRfSWRfOThkMWmNiMWQ0NjM5YWFkOCIsImFjb3VudF9jb2RliNWEyM2I2ZTQ0ZWVkYzU1OTZjY2JhYzFhNjVlYmM3MjgiLCJzY29wZXMiOlsiY29iLnJlYWQiLCJjb2Iud3JpdGUiLCJnbi5iYWxhbmNlLnJlYWQiLCJnbi5waXguZXZwLnJlYWQiLCJnbi5waXguZXZwLndyaXRlIiwiZ24uc2V0dGluZ3MucmVhZCIsImduLnNldHRpbmdzLndyaXRlIiwicGF5bG9hZGxvY2F0aW9uLnJlYWQiLCJwYXlsb2FkbG9jYXRpb24ud3JpdGUiLCJwaXgucmVhZCIsInBpeC53cml0ZSIsIndlYmhvb2sucmVhZCIsIndlYmhvb2sud3JpdGUiXSwiZXhwaXJlc0luIjozNjAwLCJjb25maWd1cmF0aW9uIjp7Ing1dCNTMjU2IjoibnhYYUxXd0hGSGZpdXp2Mk1rck51b2I4T1psSjd4SnNzeitON1gvMGhKRT0ifSwiaWF0IjoxNjIwNzU4NzI0LCJleHAiOjE2MjA3NjIzMjR9.Vk-sW3xPds88vhlW-tItEeOgsQxPRNFXciA6KArOYcI";
            Credenciais credenciais = PreencherCredenciais();
            _baseIntegracao.ObterQrCode(token, 1, credenciais.BaseUrl, credenciais.PathCertificado); ;
        }

        private CobrancaRequest PreencherCobranca()
        {
            CobrancaRequest cobranca = new CobrancaRequest();

            cobranca.calendario.expiracao = 3600;
            cobranca.devedor.cpf = "12345678901";
            cobranca.devedor.nome = "Joao Mario";
            cobranca.valor.original = "1.00";
            cobranca.chave = "15f8g4s7-ec70-4481-95cf-1a2d5e8f55d6";
            cobranca.solicitacaoPagador = "Informe o número ou identificador do pedido.";
            cobranca.infoAdicionais = new System.Collections.Generic.List<InfoAdicionais>()
            {
                new InfoAdicionais()
                {
                    nome = "teste",
                    valor = "valorTeste"
                }
            };

            return cobranca;
        }

        private Credenciais PreencherCredenciais()
        {
            Credenciais credenciais = new Credenciais();

            credenciais.CredenciaisID = 0;//id de localização das credenciais em nosso banco de dados
            credenciais.BaseUrl = "base url da api gerencianet";
            credenciais.chave = "chave pix de cada cliente";
            credenciais.ClientId = "Client_Id fornecido pela api gerencianet";
            credenciais.Secret = "Client_secret fornecido pela api gerencianet";
            credenciais.PathCertificado = "caminho do certificado digital fornecido pela gerencianet";           
            
            return credenciais;
        }
    }
}
