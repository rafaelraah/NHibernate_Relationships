using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernate_Relationships.Models
{
    public class Carro
    {
        public virtual int Id { get; set; }
        public virtual string Marca { get; set; }
        public virtual string Modelo { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}