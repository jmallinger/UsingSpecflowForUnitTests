using System;

namespace UsingSpecflowForUnitTests.SecureNavigation.Domain
{
    public class Permission
    {
        public static Permission AccessFeature1 = new Permission(58, "AccessFeature1");
        public static Permission AccessFeature2 = new Permission(55, "AccessFeature2");
        public static Permission AccessFeature3 = new Permission(60, "AccessFeature3");
        public static Permission ViewReport1 = new Permission(84, "ViewReport1");
        public static Permission AccessFeature4 = new Permission(57, "AccessFeature4");
        public static Permission ViewReport2 = new Permission(73, "ViewReport2");
        public static Permission ViewReport3 = new Permission(24, "ViewReport3");
        public static Permission AccessUtility1 = new Permission(2, "AccessUtility1");
        public static Permission AccessFeature5 = new Permission(97, "AccessFeature5");
        public static Permission AccessUtility2 = new Permission(88, "AccessUtility2");
        public static Permission ViewReport4 = new Permission(134, "ViewReport4");
        





        public int PermissionId { get; private set; }

        public String Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Permission"/> class.
        /// </summary>
        /// <param name="permissionId">The permission id.</param>
        /// <param name="name">The name.</param>
        public Permission(int permissionId, string name)
        {
            PermissionId = permissionId;
            Name = name;
        }




        public bool Equals(Permission other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return other.PermissionId == PermissionId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != typeof(Permission))
                return false;
            return Equals((Permission)obj);
        }

        public override int GetHashCode()
        {
            return PermissionId;
        }



        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Permission"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Permission(string value)
        {
            return Parse(value);
        }


        /// <summary>
        /// Parses the specified section name.
        /// </summary>
        /// <param name="permissionName">Name of the section.</param>
        /// <returns></returns>
        public static Permission Parse(string permissionName)
        {
            if (permissionName.EqualsIgnoreCase(AccessFeature5.Name)) return AccessFeature5;
            if (permissionName.EqualsIgnoreCase(ViewReport2.Name)) return ViewReport2;
            if (permissionName.EqualsIgnoreCase(AccessFeature2.Name)) return AccessFeature2;
            if (permissionName.EqualsIgnoreCase(AccessFeature1.Name)) return AccessFeature1;
            if (permissionName.EqualsIgnoreCase(AccessFeature4.Name)) return AccessFeature4;
            if (permissionName.EqualsIgnoreCase(AccessFeature3.Name)) return AccessFeature3;
            if (permissionName.EqualsIgnoreCase(ViewReport1.Name)) return ViewReport1;
            if (permissionName.EqualsIgnoreCase(AccessUtility2.Name)) return AccessUtility2;
            if (permissionName.EqualsIgnoreCase(ViewReport4.Name)) return ViewReport4;
            if (permissionName.EqualsIgnoreCase(ViewReport3.Name)) return ViewReport3;
            if (permissionName.EqualsIgnoreCase(AccessUtility1.Name)) return AccessUtility1;
            

            throw new Exception(string.Format("Unhandled permissionName value received: '{0}'", permissionName));
        }


    }
}
