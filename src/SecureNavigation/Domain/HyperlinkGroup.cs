using System.Collections.Generic;

namespace UsingSpecflowForUnitTests.SecureNavigation.Domain
{
    public class HyperlinkGroup
    {
        public string DisplayName { get; set; }
        public bool LaunchLinksInNewWindow { get; set; }
        public List<HyperlinkData> Hyperlinks { get; set; }

        public HyperlinkGroup()
        {
            Hyperlinks = new List<HyperlinkData>();
        }
    }
}