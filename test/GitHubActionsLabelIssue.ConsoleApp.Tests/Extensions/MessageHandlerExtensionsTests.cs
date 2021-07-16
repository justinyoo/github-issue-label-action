using System;
using System.Threading.Tasks;

using FluentAssertions;

using GitHubActions.LabelIssue.ConsoleApp;
using GitHubActions.LabelIssue.ConsoleApp.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace GitHubActionsLabelIssue.ConsoleApp.Tests.Extensions
{
    [TestClass]
    public class MessageHandlerExtensionsTests
    {
        [TestMethod]
        public void Given_Type_Then_It_Should_Have_Methods()
        {
            typeof(MessageHandlerExtensions)
                .Should().HaveMethod("AddLabelsOnIssueAsync", new[] { typeof(Task<IMessageHandler>), typeof(Options) })
                ;

            typeof(MessageHandlerExtensions)
                .Should().HaveMethod("RemoveLabelsFromIssueAsync", new[] { typeof(Task<IMessageHandler>), typeof(Options) })
                ;
        }

        [TestMethod]
        public void Given_Null_Parameters_When_AddLabelsOnIssueAsync_Invoked_Then_It_Should_Throw_Exception()
        {
            var handler = new Mock<IMessageHandler>();

            Func<Task> func = async () => await MessageHandlerExtensions.AddLabelsOnIssueAsync(null, null).ConfigureAwait(false);
            func.Should().Throw<ArgumentNullException>();

            func = async () => await MessageHandlerExtensions.AddLabelsOnIssueAsync(Task.FromResult(handler.Object), null).ConfigureAwait(false);
            func.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void Given_Null_Parameters_When_RemoveLabelsFromIssueAsync_Invoked_Then_It_Should_Throw_Exception()
        {
            var handler = new Mock<IMessageHandler>();

            Func<Task> func = async () => await MessageHandlerExtensions.RemoveLabelsFromIssueAsync(null, null).ConfigureAwait(false);
            func.Should().Throw<ArgumentNullException>();

            func = async () => await MessageHandlerExtensions.RemoveLabelsFromIssueAsync(Task.FromResult(handler.Object), null).ConfigureAwait(false);
            func.Should().Throw<ArgumentNullException>();
        }
    }
}
