using System;

using FluentAssertions;

using GitHubActions.LabelIssue.ConsoleApp.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Octokit;

namespace GitHubActionsLabelIssue.ConsoleApp.Tests.Extensions
{
    [TestClass]
    public class OptionsExtensionsTests
    {
        [TestMethod]
        public void Given_Type_Then_It_Should_Have_Methods()
        {
            typeof(OptionsExtensions)
                .Should().HaveMethod("ToArray", new[] { typeof(string), typeof(string) })
                ;
        }

        [TestMethod]
        public void Given_Null_Parameter_When_ToArray_Invoked_Then_It_Should_Return_EmptyArray()
        {
            var result = OptionsExtensions.ToArray(null);

            result.Should().HaveCount(0);
        }

        // [DataTestMethod]
        // [DataRow(null, null)]
        // [DataRow("hello world", "hello world")]
        // public void Given_Null_Parameters_When_WithCommitTitle_Invoked_Then_It_Return_Value(string value, string expected)
        // {
        //     var mpr = new MergePullRequest();

        //     var result = MergePullRequestExtensions.WithCommitTitle(mpr, value);

        //     result.CommitTitle.Should().BeEquivalentTo(expected);
        // }

        // [TestMethod]
        // public void Given_Null_Parameters_When_WithCommitMessage_Invoked_Then_It_Throws_Exception()
        // {
        //     Action action = () => MergePullRequestExtensions.WithCommitMessage(null, null);
        //     action.Should().Throw<ArgumentNullException>();
        // }

        // [DataTestMethod]
        // [DataRow(null, null)]
        // [DataRow("hello world", "hello world")]
        // public void Given_Null_Parameters_When_WithCommitMessage_Invoked_Then_It_Return_Value(string value, string expected)
        // {
        //     var mpr = new MergePullRequest();

        //     var result = MergePullRequestExtensions.WithCommitMessage(mpr, value);

        //     result.CommitMessage.Should().BeEquivalentTo(expected);
        // }

        // [TestMethod]
        // public void Given_Null_Parameters_When_WithSha_Invoked_Then_It_Throws_Exception()
        // {
        //     var mpr = new MergePullRequest();

        //     Action action = () => MergePullRequestExtensions.WithSha(null, null);
        //     action.Should().Throw<ArgumentNullException>();

        //     action = () => MergePullRequestExtensions.WithSha(mpr, null);
        //     action.Should().Throw<ArgumentNullException>();
        // }

        // [DataTestMethod]
        // [DataRow("hello world", "hello world")]
        // public void Given_Null_Parameters_When_WithSha_Invoked_Then_It_Return_Value(string value, string expected)
        // {
        //     var mpr = new MergePullRequest();

        //     var result = MergePullRequestExtensions.WithSha(mpr, value);

        //     result.Sha.Should().BeEquivalentTo(expected);
        // }

        // [TestMethod]
        // public void Given_Null_Parameters_When_WithMergeMethod_Invoked_Then_It_Throws_Exception()
        // {
        //     var mpr = new MergePullRequest();

        //     Action action = () => MergePullRequestExtensions.WithMergeMethod(null, PullRequestMergeMethod.Merge);
        //     action.Should().Throw<ArgumentNullException>();
        // }

        // [DataTestMethod]
        // [DataRow(PullRequestMergeMethod.Merge, PullRequestMergeMethod.Merge)]
        // [DataRow(PullRequestMergeMethod.Squash, PullRequestMergeMethod.Squash)]
        // [DataRow(PullRequestMergeMethod.Rebase, PullRequestMergeMethod.Rebase)]
        // public void Given_Null_Parameters_When_WithMergeMethod_Invoked_Then_It_Return_Value(PullRequestMergeMethod value, PullRequestMergeMethod expected)
        // {
        //     var mpr = new MergePullRequest();

        //     var result = MergePullRequestExtensions.WithMergeMethod(mpr, value);

        //     result.MergeMethod.Should().Be(expected);
        // }
    }
}
