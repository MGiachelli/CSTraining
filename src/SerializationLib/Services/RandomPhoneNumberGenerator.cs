using System.Text;

namespace SerializationLib.Services
{
    public static class RandomPhoneNumberGenerator
    {
        public static String GenerateRandomPhoneNumber()
        {

            return String.Format("07{0}", GenerateRandomNumber(8));
        }
        /// <summary>
        /// Create a random number as a string with a maximum length.
        /// </summary>
        /// <param name="length">Length of number</param>
        /// <returns>Generated string</returns>
        public static String GenerateRandomNumber(Int32 length)
        {
            if (length > 0)
            {
                var sb = new StringBuilder();

                var rnd = SeedRandom();
                for (var i = 0; i < length; i++)
                {
                    sb.Append(rnd.Next(0, 9).ToString());
                }

                return sb.ToString();
            }

            return String.Empty;
        }
        private static Random SeedRandom()
        {
            return new Random(Guid.NewGuid().GetHashCode());
        }
    }
}
