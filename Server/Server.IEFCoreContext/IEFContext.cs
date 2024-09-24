using Server.EFCore;

namespace Server.IEFCoreContext
{
    public interface IEFContext
    {
        EFCoreContext DbConnet();
    }
}