using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernate_Relationships.Models
{
    public class Pessoa
    {

        public Pessoa()
        {
            Carros = new List<Carro>();
        }

        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual IEnumerable<Carro> Carros { get; set; }
    }
}