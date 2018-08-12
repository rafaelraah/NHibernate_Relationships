using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernate_Relationships.Models
{
    public class TipoInvestimento
    {
        public virtual int Id { set; get; }
        public virtual string Nome { get; set; }
    }
}