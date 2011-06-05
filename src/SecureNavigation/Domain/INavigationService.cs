namespace UsingSpecflowForUnitTests.SecureNavigation.Domain
{
    public interface INavigationService
    {
        NavigationHyperlinks ResolveNavigationHyperlinks(ApplicationModule module);
    }
}