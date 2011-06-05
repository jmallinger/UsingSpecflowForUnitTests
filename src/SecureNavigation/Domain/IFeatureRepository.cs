using System.Collections.Generic;

namespace UsingSpecflowForUnitTests.SecureNavigation.Domain
{
    public interface IFeatureRepository
    {
        IEnumerable<Feature> GetAllFeatures();
    }
}