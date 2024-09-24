using Server.IEFCoreContext;
using Server.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service
{
    public class LoginService : BaseService, ILoginService
    {
        public LoginService(IEFContext dbcontext) : base(dbcontext)
        {


        }
    }
}
