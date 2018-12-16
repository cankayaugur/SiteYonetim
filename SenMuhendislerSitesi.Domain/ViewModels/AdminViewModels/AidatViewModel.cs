using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.Domain.ViewModels.AdminViewModels
{
    public class AidatViewModel : BaseViewModel
    {
        public int Tutar { get; set; }
        public bool OdendiMi { get; set; }

        public int DaireId { get; set; }
        public DaireViewModel Daire { get; set; }
    }
}
