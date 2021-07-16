using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GitHubActions.LabelIssue.ConsoleApp.Extensions;

using Octokit;

namespace GitHubActions.LabelIssue.ConsoleApp
{
    /// <summary>
    /// This represents the console app entity.
    /// </summary>
    public class MessageHandler : IMessageHandler
    {
        /// <inheritdoc />
        public virtual IGitHubClient GitHubClient { get; private set; }

        /// <inheritdoc />
        public List<string> LabelsAdded { get; private set; } = new List<string>();

        /// <inheritdoc />
        public List<string> LabelsRemaining { get; private set; } = new List<string>();

        /// <inheritdoc />
        public IMessageHandler WithGitHubClient(IGitHubClient client)
        {
            this.GitHubClient = client ?? throw new ArgumentNullException(nameof(client));

            return this;
        }

        /// <inheritdoc />
        public async Task<IMessageHandler> AddLabelsOnIssueAsync(Options options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (this.GitHubClient == null)
            {
                throw new InvalidOperationException("GitHubClient Not Found");
            }

            var labels = await this.GitHubClient
                                   .Issue
                                   .Labels
                                   .AddToIssue(options.Owner, options.Repository, options.IssueId, options.LabelsToAdd.ToArray())
                                   .ConfigureAwait(false);

            this.LabelsAdded = labels.Select(p => p.Name).ToList();

            return this;
        }

        /// <inheritdoc />
        public async Task<int> RemoveLabelsFromIssueAsync(Options options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (this.GitHubClient == null)
            {
                throw new InvalidOperationException("GitHubClient Not Found");
            }

            var labels = default(IReadOnlyList<Label>);
            try
            {
                foreach(var label in options.LabelsToRemove.ToArray())
                {
                    labels = await this.GitHubClient
                                       .Issue
                                       .Labels
                                       .RemoveFromIssue(options.Owner, options.Repository, options.IssueId, label)
                                       .ConfigureAwait(false);
                }


                this.LabelsRemaining = labels.Select(p => p.Name).ToList();

                return 0;
            }
            catch
            {
                return 1;
            }
        }
    }
}
