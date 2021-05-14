using Domain.Contracts;
using Domain.Entities;
using System;

namespace Repository
{
    public class BaseRepository : IBaseRepository
    {
        //método usado para gravar o pagamento gerado em uma base de dados
        public bool GravarPagamento(CobrancaResponse cobranca)
        {
            throw new NotImplementedException();
        }

        //método utilizado para atualizar o pagamento que será recebido via webhook
        public bool AtualizarStatusPagamento()
        {
            throw new NotImplementedException();
        }

        //método utilizado para obter as credenciais de integração com a gerencianet de cada cliente
        public Credenciais ObterCredenciaisGerenciaNet(int credencialId)
        {
            throw new NotImplementedException();
        }
    }
}
