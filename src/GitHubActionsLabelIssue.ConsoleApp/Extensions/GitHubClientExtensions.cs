using System;

using Octokit;

namespace GitHubActions.LabelIssue.ConsoleApp.Extensions
{
    /// <summary>
    /// This represents the extension entity for the <see cref="GitHubClient"/> class.
    /// </summary>
    public static class GitHubClientExtensions
    {
        /// <summary>
        /// Adds <see cref="Credentials"/> instance.
        /// </summary>
        /// <param name="value"><see cref="GitHubClient"/> instance.</param>
        /// <param name="token">GitHub auth token.</param>
        /// <returns>Returns the <see cref="GitHubClient"/> instance.</returns>
        public static GitHubClient WithCredentials(this GitHubClient value, string token)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentNullException(nameof(token));
            }

            value.Credentials = new Credentials(token);

            return value;
        }

        /// <summary>
        /// Adds <see cref="Credentials"/> instance.
        /// </summary>
        /// <param name="value"><see cref="GitHubClient"/> instance.</param>
        /// <param name="username">GitHub username.</param>
        /// <param name="password">GitHub password.</param>
        /// <returns>Returns the <see cref="GitHubClient"/> instance.</returns>
        public static GitHubClient WithCredentials(this GitHubClient value, string username, string password)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            value.Credentials = new Credentials(username, password);

            return value;
        }
    }
}
