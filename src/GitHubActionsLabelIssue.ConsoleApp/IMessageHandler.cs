using System.Collections.Generic;
using System.Threading.Tasks;

using Octokit;

namespace GitHubActions.LabelIssue.ConsoleApp
{
    /// <summary>
    /// This provides interfaces to the <see cref="MessageHandler" /> class.
    /// </summary>
    public interface IMessageHandler
    {
        /// <summary>
        /// Gets the <see cref="IGitHubClient"/> instance.
        /// </summary>
        IGitHubClient GitHubClient { get; }

        /// <summary>
        /// Gets the list of labels added to the issue.
        /// </summary>
        List<string> LabelsAdded { get; }

        /// <summary>
        /// Gets the list of labels remaining on the issue.
        /// </summary>
        List<string> LabelsRemaining { get; }

        /// <summary>
        /// Sets the <see cref="IGitHubClient"/> instance.
        /// </summary>
        /// <param name="client"><see cref="IGitHubClient"/> instance.</param>
        /// <returns>Returns <see cref="IMessageHandler"/> instance.</returns>
        IMessageHandler WithGitHubClient(IGitHubClient client);

        /// <summary>
        /// Adds Labels on the issue.
        /// </summary>
        /// <param name="options"><see cref="Options"/> instance.</param>
        /// <returns>Returns <see cref="IMessageHandler"/> instance.</returns>
        Task<IMessageHandler> AddLabelsOnIssueAsync(Options options);

        /// <summary>
        /// Removes Labels from the issue.
        /// </summary>
        /// <param name="options"><see cref="Options"/> instance.</param>
        /// <returns>Returns the exit code. 0 means success.</returns>
        Task<int> RemoveLabelsFromIssueAsync(Options options);
    }
}
