using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.Domain.ViewModels.AdminViewModels
{
    public class DaireViewModel : BaseViewModel
    {

        public string DaireNo { get; set; }



        public int ApartmanId { get; set; }
        public ApartmanViewModel Apartman { get; set; }

        public int KisiId { get; set; }
    }
}
