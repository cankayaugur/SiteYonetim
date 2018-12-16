using SenMuhendislerSitesi.Domain.ViewModels.SiteViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.Domain.ViewModels.SiteViewModels
{
    public class DaireViewModel : BaseViewModel
    {
        public string DaireNo { get; set; }
        public ApartmanViewModel Apartman { get; set; }

    }
}
