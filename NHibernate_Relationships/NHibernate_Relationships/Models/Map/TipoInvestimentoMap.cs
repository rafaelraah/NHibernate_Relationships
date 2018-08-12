using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernate_Relationships.Models.Map
{
    public class TipoInvestimentoMap : ClassMap<TipoInvestimento>
    {
        
        public TipoInvestimentoMap()
        {
            Id(x => x.Id);
            Map(x => x.Nome);
        }

    }
}