using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoFixture;
using AutoFixture.AutoMoq;

using FluentAssertions;

using GitHubActions.LabelIssue.ConsoleApp;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Octokit;

namespace GitHubActionsLabelIssue.ConsoleApp.Tests
{
    [TestClass]
    public class MessageHandlerTests
    {
        private IFixture _fixture;

        [TestInitialize]
        public void Init()
        {
            this._fixture = new Fixture().Customize(new AutoMoqCustomization() { ConfigureMembers = true });
        }

        [TestMethod]
        public void Given_Type_Then_It_Should_Have_Constructors()
        {
            typeof(MessageHandler)
                .Should().HaveDefaultConstructor()
                ;
        }

        [TestMethod]
        public void Given_Type_Then_It_Should_Implement_Interfaces()
        {
            typeof(MessageHandler)
                .Should().Implement<IMessageHandler>()
                ;
        }

        [TestMethod]
        public void Given_Type_Then_It_Should_Have_Properties()
        {
            typeof(MessageHandler)
                .Should().HaveProperty<IGitHubClient>("GitHubClient")
                    .Which.Should().BeVirtual()
                    .And.BeReadable()
                    .And.BeWritable()
                    .And.BeVirtual()
                    ;
        }

        [TestMethod]
        public void Given_Type_Then_It_Should_Have_Methods()
        {
            typeof(MessageHandler)
                .Should().HaveMethod("WithGitHubClient", new[] { typeof(IGitHubClient) })
                ;

            typeof(MessageHandler)
                .Should().HaveMethod("AddLabelsOnIssueAsync", new[] { typeof(Options) } )
                ;

            typeof(MessageHandler)
                .Should().HaveMethod("RemoveLabelsFromIssueAsync", new[] { typeof(Options) } )
                ;
        }

        [TestMethod]
        public void Given_Null_Parameters_When_WithGitHubClient_Invoked_Then_It_Should_Throw_Exception()
        {
            var handler = new MessageHandler();

            Action action = () => handler.WithGitHubClient(null);
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void Given_Parameters_When_WithGitHubClient_Invoked_Then_It_Should_Return_Property()
        {
            var handler = new MessageHandler();

            handler.GitHubClient.Should().BeNull();

            var client = new Mock<IGitHubClient>();
            handler.WithGitHubClient(client.Object);

            handler.GitHubClient.Should().NotBeNull();
        }

        [TestMethod]
        public void Given_Null_Parameters_When_AddLabelsOnIssueAsync_Invoked_Then_It_Should_Throw_Exception()
        {
            var handler = new MessageHandler();

            Func<Task> func = async () => await handler.AddLabelsOnIssueAsync(null).ConfigureAwait(false);
            func.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void Given_No_GitHubClient_When_AddLabelsOnIssueAsync_Invoked_Then_It_Should_Throw_Exception()
        {
            var handler = new MessageHandler();
            var options = new Mock<Options>();

            Func<Task> func = async () => await handler.AddLabelsOnIssueAsync(options.Object).ConfigureAwait(false);
            func.Should().Throw<InvalidOperationException>();
        }

        [TestMethod]
        public void Given_Null_Parameters_When_RemoveLabelsFromIssueAsync_Invoked_Then_It_Should_Throw_Exception()
        {
            var handler = new MessageHandler();

            Func<Task> func = async () => await handler.RemoveLabelsFromIssueAsync(null).ConfigureAwait(false);
            func.Should().Throw<ArgumentNullException>();
        }

        [DataTestMethod]
        [DataRow("hello")]
        [DataRow("hello", "world")]
        public async Task Given_Parameters_When_AddLabelsOnIssueAsync_Invoked_Then_It_Should_Return_Result(params string[] labels)
        {
            var labelsAdded = Enumerable.Range(0, labels.Length).Select(i => new Label(i + 1, $"lorem-{i}", labels[i], $"ipsum-{i}", $"hello-{i}", $"world-{i}", false)).ToList();

            var ilc = new Mock<IIssuesLabelsClient>();
            ilc.Setup(p => p.AddToIssue(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string[]>())).ReturnsAsync(labelsAdded);

            var ic = new Mock<IIssuesClient>();
            ic.SetupGet(p => p.Labels).Returns(ilc.Object);

            var client = new Mock<IGitHubClient>();
            client.SetupGet(p => p.Issue).Returns(ic.Object);

            var options = new Options() { LabelsToAdd = string.Join(",", labels) };

            var handler = new MessageHandler()
                              .WithGitHubClient(client.Object);

            var result = await handler.AddLabelsOnIssueAsync(options).ConfigureAwait(false);

            result.LabelsAdded.Should().HaveCount(labels.Length);
            result.LabelsAdded.Should().BeEquivalentTo(labels);
        }

        [TestMethod]
        public void Given_No_GitHubClient_When_RemoveLabelsFromIssueAsync_Invoked_Then_It_Should_Throw_Exception()
        {
            var handler = new MessageHandler();
            var options = new Mock<Options>();

            Func<Task> func = async () => await handler.RemoveLabelsFromIssueAsync(options.Object).ConfigureAwait(false);
            func.Should().Throw<InvalidOperationException>();
        }

        [DataTestMethod]
        [DataRow("hello")]
        [DataRow("hello", "world")]
        public async Task Given_Parameters_When_RemoveLabelsFromIssueAsync_Invoked_Then_It_Should_Return_Result(params string[] labels)
        {
            var remainders = new List<string>() { "lorem", "ipsum" };
            var labelsRemaining = Enumerable.Range(0, remainders.Count).Select(i => new Label(i + 1, $"lorem-{i}", remainders[i], $"ipsum-{i}", $"hello-{i}", $"world-{i}", false)).ToList();

            var ilc = new Mock<IIssuesLabelsClient>();
            ilc.Setup(p => p.RemoveFromIssue(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(labelsRemaining);

            var ic = new Mock<IIssuesClient>();
            ic.SetupGet(p => p.Labels).Returns(ilc.Object);

            var client = new Mock<IGitHubClient>();
            client.SetupGet(p => p.Issue).Returns(ic.Object);

            var options = new Options() { LabelsToRemove = string.Join(",", labels) };

            var handler = new MessageHandler()
                              .WithGitHubClient(client.Object);

            var result = await handler.RemoveLabelsFromIssueAsync(options).ConfigureAwait(false);

            result.Should().Be(0);
            handler.LabelsRemaining.Should().HaveCount(labelsRemaining.Count);
            handler.LabelsRemaining.Should().BeEquivalentTo(labelsRemaining.Select(p => p.Name));
        }
    }
}
