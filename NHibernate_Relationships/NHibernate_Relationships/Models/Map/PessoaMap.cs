using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernate_Relationships.Models.Map
{
    public class PessoaMap : ClassMap<Pessoa>
    {
        
        public PessoaMap()
        {
            Id(x => x.Id);
            Map(x => x.Nome);
            HasMany(x => x.Carros)
            .Inverse()
            .Cascade.AllDeleteOrphan();
         //   .KeyColumns.Add("IdPessoa", mapping => mapping.Name("Id")); ;
        }

    }
}