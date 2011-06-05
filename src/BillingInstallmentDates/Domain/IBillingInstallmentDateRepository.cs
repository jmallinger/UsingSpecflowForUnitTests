using System.Collections.Generic;

namespace UsingSpecflowForUnitTests.BillingInstallmentDates.Domain
{
    /// <summary>
    /// Interface for repositories returning billing installment data
    /// </summary>
    public interface IBillingInstallmentDateRepository
    {
        /// <summary>
        /// Gets the installment dates for resort.
        /// </summary>
        /// <param name="resortId">The resort id.</param>
        /// <returns></returns>
        List<BillingInstallmentDate> GetInstallmentDatesForResort(string resortId);
        /// <summary>
        /// Gets the type of the installment dates for resort and installment.
        /// </summary>
        /// <param name="resortId">The resort id.</param>
        /// <param name="installmentDateType">Type of the installment date.</param>
        /// <returns></returns>
        List<BillingInstallmentDate> GetInstallmentDatesForResortAndInstallmentType(string resortId, InstallmentDateType installmentDateType);
    }
}