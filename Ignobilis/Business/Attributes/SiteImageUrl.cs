using EPiServer.DataAnnotations;

namespace Ignobilis.Business.Attributes
{
    public class SiteImageUrl : ImageUrlAttribute
    {
        public SiteImageUrl()
            : base(IgnobilisService.Instance.Settings.Paths.DefaultPageTypeThumbnail)
        {
        }

        public SiteImageUrl(ThumbNailPath path)
            : base(path == ThumbNailPath.Default ? IgnobilisService.Instance.Settings.Paths.DefaultPageTypeThumbnail : 
                (path == ThumbNailPath.Ordinary ? IgnobilisService.Instance.Settings.Paths.OrdinaryPageTypeThumbnail :
                (path == ThumbNailPath.Start ? IgnobilisService.Instance.Settings.Paths.StartPageTypeThumbnail : 
                IgnobilisService.Instance.Settings.Paths.DefaultPageTypeThumbnail)))
        {

        }

        public enum ThumbNailPath
        {
            Default,
            Ordinary,
            Start
        }
    }
}