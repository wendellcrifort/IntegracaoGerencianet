using System.Collections.Generic;

namespace Domain.Entities
{
    public class CobrancaRequest
    {
        public CobrancaRequest()
        {
            calendario = new Calendario();
            devedor = new Devedor();
            valor = new Valor();
            infoAdicionais = new List<InfoAdicionais>();
        }

        public Calendario calendario { get; set; }
        public Devedor devedor { get; set; }
        public Valor valor { get; set; }
        public List<InfoAdicionais> infoAdicionais { get; set; }
        public string chave { get; set; }
        public string solicitacaoPagador { get; set; }
    }

    public class Calendario
    {
        public int expiracao { get; set; }
    }

    public class Devedor
    {
        public string cpf { get; set; }
        public string nome { get; set; }
    }

    public class Valor
    {
        public string original { get; set; }
    }

    public class InfoAdicionais
    {
        public string nome { get; set; }
        public string valor { get; set; }
    }
}
