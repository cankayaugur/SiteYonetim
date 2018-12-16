﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.Domain
{
    public class BaseViewModel
    {
        public int Id { get; set; }
        public bool Durum { get; set; }
        public bool SilindiMi { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public DateTime? GuncellemeTarihi { get; set; }
    }
}
