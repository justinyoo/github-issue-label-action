using System;
using System.Linq;

using FluentAssertions;

using GitHubActions.LabelIssue.ConsoleApp;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Octokit;

using Program = GitHubActions.LabelIssue.ConsoleApp.Program;

namespace GitHubActionsLabelIssue.ConsoleApp.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Given_Type_Then_It_Should_Have_Properties()
        {
            typeof(Program)
                .Should().HaveProperty<IGitHubClient>("GitHubClient")
                    .Which.Should().BeReadable()
                          .And.BeWritable()
                          ;

            typeof(Program)
                .Should().HaveProperty<IMessageHandler>("MessageHandler")
                    .Which.Should().BeReadable()
                          .And.BeWritable()
                          ;
        }

        [TestMethod]
        public void Given_Type_Then_It_Should_Have_Methods()
        {
            typeof(Program)
                .Should().HaveMethod("Main", new[] { typeof(string[]) })
                ;
        }

        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 1)]
        public void Given_Valid_Args_When_Main_Invoked_Then_It_Should_Return_Result(int exitCode, int expected)
        {
            Environment.SetEnvironmentVariable("USER_AGENT", "hello");
            Environment.SetEnvironmentVariable("GITHUB_TOKEN", "world");

            var handler = new Mock<IMessageHandler>();
            handler.Setup(p => p.WithGitHubClient(It.IsAny<IGitHubClient>())).Returns(handler.Object);
            handler.Setup(p => p.AddLabelsOnIssueAsync(It.IsAny<Options>())).ReturnsAsync(handler.Object);
            handler.Setup(p => p.RemoveLabelsFromIssueAsync(It.IsAny<Options>())).ReturnsAsync(exitCode);

            Program.MessageHandler = handler.Object;

            var args = new[] {
                "-o",
                "aliencube",
                "-r",
                "github-pr-merge-action",
                "-i",
                "1",
                "--labels-add",
                "hello,world",
                "--labels-remove",
                "lorem,ipsum"
            }.ToArray();

            var result = Program.Main(args);

            result.Should().Be(expected);
        }

        [TestMethod]
        public void Given_Invalid_Args_When_Main_Invoked_Then_It_Should_Return_Result()
        {
            Environment.SetEnvironmentVariable("USER_AGENT", "hello");
            Environment.SetEnvironmentVariable("GITHUB_TOKEN", "world");

            var handler = new Mock<IMessageHandler>();
            handler.Setup(p => p.WithGitHubClient(It.IsAny<IGitHubClient>())).Returns(handler.Object);
            handler.Setup(p => p.AddLabelsOnIssueAsync(It.IsAny<Options>())).ReturnsAsync(handler.Object);
            handler.Setup(p => p.RemoveLabelsFromIssueAsync(It.IsAny<Options>())).ReturnsAsync(0);

            Program.MessageHandler = handler.Object;

            var args = new[] {
                "-o",
                "aliencube",
                "-r",
                "github-pr-merge-action",
                "-i",
                "<issue_number>",
                "--labels-add",
                "hello,world",
                "--labels-remove",
                "lorem,ipsum"
            }.ToArray();

            var result = Program.Main(args);

            result.Should().BeGreaterThan(0);
        }
    }
}
