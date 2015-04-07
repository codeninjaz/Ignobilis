using System;
using System.Security.Principal;
using EPiServer;
using EPiServer.Core;
using EPiServer.Personalization;
using EPiServer.ServiceLocation;
using Ignobilis.Business;
using Ignobilis.Business.Global;
using Ignobilis.Business.Interfaces;
using Ignobilis.Models.Pages;

namespace Ignobilis.Models.ViewModels
{
    public class PageViewModel<T> : IPageViewModel<T> where T : IB_BasePage
    {
        public PageViewModel(T currentPage, IPrincipal userPrincipal)
        {
            CurrentPage = currentPage;
            //Dynamisk egenskap för vilken inställningssida man använder sig utav
            var settingsPageReference = currentPage.Property[Strings.DynamicPropertySettingName].Value as ContentReference;
            if(settingsPageReference != null)
            {
                SettingsPage = ServiceLocator.Current.GetInstance<IContentRepository>().Get<IB_SettingsPage>(settingsPageReference);

                var profileType = IgnobilisService.Instance.Settings.ProfileType;
                var instance = (IProfile)Activator.CreateInstance(profileType);
                instance.Init(EPiServerProfile.Current, userPrincipal);
                Profile = instance;
            }

        }

        public T CurrentPage { get; private set; }
        //public LayoutModel Layout { get; set; }
        public IContent Section { get; set; }

        public IB_SettingsPage SettingsPage { get; set; }

        public IProfile Profile { get; set; }
    }
}