using System;
using System.Collections.Generic;
using System.Linq;

using CommandLine;

using GitHubActions.LabelIssue.ConsoleApp.Extensions;

using Octokit;

namespace GitHubActions.LabelIssue.ConsoleApp
{
    public static class Program
    {
        /// <summary>
        /// Gets or sets the <see cref="IGitHubClient"/> instance.
        /// </summary>
        public static IGitHubClient GitHubClient { get; set; } = new GitHubClient(new ProductHeaderValue(Environment.GetEnvironmentVariable("USER_AGENT")))
                                                                     .WithCredentials(Environment.GetEnvironmentVariable("GITHUB_TOKEN"));

        /// <summary>
        /// Gets or sets the <see cref="IMessageHandler"/> instance.
        /// </summary>
        public static IMessageHandler MessageHandler { get; set; } = new MessageHandler();

        /// <summary>
        /// Invokes the console app.
        /// </summary>
        /// <param name="args">List of arguments passed.</param>
        public static int Main(string[] args)
        {
            using (var parser = new Parser(with => { with.EnableDashDash = true; with.HelpWriter = Console.Out; }))
            {
                var result = parser.ParseArguments<Options>(args)
                                   .MapResult(options => OnParsed(options), errors => OnNotParsed(errors))
                                   ;

                return result;
            }
        }

        private static int OnParsed(Options options)
        {
            var result = MessageHandler.WithGitHubClient(GitHubClient)
                                       .AddLabelsOnIssueAsync(options)
                                       .RemoveLabelsFromIssueAsync(options)
                                       .Result;

            return result;
        }

        private static int OnNotParsed(IEnumerable<Error> errors)
        {
            return errors.Count();
        }
    }
}
