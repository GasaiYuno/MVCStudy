using Server.IConfigSetting;
using Server.IEFCoreContext;

namespace Server.EFCoreContext
{
    public class EFContext : IEFContext
    {
        private IConfigSetting.IConfigSet _configset;
        public EFContext(IConfigSet configset) {

            this._configset = configset;
        }
        public EFCore.EFCoreContext DbConnet()
        {
            return new EFCore.EFCoreContext(_configset.Read("DBConnectStr"));
        }
    }
}