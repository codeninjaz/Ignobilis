using System;
using EPiServer.DataAnnotations;
using Ignobilis.Models.Pages;

namespace Ignobilis.Business.Attributes
{
    public class SiteContentType : ContentTypeAttribute
    {
        public SiteContentType()
        {
        }

        private Type _isOfType;
        public Type IsOfType
        {
            get { return _isOfType; }
            set
            {
                if (IgnobilisService.Instance.Settings.PageGroupsDictionary.ContainsKey(value))
                {
                    GroupName = IgnobilisService.Instance.Settings.PageGroupsDictionary[value];
                    _isOfType = value;
                }

                else
                {
                    GroupName = string.Empty;
                    _isOfType = typeof (IB_BasePage);
                }
            }
        }
    }
}