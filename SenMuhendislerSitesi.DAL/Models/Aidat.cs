using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Models
{
    public class Aidat : BaseModel
    {
        public int Tutar { get; set; }
        public bool OdendiMi { get; set; }

        public int DaireId { get; set; }
        public Daire Daire{ get; set; }
    }
}
