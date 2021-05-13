using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts
{
    public interface IBaseRepository
    {        
        void GravarPagamento();
        void AtualizarStatusPagamento();
    }
}
