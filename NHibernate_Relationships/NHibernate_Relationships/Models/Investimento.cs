using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernate_Relationships.Models
{
    public class Investimento
    {
        public virtual int Id { set; get; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual TipoInvestimento TipoInvestimento { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual DateTime DataCriacao { get; set; }
    }
}