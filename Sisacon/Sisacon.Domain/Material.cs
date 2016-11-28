﻿using System.Collections.Generic;

namespace Sisacon.Domain
{
    public class Material : EntityBase
    {
        public string CodMaterial { get; set; }
        public string Desc { get; set; }
        public virtual MaterialCategory Category { get; set; }
        public virtual List<PriceResearch> ListPriceResearch { get; set; }
        public virtual User User { get; set; }
        public int CategoryId { get; set; }

        public bool isvalid()
        {
            return User != null && User.Id > 0;
        }
    }
}
