namespace UsingSpecflowForUnitTests.SecureNavigation.Domain
{
    public interface IAuthorizationService
    {
        bool HasAccessTo(Permission requestedPermission);
    }
}