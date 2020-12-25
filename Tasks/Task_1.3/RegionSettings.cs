using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1._3
{
    class RegionSettings : IRegionSettings
    {
        private string webSite;

        public RegionSettings(string webSite)
        {
            this.webSite = webSite;
        }

        public string WebSite => webSite;
    }
}