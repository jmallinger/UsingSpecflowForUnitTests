using System.Linq;
using System.Collections.Generic;

namespace UsingSpecflowForUnitTests.SecureNavigation.Domain
{
    public class NavigationService : INavigationService
    {
        public IAuthorizationService AuthorizationService { get; private set; }
        public IETicketRepository ETicketRepository { get; private set; }
        public IFeatureRepository FeatureRepository { get; private set; }


        private IEnumerable<Feature> _allFeatures;

        protected IEnumerable<Feature> AllFeatures
        {
            get
            {
                if (_allFeatures == null)
                {
                    _allFeatures = FeatureRepository.GetAllFeatures();
                }
                return _allFeatures;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationService"/> class.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="eTicketRepository">The e ticket repository.</param>
        /// <param name="featureRepository">The feature repository.</param>
        public NavigationService(IAuthorizationService authorizationService, IETicketRepository eTicketRepository, IFeatureRepository featureRepository)
        {
            AuthorizationService = authorizationService;
            ETicketRepository = eTicketRepository;
            FeatureRepository = featureRepository;
        }


        public NavigationHyperlinks ResolveNavigationHyperlinks(ApplicationModule module)
        {
            return new NavigationHyperlinks
            {
                ApplicationSection = BuildApplicationHyperlinks(module),
                UtilitiesSection = BuildUtilityHyperlinks(module),
                ReportsSection = BuildReportHyperlinks(module)
            };
        }





        private List<HyperlinkGroup> BuildApplicationHyperlinks(ApplicationModule module)
        {
            var applicationHyperlinks = new List<HyperlinkGroup>(CreateGroupsFromFeatures(module, NavigationSection.Application));

            if (module.ShouldHostEtickets)
                applicationHyperlinks.Add(CreateETicketGroup());

            return applicationHyperlinks;
        }

        private List<HyperlinkGroup> BuildUtilityHyperlinks(ApplicationModule module)
        {
            return new List<HyperlinkGroup>(CreateGroupsFromFeatures(module, NavigationSection.Utilities));
        }

        private List<HyperlinkGroup> BuildReportHyperlinks(ApplicationModule module)
        {
            return new List<HyperlinkGroup>(CreateGroupsFromFeatures(module, NavigationSection.Reports));
        }



        private IEnumerable<HyperlinkGroup> CreateGroupsFromFeatures(ApplicationModule module, NavigationSection navigationSection)
        {
            var filteredFeatures = (from feature in AllFeatures
                                    where feature.Module.Equals(module)
                                    where feature.Section.Equals(navigationSection)
                                    where AuthorizationService.HasAccessTo(feature.Permission)
                                    orderby feature.GroupName
                                    orderby feature.DisplayName
                                    select feature).ToList();

            var featureGroups = from feature in filteredFeatures
                                orderby feature.GroupName
                                group feature by feature.GroupName into featureGroup
                                select new { GroupName = featureGroup.Key, Features = featureGroup };



            var hyperlinkGroupList = new List<HyperlinkGroup>();

            foreach (var featureGroup in featureGroups)
            {
                var hyperlinkGroup = new HyperlinkGroup { DisplayName = featureGroup.GroupName };


                foreach (var feature in featureGroup.Features)
                {
                    hyperlinkGroup.Hyperlinks.Add(ConvertToHyperlinkData(feature));
                }

                hyperlinkGroupList.Add(hyperlinkGroup);
            }

            return hyperlinkGroupList;
        }

        private static HyperlinkData ConvertToHyperlinkData(Feature feature)
        {
            return new HyperlinkData
            {
                Title = feature.DisplayName,
                Url = feature.Url
            };
        }

        private HyperlinkGroup CreateETicketGroup()
        {
            return new HyperlinkGroup
            {
                DisplayName = "E-tickets",
                LaunchLinksInNewWindow = true,
                Hyperlinks = (from eTicket in ETicketRepository.GetAllETickets() orderby eTicket.Name select ConvertToHyperlinkData(eTicket)).ToList(),
            };
        }

        private static HyperlinkData ConvertToHyperlinkData(ETicket eTicket)
        {
            return new HyperlinkData
            {
                Title = eTicket.Name,
                Url = eTicket.Url.ToString()
            };
        }


    }
}