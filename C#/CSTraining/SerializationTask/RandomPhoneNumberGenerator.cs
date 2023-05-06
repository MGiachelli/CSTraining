using System.Text;
using System.Security.Cryptography;
using System;/*from   w ww . j  a v  a2s. c o  m*/

namespace RandomPhoneNumberGenerator
{
    public static class RandomPhoneNumberGenerator
    {
        public static string GenerateRandomPhoneNumber()
        {
   
            return string.Format("07{0}", GenerateRandomNumber(8));
        }
        /// <summary>
        /// Create a random number as a string with a maximum length.
        /// </summary>
        /// <param name="length">Length of number</param>
        /// <returns>Generated string</returns>
        public static string GenerateRandomNumber(int length)
        {
            if (length > 0)
            {
                var sb = new StringBuilder();

                var rnd = SeedRandom();
                for (int i = 0; i < length; i++)
                {
                    sb.Append(rnd.Next(0, 9).ToString());
                }

                return sb.ToString();
            }

            return string.Empty;
        }
        private static Random SeedRandom()
        {
            return new Random(Guid.NewGuid().GetHashCode());
        }       
    }
}
