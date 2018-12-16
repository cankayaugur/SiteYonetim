using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.Domain.ViewModels.SiteViewModels
{
    public class ApartmanViewModel : BaseViewModel
    {
        public string ApartmanNo { get; set; }
        public List<DaireViewModel> Daireler { get; set; }

    }
}
