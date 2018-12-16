using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Models
{
    public class Apartman : BaseModel
    {
        public string ApartmanNo { get; set; }

        //public List<DaireSahibi> DaireSahipleri{ get; set; }

        public List<Daire> Daireler { get; set; }
    }
}
