using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using UsingSpecflowForUnitTests.SecureNavigation.Domain;

namespace UsingSpecflowForUnitTests.SecureNavigation
{
    [TestFixture]
    public class general_context
    {
        protected List<ETicket> sampleListOfEtickets;
        protected IETicketRepository eTicketRepository;

        protected List<Feature> sampleListOfFeatures;
        protected IFeatureRepository featureRepository;


        [SetUp]
        public void setup()
        {
            sampleListOfEtickets = new List<ETicket>
           {
               new ETicket { Name = "ETicket1", Url = new Uri("http://www.url1.com") },
               new ETicket { Name = "ETicket2", Url = new Uri("http://www.url2.com") },
           };

            eTicketRepository = MockRepository.GenerateStub<IETicketRepository>();
            eTicketRepository.Stub(x => x.GetAllETickets()).Return(sampleListOfEtickets);


            sampleListOfFeatures = new List<Feature>
           {
               NewFeature(Permission.AccessFeature1, ApplicationModule.FrontDesk, "Feature 1", "Front Desk Apps", NavigationSection.Application),
               NewFeature(Permission.AccessFeature2, ApplicationModule.FrontDesk, "Feature 2", "Owner Apps", NavigationSection.Application),
               NewFeature(Permission.AccessFeature3, ApplicationModule.FrontDesk, "Feature 3", "Customer Apps", NavigationSection.Application),
               NewFeature(Permission.ViewReport1, ApplicationModule.FrontDesk, "Report 1", "Front Desk Reports", NavigationSection.Reports),
               NewFeature(Permission.AccessFeature4, ApplicationModule.FrontDesk, "Feature 4", "Front Desk Apps", NavigationSection.Application),
               NewFeature(Permission.ViewReport2, ApplicationModule.FrontDesk, "Report 2", "Front Desk Reports", NavigationSection.Reports),
               NewFeature(Permission.ViewReport3, ApplicationModule.Sales, "Report 3", "Sales Reports", NavigationSection.Reports),
               NewFeature(Permission.AccessUtility1, ApplicationModule.Sales, "Utility 1", "Sales Utils", NavigationSection.Utilities),
               NewFeature(Permission.AccessFeature5, ApplicationModule.Hoa, "Feature 5", "HOA Apps", NavigationSection.Application),
               NewFeature(Permission.AccessUtility2, ApplicationModule.Hoa, "Utility 2", "HOA Utils", NavigationSection.Utilities),
               NewFeature(Permission.ViewReport4, ApplicationModule.Hoa, "Report 4", "HOA Reports", NavigationSection.Reports),
           };

            featureRepository = MockRepository.GenerateStub<IFeatureRepository>();
            featureRepository.Stub(x => x.GetAllFeatures()).Return(sampleListOfFeatures);
        }

        protected static Feature NewFeature(Permission permission, ApplicationModule module, string displayName, string groupName, NavigationSection section)
        {
            return new Feature { DisplayName = displayName, GroupName = groupName, Module = module, Permission = permission, Section = section };
        }

        protected static HyperlinkGroup NewGroup(string displayName, List<HyperlinkData> hyperlinks)
        {
            return new HyperlinkGroup { DisplayName = displayName, Hyperlinks = hyperlinks };
        }
    }

    [TestFixture]
    public class given_a_user_that_has_no_access_to_any_privileges : general_context
    {
        INavigationService dashboardService;
        NavigationHyperlinks actualHyperlinks;

        [SetUp]
        public void when_requesting_front_page_hyperlinks()
        {
            var authorizationService = MockRepository.GenerateStub<IAuthorizationService>();
            authorizationService.Stub(x => x.HasAccessTo(null)).IgnoreArguments().Return(false);

            dashboardService = new NavigationService(authorizationService, eTicketRepository, featureRepository);


            actualHyperlinks = dashboardService.ResolveNavigationHyperlinks(ApplicationModule.FrontDesk);
        }

