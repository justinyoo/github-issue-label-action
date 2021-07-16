using System;
using System.Collections.Generic;
using System.Linq;

namespace GitHubActions.LabelIssue.ConsoleApp.Extensions
{
    /// <summary>
    /// This represents the extension entity for the <see cref="Options"/> class.
    /// </summary>
    public static class OptionsExtensions
    {
        /// <summary>
        /// Converts the given string value into an array of strings, delimited by the given delimiter.
        /// </summary>
        /// <param name="value">String value to split.</param>
        /// <param name="delimiter">Delimiter. Default is <c>comma</c>.</param>
        /// <returns>Returns the array of strings.</returns>
        public static string[] ToArray(this string value, string delimiter = ",")
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return new List<string>().ToArray();
            }

            var segments = value.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(p => p.Trim())
                                .ToArray();

            return segments;
        }
    }
}
