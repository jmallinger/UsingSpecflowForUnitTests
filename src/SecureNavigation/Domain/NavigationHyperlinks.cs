using System.Collections.Generic;

namespace UsingSpecflowForUnitTests.SecureNavigation.Domain
{
    public class NavigationHyperlinks
    {
        public List<HyperlinkGroup> ApplicationSection { get; set; }
        public List<HyperlinkGroup> UtilitiesSection { get; set; }
        public List<HyperlinkGroup> ReportsSection { get; set; }

        public NavigationHyperlinks()
        {
            ApplicationSection = new List<HyperlinkGroup>();
            UtilitiesSection = new List<HyperlinkGroup>();
            ReportsSection = new List<HyperlinkGroup>();
        }
    }
}