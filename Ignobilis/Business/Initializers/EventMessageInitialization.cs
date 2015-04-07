using System;
using EPiServer;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace Ignobilis.Business.Initializers
{
    [InitializableModule]
    public class EventMessageInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            DataFactory.Instance.PublishedPage += IgnobilisService.Instance.Settings.Functionality.PageEvents.OnPublishedPage;
        }

        public void Uninitialize(InitializationEngine context)
        {
            DataFactory.Instance.PublishedPage -= IgnobilisService.Instance.Settings.Functionality.PageEvents.OnPublishedPage;
        }

        public void Preload(string[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}