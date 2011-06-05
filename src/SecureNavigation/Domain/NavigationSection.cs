using System;

namespace UsingSpecflowForUnitTests.SecureNavigation.Domain
{
    public class NavigationSection
    {
        public static NavigationSection Application = new NavigationSection("Application");
        public static NavigationSection Utilities = new NavigationSection("Utilities");
        public static NavigationSection Reports = new NavigationSection("Reports");


        public string Name {get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationSection"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        protected NavigationSection(string name)
        {
            Name = name;
        }


        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="NavigationSection"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NavigationSection(string value)
        {
            return Parse(value);
        }


        /// <summary>
        /// Parses the specified section name.
        /// </summary>
        /// <param name="sectionName">Name of the section.</param>
        /// <returns></returns>
        public static NavigationSection Parse(string sectionName)
        {
            if (sectionName.EqualsIgnoreCase(Application.Name))
                return Application;
            if (sectionName.EqualsIgnoreCase(Utilities.Name))
                return Utilities;
            if (sectionName.EqualsIgnoreCase(Reports.Name))
                return Reports;

            throw new Exception(string.Format("Unhandled sectionName value received: '{0}'", sectionName));
        }

    }
}