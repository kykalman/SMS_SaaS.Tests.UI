using System;
using System.Linq;

namespace SMB_SaaS.Core.Utilities
{
    public enum GenerationOptions
    {
        /// <summary>
        /// Use lower case letters and numbers to generate a string.
        /// </summary>
        LowerCase,

        /// <summary>
        /// Use lower case letters only to generate a string.
        /// </summary>
        LowerCaseLetters,

        /// <summary>
        /// Use upper case letters and numbers to generate a string.
        /// </summary>
        UpperCase,

        /// <summary>
        /// Use mixed case letters and numbers to generate a string.
        /// </summary>
        MixedCase,

        /// <summary>
        /// Use numbers to generate a string.
        /// </summary>
        Numbers
    }
    public class StringGenerator
    {
        private static string chars;
        private static Random random = new Random();

        public static string GenerateString(int length, GenerationOptions options)
        {
            switch (options)
            {
                case GenerationOptions.LowerCase:
                    {
                        chars = "abcdefghijklmnopqrstuvwxyz0123456789";
                        return new string(Enumerable.Repeat(chars, length)
                          .Select(s => s[random.Next(s.Length)]).ToArray());
                    };
                case GenerationOptions.LowerCaseLetters:
                    {
                        chars = "abcdefghijklmnopqrstuvwxyz";
                        return new string(Enumerable.Repeat(chars, length)
                          .Select(s => s[random.Next(s.Length)]).ToArray());
                    };
                case GenerationOptions.UpperCase:
                    {
                        chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                        return new string(Enumerable.Repeat(chars, length)
                          .Select(s => s[random.Next(s.Length)]).ToArray());
                    };
                case GenerationOptions.MixedCase:
                    {
                        chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                        return new string(Enumerable.Repeat(chars, length)
                          .Select(s => s[random.Next(s.Length)]).ToArray());
                    };
                case GenerationOptions.Numbers:
                    {
                        chars = "0123456789";
                        return new string(Enumerable.Repeat(chars, length)
                          .Select(s => s[random.Next(s.Length)]).ToArray());
                    };
                default:
                    {
                        chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                        return new string(Enumerable.Repeat(chars, length)
                          .Select(s => s[random.Next(s.Length)]).ToArray());
                    };
            }
        }
        public static string GenerateFullName()
        {
            var FNLetter = StringGenerator.GenerateString(1, GenerationOptions.UpperCase);
            var LNLetter = StringGenerator.GenerateString(1, GenerationOptions.UpperCase);
            var FNtext = StringGenerator.GenerateString(6, GenerationOptions.LowerCase);
            var LNtext = StringGenerator.GenerateString(7, GenerationOptions.LowerCase);
            return $"{FNLetter}{FNtext} {LNLetter}{LNtext}";
        }
        public static string GeneratePhoneNumber()
        {
            return StringGenerator.GenerateString(11, GenerationOptions.Numbers);
        }
    }
}
