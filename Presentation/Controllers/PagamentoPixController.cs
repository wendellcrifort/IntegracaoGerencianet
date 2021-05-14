using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PocPagamentoPix.Controllers
{    
    [Route("api/[controller]")]
    public class PagamentoPixController : Controller
    {
        private readonly IBaseIntegracao _baseIntegracao;
        private readonly IBaseRepository _baseRepository;
        public PagamentoPixController(IBaseIntegracao baseIntegracao, IBaseRepository baseRepository)
        {
            _baseIntegracao = baseIntegracao;
            _baseRepository = baseRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Método que registra o pagamento via pix e retorna o qrCode em base64
        /// </summary>
        /// <param name="payLoad">Dados do pagamento a ser gerado</param>
        /// <param name="txId">Id único do pagamento</param>
        /// <param name="credencialId">Id unico das credenciais</param>
        /// <returns>Retorna um base64 que representa o qrCode</returns>
        [HttpPost]
        public IActionResult Post([FromBody]CobrancaRequest payLoad, string txId, int credencialId)
        {
            Credenciais credenciais = _baseRepository.ObterCredenciaisGerenciaNet(credencialId);
            payLoad.chave = credenciais.chave;
            string imagem = _baseIntegracao.PagarPorPix(payLoad, txId, credenciais);
            return Ok(imagem);
        }
    }
}
