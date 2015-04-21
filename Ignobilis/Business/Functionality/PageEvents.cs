using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using EPiServer;
using EPiServer.Cms.Shell;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using Ignobilis.Business.Api;
using Ignobilis.Business.Global;
using Ignobilis.Business.Interfaces;
using Ignobilis.Models.Pages;
using Microsoft.AspNet.SignalR;

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
            //test
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

            var hubContext = GlobalHost.ConnectionManager.GetHubContext<EventMessageHub>();
            hubContext.Clients.All.clearMessages();

            foreach (var message in EventMessages(string.Empty))
            {
                if (string.IsNullOrEmpty(message.Group))
                {
                    hubContext.Clients.All.broadcastMessage(message.Type, message.EventMessage, message.LinkUrl.ToString());
                }
                else
                {
                    hubContext.Clients.Group(message.Group.ToLower()).broadcastMessage(message.Type, message.EventMessage, message.LinkUrl.ToString());
                }
            }            
        }

    }
}