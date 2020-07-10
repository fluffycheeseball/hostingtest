using System.Text.RegularExpressions;
using System.Net.Mail;

using static System.String;
using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Interfaces.ExtensionMethods
{
    public static class NullableStringExtensions
    {
        public static bool IsEmpty(this string?input) {
            return string.IsNullOrWhiteSpace(input);
        }

        public static bool IsNotEmpty(this string? input) {
            return !string.IsNullOrWhiteSpace(input);
        }

        public static bool IsLessThanMinLength(this string? input, int minLength) {
            return IsNullOrWhiteSpace(input) || input.Length < minLength;
        }

        public static bool IsEmailFormat(this string? input) {
            var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            bool isValid = Regex.IsMatch(input, regex, RegexOptions.IgnoreCase);
            return isValid;
        }

        public static bool IsNotEmailFormat(this string? input) {
            return !IsEmailFormat(input);
        }

        public static bool IsValidJson(this string? strInput) {
            if(strInput == null) {
                return false;
            }
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try {
                    var obj = JToken.Parse(strInput);
                    return true;
                } catch
                  {
                    return false;
                }
            } else {
                return false;
            }
        }

        public static bool IsNotValidJson(this string? input) {
            return !IsValidJson(input);
        }
    }
}
