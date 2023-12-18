using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class AppUserManger : BaseManager<AppUser>, IAppUserManager
    {
        IAppUserRepository _apRep;
        public AppUserManger(IAppUserRepository apRep) : base(apRep)
        {
            _apRep = apRep;
        }

        public async Task<bool> CreateUser(AppUser item)
        {
            //todo : Blyazılır 
            return await _apRep.AddUser(item);
        }

    }
}
