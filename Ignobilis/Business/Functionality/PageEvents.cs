using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using Ignobilis.Business.Api;
using Ignobilis.Business.Global;
using Ignobilis.Business.Interfaces;
using Ignobilis.Models.Pages;

namespace Ignobilis.Business.Functionality
{
    public class PageEvents : IPageEvents
    {
        public List<IB_EventMessage> EventMessages(string group)
        {
            var pageData = ServiceLocator.Current.GetInstance<IContentRepository>().Get<PageData>(ContentReference.StartPage);
            var settingsPageReference = pageData.Property[Strings.DynamicPropertySettingName].Value as ContentReference;

            var settingsPage = ServiceLocator.Current.GetInstance<IContentRepository>().Get<IB_SettingsPage>(settingsPageReference);

            var result = ServiceLocator.Current.GetInstance<IContentRepository>()
            .GetChildren<IB_EventMessage>(settingsPage.EventMessageRoot)
            .Where(m => m.CheckPublishedStatus(PagePublishedStatus.Published)).ToList();

            return !group.IsNullOrEmpty() ? result.Where(m => String.Equals(m.Group, group, StringComparison.CurrentCultureIgnoreCase) || m.Group.IsNullOrEmpty()).ToList() : result;            
        }

        public void OnPublishedPage(object sender, PageEventArgs eventArgs)
        {
            var pageData = ServiceLocator.Current.GetInstance<IContentRepository>().Get<PageData>(ContentReference.StartPage);

            var settingsPageReference = pageData.Property[Strings.DynamicPropertySettingName].Value as ContentReference;
            if (settingsPageReference == null) return;

            var settingsPage = ServiceLocator.Current.GetInstance<IContentRepository>().Get<IB_SettingsPage>(settingsPageReference);
            var parent = ServiceLocator.Current.GetInstance<IContentRepository>().Get<PageData>(eventArgs.PageLink).ParentLink;
            if (parent != settingsPage.EventMessageRoot) return;

            var ibEventMessage = eventArgs.Page as IB_EventMessage;
            if (ibEventMessage == null) return;

            SignalRConnector.EventMessage.Clear();
            foreach (var message in EventMessages(string.Empty))
            {
                SignalRConnector.EventMessage.Send(message);
            }
        }

    }
}