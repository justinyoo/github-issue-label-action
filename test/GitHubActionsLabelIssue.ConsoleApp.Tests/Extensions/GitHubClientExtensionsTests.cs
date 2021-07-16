using System;

using FluentAssertions;

using GitHubActions.LabelIssue.ConsoleApp.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Octokit;

namespace GitHubActionsLabelIssue.ConsoleApp.Tests.Extensions
{
    [TestClass]
    public class GitHubClientExtensionsTests
    {
        [TestMethod]
        public void Given_Type_Then_It_Should_Have_Methods()
        {
            typeof(GitHubClientExtensions)
                .Should().HaveMethod("WithCredentials", new[] { typeof(GitHubClient), typeof(string) })
                ;

            typeof(GitHubClientExtensions)
                .Should().HaveMethod("WithCredentials", new[] { typeof(GitHubClient), typeof(string), typeof(string) })
                ;
        }

        [TestMethod]
        public void Given_Null_Parameters_When_WithCredentials_Invoked_Then_It_Throws_Exception()
        {
            var connection = new Mock<IConnection>();
            var client = new GitHubClient(connection.Object);

            Action action = () => GitHubClientExtensions.WithCredentials(null, null);
            action.Should().Throw<ArgumentNullException>();

            action = () => GitHubClientExtensions.WithCredentials(client, null);
            action.Should().Throw<ArgumentNullException>();

            action = () => GitHubClientExtensions.WithCredentials(null, null, null);
            action.Should().Throw<ArgumentNullException>();

            action = () => GitHubClientExtensions.WithCredentials(client, null, null);
            action.Should().Throw<ArgumentNullException>();

            action = () => GitHubClientExtensions.WithCredentials(client, "hello world", null);
            action.Should().Throw<ArgumentNullException>();
        }
    }
}
