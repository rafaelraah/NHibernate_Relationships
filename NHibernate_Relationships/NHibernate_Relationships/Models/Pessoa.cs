using System.Collections.Generic;

namespace NHibernate_Relationships.Models
{
    public class Pessoa 
    {

        public Pessoa()
        {
            Carros = new List<Carro>();
            Investimentos = new List<Investimento>();
        }

        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual IEnumerable<Carro> Carros { get; set; }
        public virtual IEnumerable<Investimento> Investimentos { get; set; }
    }
}