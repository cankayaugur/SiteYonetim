using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.Domain.ViewModels.SiteViewModels
{
    public class AdresViewModel : BaseViewModel
    {
        public string Mahalle { get; set; }
        public string AcikAdres { get; set; }
        public string Okul { get; set; }
        public string Benzinlik { get; set; }
        public string Carsi { get; set; }
        public string Avm { get; set; }
        public string OtobusDuragi { get; set; }
    }
}
