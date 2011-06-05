using System;

namespace UsingSpecflowForUnitTests.BillingInstallmentDates.Domain
{
    ///<summary>
    /// Represents date and time-related services.
    ///</summary>
    public interface ITimeService
    {
        ///<summary>
        ///</summary>
        DateTime Now { get; }

        /// <summary>
        /// Gets today's date.
        /// </summary>
        /// <value>The today.</value>
        DateTime Today { get; }
    }
}