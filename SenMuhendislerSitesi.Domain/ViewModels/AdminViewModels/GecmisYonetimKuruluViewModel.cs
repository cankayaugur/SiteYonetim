using SenMuhendislerSitesi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.Domain.ViewModels.AdminViewModels
{
    public class GecmisYonetimKuruluViewModel : BaseViewModel
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        //public string FotografUrl { get; set; }
        public string GorevSuresi { get; set; }
        public Unvan Unvan { get; set; }
        public int KisiId { get; set; }

    }
}
