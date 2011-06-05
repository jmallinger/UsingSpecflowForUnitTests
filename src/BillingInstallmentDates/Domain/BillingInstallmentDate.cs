using System;

namespace UsingSpecflowForUnitTests.BillingInstallmentDates.Domain
{
    /// <summary>
    /// Represents a date used in the billing schedule
    /// </summary>
    public class BillingInstallmentDate
    {
        /// <summary>
        /// Gets or sets the resort id.
        /// </summary>
        /// <value>The resort id.</value>
        public string ResortId { get; set; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }
        /// <summary>
        /// Gets or sets the installment phase.
        /// </summary>
        /// <value>The installment phase.</value>
        public InstallmentDateType InstallmentPhase { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BillingInstallmentDate"/> class.
        /// </summary>
        public BillingInstallmentDate()
        {
            ResortId = string.Empty;
            InstallmentPhase = InstallmentDateType.Unknown;
            Date = DateTime.MaxValue;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is empty.
        /// </summary>
        /// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
        public bool IsEmpty
        {
            get { return ResortId == string.Empty || 
                         InstallmentPhase == InstallmentDateType.Unknown ||
                         Date == DateTime.MaxValue; 
            }
        }
    }
}