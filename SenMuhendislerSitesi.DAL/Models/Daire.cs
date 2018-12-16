using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Models
{
    public class Daire : BaseModel
    {
        public string DaireNo { get; set; }



        public int ApartmanId { get; set; }
        public Apartman Apartman { get; set; }

        public int KisiId { get; set; }
        public Kisi DaireSahibi{ get; set; }
        public List<Aidat> Aidatlar { get; set; }


    }
}
