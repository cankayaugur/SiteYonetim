using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.Domain.ViewModels.SiteViewModels
{
    public class IletisimViewModel : BaseViewModel
    {
        public string Konu { get; set; }
        public string Eposta { get; set; }
        public string Telefon { get; set; }
        public string Mesaj { get; set; }
    }
}
 