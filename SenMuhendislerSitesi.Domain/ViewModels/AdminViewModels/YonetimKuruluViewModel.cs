using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.Domain.ViewModels.AdminViewModels
{
    public class YonetimKuruluViewModel : BaseViewModel
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        //public string FotografUrl { get; set; }
        public string GorevSuresi { get; set; }

        public int KisiId { get; set; }
        public KisiViewModel KurulEkleyen { get; set; }
    }
}
