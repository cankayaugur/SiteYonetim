using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Models
{
    public class Iletisim : BaseModel
    {
        public string Konu { get; set; }
        public string Eposta { get; set; }
        public string Telefon { get; set; }
        public string Mesaj { get; set; }
    }
}
