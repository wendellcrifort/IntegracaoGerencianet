using Domain.Contracts;
using Domain.Entities;
using System;

namespace Repository
{
    public class BaseRepository : IBaseRepository
    {
        public bool GravarPagamento(CobrancaResponse cobranca)
        {
            throw new NotImplementedException();
        }

        public bool AtualizarStatusPagamento()
        {
            throw new NotImplementedException();
        }

        public Credenciais ObterCredenciaisGerenciaNet(int credencialId)
        {
            throw new NotImplementedException();
        }
    }
}
