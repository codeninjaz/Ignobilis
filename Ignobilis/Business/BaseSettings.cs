using System;
using System.Collections.Generic;
using Ignobilis.Business.Functionality;
using Ignobilis.Business.Interfaces;
using Ignobilis.Models.Pages;

namespace Ignobilis.Business
{
    public class BaseSettings : ISettings
    {
        public BaseSettings()
        {
            Paths = new BasePaths();
            Functionality = new BaseFunctionality();
            ProfileType = typeof (PublicProfile);
            CssClasses = new List<string>();
        }
        public IPaths Paths { get; set; }

        public List<string> CssClasses { get; set;}

        private Dictionary<Type, String> _pageGroupsDictionary = 
            new Dictionary<Type, string>()
            {
                {typeof(IB_OrdinaryPage), "Innehåll"}, 
                {typeof(IB_StartPage), "Struktur"}
            }; 
        public Dictionary<Type, string> PageGroupsDictionary { get { return _pageGroupsDictionary; } set
        {
            _pageGroupsDictionary = value;
        } }

        private List<String> _tabNamesList = new List<string>()
                                             {
                                                 "Innehåll",
                                                 "Avancerade inställningar"
                                             };

        public List<string> TabNamesList
        {
            get { return _tabNamesList; }
            set { _tabNamesList = value; }
        }

        public IFunctionality Functionality { get; set; }
        public Type ProfileType { get; set; }
        public string ConnectionString { get; set; }
    }
}