using System.Security.Principal;
using EPiServer.Personalization;
using Ignobilis.Business.Interfaces;

namespace Ignobilis.Business.Functionality
{
    public class PublicProfile : IProfile
    {
        public void Init(EPiServerProfile profile, IPrincipal userPrincipal)
        {
            Group = "Public";
            Principal = userPrincipal;
        }

        public string Group { get; set; }
        public IPrincipal Principal { get; set; }

    }
}