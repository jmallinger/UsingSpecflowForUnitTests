namespace UsingSpecflowForUnitTests.BillingInstallmentDates.Domain
{
    public class InstallmentDateType
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }


        /// <summary>
        /// Parses the specified installment date type id.
        /// </summary>
        /// <param name="installmentDateTypeId">The installment date type id.</param>
        /// <returns></returns>
        public static InstallmentDateType Parse(int installmentDateTypeId)
        {
            if (installmentDateTypeId == Q1.Id)
            {
                return Q1;
            }

            if (installmentDateTypeId == Q2.Id)
            {
                return Q2;
            }

            if (installmentDateTypeId == Q3.Id)
            {
                return Q3;
            }

            return installmentDateTypeId == Q4.Id ? Q4 : Unknown;
        }

        public static InstallmentDateType Q1 = new InstallmentDateType { Id = 1, Description = "Q1" };
        public static InstallmentDateType Q2 = new InstallmentDateType { Id = 2, Description = "Q2" };
        public static InstallmentDateType Q3 = new InstallmentDateType { Id = 3, Description = "Q3" };
        public static InstallmentDateType Q4 = new InstallmentDateType { Id = 4, Description = "Q4" };
        public static InstallmentDateType Unknown = new InstallmentDateType { Id = 0, Description = string.Empty };





        public bool Equals(InstallmentDateType other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id == Id && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(InstallmentDateType)) return false;
            return Equals((InstallmentDateType)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id * 397) ^ (Description != null ? Description.GetHashCode() : 0);
            }
        }
    }
}