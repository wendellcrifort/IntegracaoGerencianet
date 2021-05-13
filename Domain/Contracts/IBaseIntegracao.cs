using Domain.Entidades;

namespace Domain.Contracts
{
    public interface IBaseIntegracao
    {        
        string PagarPorPix(CobrancaRequest cobranca, string txId);
        string Authorize();
        int GerarCobrnca(string token, CobrancaRequest cobranca, string txId);
        string ObterQrCode(string token, int location);
    }
}
