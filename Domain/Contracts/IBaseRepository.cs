using Domain.Entities;

namespace Domain.Contracts
{
    public interface IBaseRepository
    {        
        /// <summary>
        /// método que registra a cobrança gerada em uma base de dados
        /// </summary>
        /// <param name="cobranca">Recebe o retorno da api de geração de cobrança</param>
        /// <returns>Retorna true/false para informar se a gravação foi bem sucedida</returns>
        bool GravarPagamento(CobrancaResponse cobranca);

        /// <summary>
        /// Atualiza o status do pagamento de acordo com retorno do webhook
        /// </summary>
        /// <returns>Retorna true/false para informar se a gravação foi bem sucedida</returns>
        bool AtualizarStatusPagamento();

        /// <summary>
        /// Busca as credenciais do cliente em uma base de dados
        /// </summary>
        /// <param name="credencialId">Id unico do registro no banco de dados</param>
        /// <returns>Objeto contendo as credenciais de cada cliente na gerencianet</returns>
        Credenciais ObterCredenciaisGerenciaNet(int credencialId);
    }
}
