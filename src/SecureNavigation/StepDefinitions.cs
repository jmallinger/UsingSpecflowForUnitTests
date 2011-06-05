using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using TechTalk.SpecFlow;
using UsingSpecflowForUnitTests.SecureNavigation.Domain;

namespace UsingSpecflowForUnitTests.SecureNavigation
{
    [Binding]
    public class StepDefinitions
    {
        protected IFeatureRepository featureRepository = MockRepository.GenerateStub<IFeatureRepository>();
        protected IETicketRepository eTicketRepository = MockRepository.GenerateStub<IETicketRepository>();
        protected IAuthorizationService authorizationService = MockRepository.GenerateStub<IAuthorizationService>();

        protected IEnumerable<Feature> sampleListOfFeatures;
        protected IEnumerable<ETicket> sampleListOfEtickets;

        protected INavigationService dashboardService;
        protected NavigationHyperlinks actualHyperlinks;



        [Given("a feature-to-privilege mapping of:")]
        public void GivenAFeaturePrivilegeMappingOf(Table featurePrivilegeTable)
        {
            // TODO: Module/Permission/Section are not populated b/c they are not primitives, need to add support for StepArgumentTransformation
            // sampleListOfFeatures = featurePrivilegeTable.CreateSet<Feature>();
            {
                sampleListOfFeatures = (from row in featurePrivilegeTable.Rows
                                        select new Feature
                                           {
                                               DisplayName = row["DisplayName"],
                                               GroupName = row["GroupName"],
                                               Section = row["Section"],
                                               Permission = row["Permission"],
                                               Module = row["Module"],
                                           }
                                        ).ToList();
            }


            featureRepository.Stub(x => x.GetAllFeatures()).Return(sampleListOfFeatures);
        }

        [Given(@"a set of ETickets of:")]
        public void GivenASetOfETicketsOf(Table eticketsTable)
        {
            // TODO: Url is not populated b/c it is not a primitive, need to add support for StepArgumentTransformation
            // sampleListOfEtickets = eticketsTable.CreateSet<ETicket>();
            {
                sampleListOfEtickets = (from row in eticketsTable.Rows
                                        select new ETicket
                                        {
                                            Name = row["Name"],
                                            Url = new Uri(row["Url"]),
                                        }
                                        ).ToList();
            }

            eTicketRepository.Stub(x => x.GetAllETickets()).Return(sampleListOfEtickets);
        }

        [Given(@"the privileges of the user accessing the system is:")]
        public void GivenAnAccessControlListOf(Table accessControlTable)
        {
            var permissionSet = from tableRow in accessControlTable.Rows
                                select tableRow["Permission"];

            foreach (var permission in permissionSet)
            {
                var currentPermission = permission;
                authorizationService.Stub(x => x.HasAccessTo(currentPermission)).Return(true);
            }
        }


        [When(@"requesting the (.*) hyperlinks the current user can access")]
        public void WhenRequestingTheHyperlinksTheCurrentUserCanAccess(string moduleName)
        {
            dashboardService = new NavigationService(authorizationService, eTicketRepository, featureRepository);
            actualHyperlinks = dashboardService.ResolveNavigationHyperlinks(ApplicationModule.Parse(moduleName));
        }



        [Then(@"the following hyperlinks should be available:")]
        public void ThenTheFollowingHyperlinksShouldBeAvailable(string expectedHyperlinksAsMultilineText)
        {
            var actualHyperlinksAsMultilineText = ToMultilineText(actualHyperlinks);

            Assert.That(actualHyperlinksAsMultilineText, Is.EqualTo(expectedHyperlinksAsMultilineText));
        }


        private static string ToMultilineText(NavigationHyperlinks hyperlinks)
        {
            var builder = new StringBuilder();

            AppendSection(builder, "ApplicationSection", hyperlinks.ApplicationSection);
            AppendSection(builder, "UtilitiesSection", hyperlinks.UtilitiesSection);
            AppendSection(builder, "ReportsSection", hyperlinks.ReportsSection);

            return builder.ToString().Trim(Environment.NewLine.ToCharArray());
        }

        private static void AppendSection(StringBuilder builder, string sectionName, IEnumerable<HyperlinkGroup> hyperlinkGroups)
        {
            if (!hyperlinkGroups.Any()) return;

            builder.AppendLine(sectionName);
            foreach (var hyperlinkGroup in hyperlinkGroups)
            {
                builder.AppendFormat("\t{0}", hyperlinkGroup.DisplayName);
                builder.AppendLine();

                foreach (var hyperlink in hyperlinkGroup.Hyperlinks)
                {
                    builder.AppendFormat("\t\t{0}", hyperlink.Title);
                    builder.AppendLine();
                }
            }
        }


    }


}