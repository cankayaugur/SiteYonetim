using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SenMuhendislerSitesi.DAL.Models;
using SenMuhendislerSitesi.DAL.Repository;
using SenMuhendislerSitesi.DAL.UnitOfWork;

namespace SenMuhendislerSitesi.Services.AdminServices
{
    public class AidatService : BaseService
    {
        public readonly Repository<Aidat> _aidatRepository;
        public AidatService(UnitOfWork uow) : base(uow)
        {
            _aidatRepository = new Repository<Aidat>(uow);
        }
    }
}
