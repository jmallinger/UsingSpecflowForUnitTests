using System;
using System.Linq;

namespace UsingSpecflowForUnitTests.BillingInstallmentDates.Domain
{
    /// <summary>
    /// Service to return dates based on a given date and a billing schedule for a resort
    /// </summary>
    public class BillingInstallmentDateService : IBillingInstallmentDateService
    {
        /// <summary>
        /// Gets or sets the time service.
        /// </summary>
        /// <value>The time service.</value>
        public ITimeService TimeService { get; set; }
        /// <summary>
        /// Gets or sets the installment date repository.
        /// </summary>
        /// <value>The installment date repository.</value>
        public IBillingInstallmentDateRepository InstallmentDateRepository { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BillingInstallmentDateService"/> class.
        /// </summary>
        /// <param name="timeService">The time service.</param>
        /// <param name="billDateRepository">The bill date repository.</param>
        public BillingInstallmentDateService(ITimeService timeService, IBillingInstallmentDateRepository billDateRepository)
        {
            TimeService = timeService;
            InstallmentDateRepository = billDateRepository;
        }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <param name="resortId">The resort id.</param>
        /// <returns></returns>
        public DateTime GetStartDate(string resortId)
        {
            var installmentDatesForStartDate = InstallmentDateRepository.GetInstallmentDatesForResortAndInstallmentType(resortId, InstallmentDateType.Q1);

            return (from billingInstallmentDate in installmentDatesForStartDate
                    where billingInstallmentDate.Date <= TimeService.Today
                    orderby billingInstallmentDate.Date descending
                    select billingInstallmentDate).First().Date;
        }

        /// <summary>
        /// Gets the end date.
        /// </summary>
        /// <param name="resortId">The resort id.</param>
        /// <returns></returns>
        public DateTime GetEndDate(string resortId)
        {
            var nextInstallmentDate = GetNextInstallmentDate(resortId);

            return nextInstallmentDate.IsEmpty ? TimeService.Today : nextInstallmentDate.Date;
        }

        private BillingInstallmentDate GetNextInstallmentDate(string resortId)
        {
            var installmentDates = InstallmentDateRepository.GetInstallmentDatesForResort(resortId);

            return (from installmentDate in installmentDates
                    where installmentDate.Date > TimeService.Today
                    orderby installmentDate.Date ascending 
                    select installmentDate).DefaultIfEmpty(new BillingInstallmentDate()).First();
        }
    }
}