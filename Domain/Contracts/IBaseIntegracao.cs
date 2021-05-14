using Domain.Entities;

namespace Domain.Contracts
{
    public interface IBaseIntegracao
    {
        /// <summary>
        /// Cria a cobrança na gerencianet e retorna o qrCode em base64
        /// </summary>
        /// <param name="cobranca">Dados da cobrança a ser gerada</param>
        /// <param name="txId">Id unico do pagamento</param>
        /// <param name="credenciais">Credenciais gerencianet do cliente</param>
        /// <returns></returns>
        string PagarPorPix(CobrancaRequest cobranca, string txId, Credenciais credenciais);

        /// <summary>
        /// Realiza o login na aplicação
        /// </summary>
        /// <param name="credenciais">Credenciais gerencianet do cliente</param>
        /// <returns>Token de autorização</returns>
        string Authorize(Credenciais credenciais);

        /// <summary>
        /// Registra a cobrança na gerencianet
        /// </summary>
        /// <param name="token">token de autorização</param>
        /// <param name="cobranca">dados da cobrança</param>
        /// <param name="txId">id unico do pagamento</param>
        /// <param name="baseUrl">url post gerencianet</param>
        /// <param name="pathCertificado">path do certificado digital fornecido pela gerencianet</param>
        /// <returns>id para lcalização do qrCode gerado</returns>
        int GerarCobrnca(string token, CobrancaRequest cobranca, string txId, string baseUrl, string pathCertificado);

        /// <summary>
        /// Busca o qrCode gerado
        /// </summary>
        /// <param name="token">token de autorização</param>
        /// <param name="location">id para localização do qrCode</param>
        /// <param name="baseUrl">url gerencianet</param>
        /// <param name="pathCertificado">path do certificado digital fornecido pela gerencianet</param>
        /// <returns>retorna o qrCode em base64</returns>
        string ObterQrCode(string token, int location, string baseUrl, string pathCertificado);
    }
}
