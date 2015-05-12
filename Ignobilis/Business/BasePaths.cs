using System.Collections.Generic;
using Ignobilis.Business.Interfaces;

namespace Ignobilis.Business
{
    public class BasePaths : IPaths
    {
        public BasePaths()
        {
            OrdinaryPageTypeThumbnail = BaseGraphics + "Ordinary_Page.png";
            DefaultPageTypeThumbnail = BaseGraphics + "Ordinary_Page.png";
            StartPageTypeThumbnail = BaseGraphics + "Start_Page.png";
        }

        private string _baseGraphics = "/Static/Ignobilis/gfx/";
        public string BaseGraphics { get { return _baseGraphics; } set { _baseGraphics = value; } }

        public string OrdinaryPageTypeThumbnail { get; set; }
        public string DefaultPageTypeThumbnail { get; set; }
        public string StartPageTypeThumbnail { get; set; }

        private List<string> _cssList = new List<string>
                                        {
                                            "/Static/Ignobilis/css/Base.css"
                                        }; 
        public List<string> CssList { get { return _cssList; } set { _cssList = value; } }


        private List<string> _scripts = new List<string>
                                        {
                                            "/Static/Ignobilis/Scripts/jquery-1.6.4.min.js",
                                            "/Static/Ignobilis/Scripts/jquery.signalR-2.2.0.min.js",
                                            "/signalr/hubs",
                                            "/Static/Ignobilis/Scripts/EventMessageHub.js",
                                            "/Static/Ignobilis/Scripts/Generated/vendor.js?=" + Util.AssemblyVersion(),                                        
                                            "/Static/Ignobilis/Scripts/Generated/app.js?v=" + Util.AssemblyVersion(),                                        
                                        }; 
        public List<string> Scripts { get { return _scripts; } set { _scripts = value; } }
    }
}