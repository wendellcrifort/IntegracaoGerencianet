using Domain.Contracts;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Repository
{
    public class BaseRepository : IBaseRepository
    {
        public void GravarPagamento()
        {
            throw new NotImplementedException();
        }

        public void AtualizarStatusPagamento()
        {
            throw new NotImplementedException();
        }
    }
}
