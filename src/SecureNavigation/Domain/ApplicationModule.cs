using System;

namespace UsingSpecflowForUnitTests.SecureNavigation.Domain
{
    /// <summary>
    /// Container class used to represent a Touchpoint module
    /// </summary>
    public class ApplicationModule
    {
        public static ApplicationModule Sales = new ApplicationModule("Sales", 1, true);
        public static ApplicationModule FrontDesk = new ApplicationModule("FrontDesk", 2, true);
        public static ApplicationModule Hoa = new ApplicationModule("Hoa", 3, false);

        public string Name { get; protected set; }
        public int SortOrder { get; protected set; }
        public bool ShouldHostEtickets { get; protected set; }



        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationModule"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <param name="shouldHostEtickets">if set to <c>true</c> [should host etickets].</param>
        protected ApplicationModule(string name, int sortOrder, bool shouldHostEtickets)
        {
            Name = name;
            SortOrder = sortOrder;
            ShouldHostEtickets = shouldHostEtickets;
        }



        public override string ToString()
        {
            return Name;
        }



        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="ApplicationModule"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator ApplicationModule(string value)
        {
            return Parse(value);
        }


        public static ApplicationModule Parse(string moduleName)
        {
            if (moduleName.EqualsIgnoreCase(FrontDesk.Name)) return FrontDesk;
            if (moduleName.EqualsIgnoreCase(Hoa.Name)) return Hoa;
            if (moduleName.EqualsIgnoreCase(Sales.Name)) return Sales;

            throw new ApplicationException(string.Format("Unhandled moduleName received '{0}'", moduleName));
        }

    }
}
