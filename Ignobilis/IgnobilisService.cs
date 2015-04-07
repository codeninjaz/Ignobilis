using System.ComponentModel;
using Ignobilis.Business;
using Ignobilis.Business.Interfaces;

namespace Ignobilis
{
    public class IgnobilisService
    {
        private IgnobilisService(){}

        private static object syncLock = new object();

        private static IgnobilisService _instance;

        [Description("Will return a service initilized with BaseSettings, to override, use Init(ISettings)")]
        public static IgnobilisService Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Support multithreaded applications through
                    // 'Double checked locking' pattern which (once
                    // the instance exists) avoids locking each
                    // time the method is invoked
                    lock (syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new IgnobilisService();
                            _instance.Init(new BaseSettings());
                        }
                    }
                }

                return _instance;
            }
        }

        
        public void Init(ISettings settings)
        {
            Settings = settings;
        }


        public ISettings Settings { get; set; }

    }
}