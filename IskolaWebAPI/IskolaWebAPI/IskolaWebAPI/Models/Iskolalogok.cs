using System;
using System.Collections.Generic;

namespace IskolaWebAPI.Models
{
    public partial class Iskolalogok
    {
        public int Id { get; set; }
        public int IskolaId { get; set; }
        public byte[] Logo { get; set; } = null!;

        public virtual Iskolak Iskola { get; set; } = null!;
    }
}
