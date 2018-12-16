using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Models
{
    public class Duyuru : BaseModel
    {
        public string Baslik{ get; set; }
        public string Icerik { get; set; }
        public string FotografUrl { get; set; }
        public string AltBaslik { get; set; }
        public DateTime DuyuruTarihi { get; set; }

        public int KisiId { get; set; }
        public Kisi Yonetici { get; set; }




    }
}
