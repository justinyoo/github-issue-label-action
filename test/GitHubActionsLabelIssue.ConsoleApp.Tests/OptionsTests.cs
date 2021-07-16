using CommandLine;

using FluentAssertions;

using GitHubActions.LabelIssue.ConsoleApp;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GitHubActionsLabelIssue.ConsoleApp.Tests
{
    [TestClass]
    public class OptionsTests
    {
        [TestMethod]
        public void Given_Type_Then_It_Should_Have_Properties()
        {
            typeof(Options)
                .Should().HaveProperty<string>("Owner")
                    .Which.Should().BeReadable()
                          .And.BeWritable()
                          .And.BeVirtual()
                          ;

            typeof(Options)
                .Should().HaveProperty<string>("Repository")
                    .Which.Should().BeReadable()
                          .And.BeWritable()
                          .And.BeVirtual()
                          ;

            typeof(Options)
                .Should().HaveProperty<int>("IssueId")
                    .Which.Should().BeReadable()
                          .And.BeWritable()
                          .And.BeVirtual()
                          ;

            typeof(Options)
                .Should().HaveProperty<string>("LabelsToAdd")
                    .Which.Should().BeReadable()
                          .And.BeWritable()
                          .And.BeVirtual()
                          ;

            typeof(Options)
                .Should().HaveProperty<string>("LabelsToRemove")
                    .Which.Should().BeReadable()
                          .And.BeWritable()
                          .And.BeVirtual()
                          ;
        }

        [TestMethod]
        public void Given_Type_Then_It_Should_Have_Decorators()
        {
            typeof(Options)
                .Should().HaveProperty<string>("Owner")
                    .Which.Should().BeDecoratedWith<OptionAttribute>(
                        p => p.ShortName.Equals("o") &&
                             p.LongName.Equals("owner") &&
                             p.Required == true)
                    ;

            typeof(Options)
                .Should().HaveProperty<string>("Repository")
                    .Which.Should().BeDecoratedWith<OptionAttribute>(
                        p => p.ShortName.Equals("r") &&
                             p.LongName.Equals("repository") &&
                             p.Required == true)
                    ;

            typeof(Options)
                .Should().HaveProperty<int>("IssueId")
                    .Which.Should().BeDecoratedWith<OptionAttribute>(
                        p => p.ShortName.Equals("i") &&
                             p.LongName.Equals("issue-id") &&
                             p.Required == true)
                    ;

            typeof(Options)
                .Should().HaveProperty<string>("LabelsToAdd")
                    .Which.Should().BeDecoratedWith<OptionAttribute>(
                        p => p.LongName.Equals("labels-add") &&
                             p.Required == false)
                    ;

            typeof(Options)
                .Should().HaveProperty<string>("LabelsToRemove")
                    .Which.Should().BeDecoratedWith<OptionAttribute>(
                        p => p.LongName.Equals("labels-remove") &&
                             p.Required == false)
                    ;
        }
    }
}
