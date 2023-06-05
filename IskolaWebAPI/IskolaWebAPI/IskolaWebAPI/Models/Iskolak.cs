using System;
using System.Collections.Generic;

namespace IskolaWebAPI.Models
{
    public partial class Iskolak
    {
        public Iskolak()
        {
            Diakoks = new HashSet<Diakok>();
        }

        public int Id { get; set; }
        public int IskolaId { get; set; }
        public string Nev { get; set; } = null!;
        public byte[] SmallLogo { get; set; } = null!;

        public virtual Iskolalogok? Iskolalogok { get; set; }

        public virtual ICollection<Diakok> Diakoks { get; set; }
    }
}
