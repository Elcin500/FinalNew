﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalNew.Models.Entity
{
    public class NMRDistrict
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

    }
}
