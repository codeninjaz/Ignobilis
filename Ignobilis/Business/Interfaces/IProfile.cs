using System.Security.Principal;
using EPiServer.Personalization;

namespace Ignobilis.Business.Interfaces
{
    public interface IProfile
    {
        void Init(EPiServerProfile profile, IPrincipal userPrincipal);
        string Group { get; set; }

        IPrincipal Principal { get; set; }
    }
}
