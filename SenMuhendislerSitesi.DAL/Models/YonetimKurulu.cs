using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Models
{
    public class YonetimKurulu : BaseModel
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        //public string FotografUrl { get; set; }
        public string GorevSuresi { get; set; }

        public int KisiId { get; set; }
        public Kisi KurulEkleyen { get; set; }
    }
}
