namespace FxScreenshot
{
    using System;
    using System.Security;
    using System.Text;


    /// <summary>
    /// extension methods for <see cref="string"/>
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// convert byte array to hex string
        /// </summary>
        /// <param name="data">byte array to convert</param>
        /// <returns>string of hex characters</returns>
        public static string ToHexString(this byte[] data)
        {
            var builder = new StringBuilder();

            foreach (byte b in data)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// convert string to <see cref="SecureString"/>
        /// </summary>
        /// <param name="input">input string</param>
        /// <returns>secure string composed of characters from input</returns>
        public static SecureString ToSecureString(this string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }

            var secureStr = new SecureString();

            if (input.Length > 0)
            {
                foreach (var c in input.ToCharArray())
                {
                    secureStr.AppendChar(c);
                }
            }

            return secureStr;
        }

        /// <summary>
        /// escape string value for use in csv cell
        /// </summary>
        /// <param name="input">The string.</param>
        /// <returns>escaped string suitable for csv cell</returns>
        public static string StringToCsvCell(this string input)
        {
            if (input == null)
            {
                return "null";
            }

            if (string.IsNullOrWhiteSpace(input))
            {
                return $"\"{input}\"";
            }

            bool mustQuote = input.Contains(",") || input.Contains("\"") || input.Contains("\r") || input.Contains("\n");
            if (mustQuote)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("\"");

                foreach (char nextChar in input)
                {
                    sb.Append(nextChar);

                    if (nextChar == '"')
                    {
                        sb.Append("\"");
                    }
                }

                sb.Append("\"");
                return sb.ToString();
            }

            return input;
        }

        /// <summary>
        /// Simple class that contains an enum and a boolean on whether or not the enum is used (specified)
        /// </summary>
        /// <typeparam name="T">The Enum</typeparam>
        public class CodeAndSpecifiedFlag<T> where T : struct, IConvertible
        {
            /// <summary>
            /// The Enum used
            /// </summary>
            public T Code { get; set; }

            /// <summary>
            /// a flag specifying whether the emum should be used or not
            /// </summary>
            public bool Specified { get; set; }
        }

        /// <summary>
        /// Converts a string to an enum. Returns true or false based on whether it has a value or not
        /// </summary>
        /// <typeparam name="T">The enum type</typeparam>
        /// <param name="stringValue">the string to be converted to the enum</param>
        /// <param name="enumeration">The output enum variable</param>
        /// <param name="ignoreCase">Derp Derp</param>
        /// <returns>True if the stringValue is not null or empty</returns>
        private static bool ConvertStringToEnum<T>(string stringValue, out T enumeration, bool ignoreCase = false) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            if (string.IsNullOrEmpty(stringValue))
            {
                enumeration = default(T);
                return false;
            }

            if (!Enum.TryParse(stringValue, ignoreCase, out enumeration))
            {
                throw new Exception("Could not parse " + stringValue + " into irs enum " + typeof(T));
            }

            return true;
        }
    }
}
