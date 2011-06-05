using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using TechTalk.SpecFlow;
using UsingSpecflowForUnitTests.BillingInstallmentDates.Domain;

namespace UsingSpecflowForUnitTests.BillingInstallmentDates
{
    [Binding]
    public class StepDefinitions
    {
        ITimeService _timeService = MockRepository.GenerateStub<ITimeService>();
        IBillingInstallmentDateRepository _installmentDateRepo = MockRepository.GenerateStub<IBillingInstallmentDateRepository>();
        private BillingInstallmentDateService _installmentDateService;

        private List<BillingInstallmentDate> _billingInstallmentDates;
        private string _resortId;

        [Given(@"a billing schedule of:")]
        public void GivenABillingScheduleOf(Table billingSchedule)
        {
            _billingInstallmentDates = (from row in billingSchedule.Rows
                                        select new BillingInstallmentDate
                                                   {
                                                       Date = Convert.ToDateTime(row["Date"]),
                                                       InstallmentPhase = InstallmentDateType.Parse(Convert.ToInt32(row["InstallmentDateTypeId"])),
                                                       ResortId = row["ResortId"]
                                                   }
                                       ).ToList();

            _resortId = _billingInstallmentDates[0].ResortId;

            _installmentDateRepo.Stub(x => x.GetInstallmentDatesForResort(_resortId)).Return(_billingInstallmentDates);
        }

        [When(@"requesting the installment date range for (.*)")]
        public void WhenRequestingTheInstallmentDateRangeFor(DateTime asOfDate)
        {
            var installmentDatesForStart = (from installmentDate in _billingInstallmentDates
                                             where installmentDate.InstallmentPhase.Equals(InstallmentDateType.Q1)
                                             select installmentDate).DefaultIfEmpty(new BillingInstallmentDate()).ToList();

            _timeService.Stub(x => x.Today).Return(asOfDate);
            _installmentDateRepo.Stub(x => x.GetInstallmentDatesForResortAndInstallmentType(_resortId, InstallmentDateType.Q1)).Return(installmentDatesForStart);
        }

        [Then(@"the resulting range should be (.*) and (.*)")]
        public void ThenTheResultingRangeShouldBeBetween(DateTime expectedStartDate, DateTime expectedEndDate)
        {
            _installmentDateService = new BillingInstallmentDateService(_timeService, _installmentDateRepo);

            var actualStartDate = _installmentDateService.GetStartDate(_resortId);
            var actualEndDate = _installmentDateService.GetEndDate(_resortId);

            Assert.That(actualStartDate, Is.EqualTo(expectedStartDate));
            Assert.That(actualEndDate, Is.EqualTo(expectedEndDate));
        }

    }
}