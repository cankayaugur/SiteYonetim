using SenMuhendislerSitesi.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.Services
{
    public class BaseService
    {
        public UnitOfWork _uowBase;

        public BaseService(UnitOfWork uow)
        {
            _uowBase = uow;
        }
    }
}
