using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.Domain.ViewModels.AdminViewModels
{
    public class DuyuruViewModel : BaseViewModel
    {
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string AltBaslik { get; set; }
        public string FotografUrl { get; set; }
        public string Fotograf { get; set; }
        public DateTime DuyuruTarihi { get; set; }

        public int KisiId { get; set; }
    }
}
