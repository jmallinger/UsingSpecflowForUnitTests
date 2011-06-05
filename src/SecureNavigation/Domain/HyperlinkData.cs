namespace UsingSpecflowForUnitTests.SecureNavigation.Domain
{
    public class HyperlinkData
    {
        public string Title { get; set; }
        public string Url { get; set; }


        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Title: {0}, Url: {1}", Title, Url);
        }
    }
}