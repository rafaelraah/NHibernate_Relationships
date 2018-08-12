using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernate_Relationships.Models.Map
{
    public class InvestimentoMap : ClassMap<Investimento>
    {
        
        public InvestimentoMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Valor);
            Map(x => x.DataCriacao);
            References(x => x.Pessoa).Class<Pessoa>().Columns("IdPessoa");
            References(x => x.TipoInvestimento).Class<TipoInvestimento>().Columns("IdTipoInvestimento");
        }

    }
}