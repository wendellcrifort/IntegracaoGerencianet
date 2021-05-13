using Domain.Entidades;
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
            string txId = "fc9a4366ff3d4964b5dbc6c91a8722t8";            

            string imgBase64 = _baseIntegracao.PagarPorPix(cobranca, txId);
        }

        [TestMethod]
        public void Authorize()
        {
            _baseIntegracao.Authorize();
        }

        [TestMethod]
        public void GerarCobranca()
        {
            _baseIntegracao.GerarCobrnca("", new CobrancaRequest(), "");
        }

        [TestMethod]
        public void ObterQrCode()
        {

        }
    }
}
