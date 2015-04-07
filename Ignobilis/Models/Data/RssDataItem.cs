using System;
using System.Linq;
using System.ServiceModel.Syndication;
using EPiServer;
using Ignobilis.Business.Interfaces;

namespace Ignobilis.Models.Data
{
    public class RssDataItem : IListItem
    {
        public RssDataItem(SyndicationItem item)
        {
            var firstOrDefault = item.Links.FirstOrDefault();
            if (firstOrDefault != null)
            {
                Link = new Url(firstOrDefault.GetAbsoluteUri());
                LinkText = firstOrDefault.Title;
            }

            Title = item.Title.Text;
            if (item.Summary != null) Description = item.Summary.Text;
            PublishedDate = item.PublishDate.DateTime;

            var id = item.Id ?? "-1";

            var bytes = new byte[16];
            bytes[0] = (byte)item.GetHashCode();
            bytes[1] = (byte)item.PublishDate.Day;
            bytes[2] = (byte)item.PublishDate.Year;
            bytes[3] = (byte)item.PublishDate.Month;
            bytes[4] = (byte)item.PublishDate.Hour;
            bytes[5] = (byte)item.PublishDate.Minute;
            bytes[6] = (byte)item.PublishDate.Second;
            bytes[7] = (byte)item.Summary.GetHashCode();
            bytes[8] = (byte)id.GetHashCode();
            bytes[9] = (byte)item.Title.GetHashCode();
            
            Id = new Guid(bytes);
            IsExternal = true;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Url Link { get; set; }
        public string LinkText { get; set; }
        public Url Image { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsExternal { get; set; }
    }
}