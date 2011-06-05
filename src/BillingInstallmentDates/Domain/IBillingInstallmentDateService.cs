using System;

namespace UsingSpecflowForUnitTests.BillingInstallmentDates.Domain
{
    /// <summary>
    /// Interface for services that return dates based on a given date and a billing schedule for a resort
    /// </summary>
    public interface IBillingInstallmentDateService
    {
        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <param name="resortId">The resort id.</param>
        /// <returns></returns>
        DateTime GetStartDate(string resortId);
        /// <summary>
        /// Gets the end date.
        /// </summary>
        /// <param name="resortId">The resort id.</param>
        /// <returns></returns>
        DateTime GetEndDate(string resortId);
    }
}