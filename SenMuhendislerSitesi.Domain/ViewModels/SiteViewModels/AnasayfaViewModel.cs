using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.Domain.ViewModels.SiteViewModels
{
    public class AnasayfaViewModel
    {
        public List<DuyuruViewModel> Duyurular { get; set; }
        public List<GaleriViewModel> Galeriler { get; set; }
        public AdresViewModel Adresler { get; set; }
    }
}