        [Test]
        public void then_only_hyperlinks_related_to_etickets_should_be_returned_as_they_are_not_secured_resources()
        {

            var expectedHyperlinks = new NavigationHyperlinks
            {
                ApplicationSection = new List<HyperlinkGroup>
                 {
                     new HyperlinkGroup
                     {
                         DisplayName = "E-tickets",
                         Hyperlinks = new List<HyperlinkData>
                          {
                              new HyperlinkData { Title = "ETicket1", Url = "http://www.url1.com/" },
                              new HyperlinkData { Title = "ETicket2", Url = "http://www.url2.com/" }
                          }
                     }
                 },
                UtilitiesSection = new List<HyperlinkGroup>(),
                ReportsSection = new List<HyperlinkGroup>(),
            };



            // TODO: replace the following with reflection-based equality assertions
            Assert.That(actualHyperlinks.UtilitiesSection, Is.EqualTo(expectedHyperlinks.UtilitiesSection));
            Assert.That(actualHyperlinks.ReportsSection, Is.EqualTo(expectedHyperlinks.ReportsSection));

            Assert.That(actualHyperlinks.ApplicationSection.Count, Is.EqualTo(expectedHyperlinks.ApplicationSection.Count));
            Assert.That(actualHyperlinks.ApplicationSection[0].DisplayName, Is.EqualTo(expectedHyperlinks.ApplicationSection[0].DisplayName));
            Assert.That(actualHyperlinks.ApplicationSection[0].Hyperlinks.Count, Is.EqualTo(expectedHyperlinks.ApplicationSection[0].Hyperlinks.Count));
            Assert.That(actualHyperlinks.ApplicationSection[0].Hyperlinks[0].Title, Is.EqualTo(expectedHyperlinks.ApplicationSection[0].Hyperlinks[0].Title));
            Assert.That(actualHyperlinks.ApplicationSection[0].Hyperlinks[1].Title, Is.EqualTo(expectedHyperlinks.ApplicationSection[0].Hyperlinks[1].Title));
        }
    }

    [TestFixture]
    public class given_a_user_that_with_partial_access_to_front_desk_privileges : general_context
    {
        INavigationService dashboardService;
        NavigationHyperlinks actualHyperlinks;

        [SetUp]
        public void setup()
        {
            var authorizationService = MockRepository.GenerateStub<IAuthorizationService>();
            authorizationService.Stub(x => x.HasAccessTo(Permission.AccessFeature4)).Return(true);
            authorizationService.Stub(x => x.HasAccessTo(Permission.AccessFeature1)).Return(true);
            authorizationService.Stub(x => x.HasAccessTo(Permission.AccessFeature2)).Return(true);
            authorizationService.Stub(x => x.HasAccessTo(Permission.AccessFeature3)).Return(true);
            authorizationService.Stub(x => x.HasAccessTo(Permission.ViewReport2)).Return(true);
            authorizationService.Stub(x => x.HasAccessTo(Permission.ViewReport3)).Return(true);
            authorizationService.Stub(x => x.HasAccessTo(Permission.AccessUtility1)).Return(true);

            dashboardService = new NavigationService(authorizationService, eTicketRepository, featureRepository);
        }

