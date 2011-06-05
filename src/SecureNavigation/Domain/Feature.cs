
namespace UsingSpecflowForUnitTests.SecureNavigation.Domain
{
    public class Feature
    {
        public string DisplayName { get; set; }
        public string GroupName { get; set; }
        public NavigationSection Section { get; set; }
        public string Url { get; set; }
        public Permission Permission { get; set; }
        public ApplicationModule Module { get; set; }
    }
}