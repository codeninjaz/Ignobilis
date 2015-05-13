using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using Ignobilis.Business.Interfaces;

namespace Ignobilis.Business.Functionality
{
    public class BreadCrumb : IBreadCrumb
    {
        public BreadCrumb()
        {
            Seperator = "/";
            Message = "du är här:";            
        }

        public List<IContent> Load(ContentReference currentPage)
        {
            var enumerable = ServiceLocator.Current.GetInstance<IContentRepository>().GetAncestors(currentPage);

            var contents = enumerable as IList<IContent> ?? enumerable.ToList();
            var resultList = new List<IContent>();
            
            foreach (var item in contents.Reverse())
            {
                var pageData = item as PageData;
                if (pageData != null && pageData.VisibleInMenu && pageData.PageLink != ContentReference.RootPage)
                {
                    resultList.Add(pageData);
                }
            }

            var content = ServiceLocator.Current.GetInstance<IContentRepository>().Get<IContent>(currentPage);
            if(content != null)
            {
                resultList.Add(content);
            }

            return resultList;
        }

        public string Seperator { get; set; }
        public string Message { get; set; }        
    }
}