        [Test]
        public void when_requesting_front_desk_hyperlinks___then_the_hyperlinks_related_to_the_users_privileges_should_be_returned()
        {
            actualHyperlinks = dashboardService.ResolveNavigationHyperlinks(ApplicationModule.FrontDesk);

            var expectedHyperlinks = new NavigationHyperlinks
            {
                ApplicationSection = new List<HyperlinkGroup>
                 {
                     NewGroup("Customer Apps", new List<HyperlinkData>
                          {
                              new HyperlinkData { Title = "Feature 3" },
                          }),
                     NewGroup("Front Desk Apps", new List<HyperlinkData>
                          {
                              new HyperlinkData { Title = "Feature 1" },
                              new HyperlinkData { Title = "Feature 4" },
                          }),
                     NewGroup("Owner Apps", new List<HyperlinkData>
                          {
                              new HyperlinkData { Title = "Feature 2" },
                          }),
                     NewGroup("E-tickets", new List<HyperlinkData>
                          {
                              new HyperlinkData { Title = "ETicket1", Url = "http://www.url1.com/" },
                              new HyperlinkData { Title = "ETicket2", Url = "http://www.url2.com/" },
                          }),
                 },
                UtilitiesSection = new List<HyperlinkGroup>(),
                ReportsSection = new List<HyperlinkGroup>
                 {
                     NewGroup("Front Desk Reports", new List<HyperlinkData>
                          {
                              new HyperlinkData { Title = "Report 2",  },
                          }),
                 },
            };

            // TODO: replace the following with reflection-based equality assertions
            Assert.That(actualHyperlinks.ApplicationSection.Count, Is.EqualTo(expectedHyperlinks.ApplicationSection.Count));
            Assert.That(actualHyperlinks.UtilitiesSection.Count, Is.EqualTo(expectedHyperlinks.UtilitiesSection.Count));
            Assert.That(actualHyperlinks.ReportsSection.Count, Is.EqualTo(expectedHyperlinks.ReportsSection.Count));

            // Feature 3
            Assert.That(actualHyperlinks.ApplicationSection[0].DisplayName, Is.EqualTo(expectedHyperlinks.ApplicationSection[0].DisplayName));
            Assert.That(actualHyperlinks.ApplicationSection[0].Hyperlinks.Count, Is.EqualTo(expectedHyperlinks.ApplicationSection[0].Hyperlinks.Count));
            Assert.That(actualHyperlinks.ApplicationSection[0].Hyperlinks[0].Title, Is.EqualTo(expectedHyperlinks.ApplicationSection[0].Hyperlinks[0].Title));

            // Front Desk Apps
            Assert.That(actualHyperlinks.ApplicationSection[1].DisplayName, Is.EqualTo(expectedHyperlinks.ApplicationSection[1].DisplayName));
            Assert.That(actualHyperlinks.ApplicationSection[1].Hyperlinks.Count, Is.EqualTo(expectedHyperlinks.ApplicationSection[1].Hyperlinks.Count));
            Assert.That(actualHyperlinks.ApplicationSection[1].Hyperlinks[0].Title, Is.EqualTo(expectedHyperlinks.ApplicationSection[1].Hyperlinks[0].Title));
            Assert.That(actualHyperlinks.ApplicationSection[1].Hyperlinks[1].Title, Is.EqualTo(expectedHyperlinks.ApplicationSection[1].Hyperlinks[1].Title));

            // Owner Apps
            Assert.That(actualHyperlinks.ApplicationSection[2].DisplayName, Is.EqualTo(expectedHyperlinks.ApplicationSection[2].DisplayName));
            Assert.That(actualHyperlinks.ApplicationSection[2].Hyperlinks.Count, Is.EqualTo(expectedHyperlinks.ApplicationSection[2].Hyperlinks.Count));
            Assert.That(actualHyperlinks.ApplicationSection[2].Hyperlinks[0].Title, Is.EqualTo(expectedHyperlinks.ApplicationSection[2].Hyperlinks[0].Title));

            // E-tickets
            Assert.That(actualHyperlinks.ApplicationSection[3].DisplayName, Is.EqualTo(expectedHyperlinks.ApplicationSection[3].DisplayName));
            Assert.That(actualHyperlinks.ApplicationSection[3].Hyperlinks.Count, Is.EqualTo(expectedHyperlinks.ApplicationSection[3].Hyperlinks.Count));
            Assert.That(actualHyperlinks.ApplicationSection[3].Hyperlinks[0].Title, Is.EqualTo(expectedHyperlinks.ApplicationSection[3].Hyperlinks[0].Title));
            Assert.That(actualHyperlinks.ApplicationSection[3].Hyperlinks[1].Title, Is.EqualTo(expectedHyperlinks.ApplicationSection[3].Hyperlinks[1].Title));
        }

    }

    [TestFixture]
    public class given_a_user_that_with_full_access_to_hoa_privileges : general_context
    {
        INavigationService dashboardService;
        NavigationHyperlinks actualHyperlinks;

