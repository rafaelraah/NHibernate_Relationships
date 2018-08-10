using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernate_Relationships.Models.Map
{
    public class CarroMap : ClassMap<Carro>
    {
        
        public CarroMap()
        {
            Id(x => x.Id);
            Map(x => x.Marca);
            Map(x => x.Modelo);
            References(x => x.Pessoa).Class<Pessoa>().Columns("IdPessoa");
        }

    }
}