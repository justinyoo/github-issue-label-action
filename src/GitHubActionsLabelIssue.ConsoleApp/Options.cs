using CommandLine;

using Octokit;

namespace GitHubActions.LabelIssue.ConsoleApp
{
    /// <summary>
    /// This represents the parameters entity for the console app.
    /// </summary>
    public class Options
    {
        /// <summary>
        /// Gets or sets the repository owner.
        /// </summary>
        [Option('o', "owner", Required = true, HelpText = "GitHub repository owner.")]
        public virtual string Owner { get; set; }

        /// <summary>
        /// Gets or sets the repository name.
        /// </summary>
        [Option('r', "repository", Required = true, HelpText = "GitHub repository")]
        public virtual string Repository { get; set; }

        /// <summary>
        /// Gets or sets the issue ID.
        /// </summary>
        [Option('i', "issue-id", Required = true, HelpText = "GitHub issue ID for the PR.")]
        public virtual int IssueId { get; set; }

        /// <summary>
        /// Gets or sets the comma delimited list of lables to add.
        /// </summary>
        [Option("labels-add", Required = false, HelpText = "Labels to add to the given GitHub issue.")]
        public virtual string LabelsToAdd { get; set; }

        /// <summary>
        /// Gets or sets the comma delimited list of lables to remove.
        /// </summary>
        [Option("labels-remove", Required = false, HelpText = "Labels to remove from the given GitHub issue.")]
        public virtual string LabelsToRemove { get; set; }
    }
}