        [SetUp]
        public void setup()
        {
            var authorizationService = MockRepository.GenerateStub<IAuthorizationService>();
            authorizationService.Stub(x => x.HasAccessTo(Permission.AccessFeature4)).Return(true);
            authorizationService.Stub(x => x.HasAccessTo(Permission.AccessFeature1)).Return(true);
            authorizationService.Stub(x => x.HasAccessTo(Permission.AccessFeature2)).Return(true);
            authorizationService.Stub(x => x.HasAccessTo(Permission.AccessFeature3)).Return(true);
            authorizationService.Stub(x => x.HasAccessTo(Permission.ViewReport2)).Return(true);
            authorizationService.Stub(x => x.HasAccessTo(Permission.ViewReport3)).Return(true);
            authorizationService.Stub(x => x.HasAccessTo(Permission.AccessUtility1)).Return(true);
            authorizationService.Stub(x => x.HasAccessTo(Permission.AccessFeature5)).Return(true);
            authorizationService.Stub(x => x.HasAccessTo(Permission.AccessUtility2)).Return(true);
            authorizationService.Stub(x => x.HasAccessTo(Permission.ViewReport4)).Return(true);

            dashboardService = new NavigationService(authorizationService, eTicketRepository, featureRepository);
        }

        [Test]
        public void when_requesting_hoa_hyperlinks___then_the_hyperlinks_related_to_the_users_privileges_should_be_returned()
        {
            actualHyperlinks = dashboardService.ResolveNavigationHyperlinks(ApplicationModule.Hoa);

            var expectedHyperlinks = new NavigationHyperlinks
            {
                ApplicationSection = new List<HyperlinkGroup>
                 {
                     NewGroup("HOA Apps", new List<HyperlinkData>
                          {
                              new HyperlinkData { Title = "Feature 5",  },
                          }),
                 },
                UtilitiesSection = new List<HyperlinkGroup>
                 {
                     NewGroup("HOA Utils", new List<HyperlinkData>
                          {
                              new HyperlinkData { Title = "Utility 2",  },
                          }),
                 },
                ReportsSection = new List<HyperlinkGroup>
                 {
                     NewGroup("HOA Reports", new List<HyperlinkData>
                          {
                              new HyperlinkData { Title = "Report 4",  },
                          }),
                 },
            };

            // TODO: replace the following with reflection-based equality assertions
            Assert.That(actualHyperlinks.ApplicationSection.Count, Is.EqualTo(expectedHyperlinks.ApplicationSection.Count));
            Assert.That(actualHyperlinks.UtilitiesSection.Count, Is.EqualTo(expectedHyperlinks.UtilitiesSection.Count));
            Assert.That(actualHyperlinks.ReportsSection.Count, Is.EqualTo(expectedHyperlinks.ReportsSection.Count));

            // HOA Apps
            Assert.That(actualHyperlinks.ApplicationSection[0].DisplayName, Is.EqualTo(expectedHyperlinks.ApplicationSection[0].DisplayName));
            Assert.That(actualHyperlinks.ApplicationSection[0].Hyperlinks.Count, Is.EqualTo(expectedHyperlinks.ApplicationSection[0].Hyperlinks.Count));
            Assert.That(actualHyperlinks.ApplicationSection[0].Hyperlinks[0].Title, Is.EqualTo(expectedHyperlinks.ApplicationSection[0].Hyperlinks[0].Title));

            // HOA Utils
            Assert.That(actualHyperlinks.UtilitiesSection[0].DisplayName, Is.EqualTo(expectedHyperlinks.UtilitiesSection[0].DisplayName));
            Assert.That(actualHyperlinks.UtilitiesSection[0].Hyperlinks.Count, Is.EqualTo(expectedHyperlinks.UtilitiesSection[0].Hyperlinks.Count));
            Assert.That(actualHyperlinks.UtilitiesSection[0].Hyperlinks[0].Title, Is.EqualTo(expectedHyperlinks.UtilitiesSection[0].Hyperlinks[0].Title));

            // HOA Reports
            Assert.That(actualHyperlinks.ReportsSection[0].DisplayName, Is.EqualTo(expectedHyperlinks.ReportsSection[0].DisplayName));
            Assert.That(actualHyperlinks.ReportsSection[0].Hyperlinks.Count, Is.EqualTo(expectedHyperlinks.ReportsSection[0].Hyperlinks.Count));
            Assert.That(actualHyperlinks.ReportsSection[0].Hyperlinks[0].Title, Is.EqualTo(expectedHyperlinks.ReportsSection[0].Hyperlinks[0].Title));
        }

    }


}
