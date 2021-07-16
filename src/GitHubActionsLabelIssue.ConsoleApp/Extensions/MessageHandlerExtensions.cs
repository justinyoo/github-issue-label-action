using System;
using System.Threading.Tasks;

namespace GitHubActions.LabelIssue.ConsoleApp.Extensions
{
    /// <summary>
    /// This represents the extension entity for the <see cref="MessageHandler"/> class.
    /// </summary>
    public static class MessageHandlerExtensions
    {
        /// <summary>
        /// Adds Labels on the issue.
        /// </summary>
        /// <param name="value"><see cref="Task{IMessageHandler}"/> instance.</param>
        /// <param name="options"><see cref="Options"/> instance.</param>
        /// <returns>Returns the <see cref="IMessageHandler"/> instance.</returns>
        public static async Task<IMessageHandler> AddLabelsOnIssueAsync(this Task<IMessageHandler> value, Options options)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var instance = await value.ConfigureAwait(false);

            return await instance.AddLabelsOnIssueAsync(options).ConfigureAwait(false);
        }

        /// <summary>
        /// Removes Labels from the issue.
        /// </summary>
        /// <param name="value"><see cref="Task{IMessageHandler}"/> instance.</param>
        /// <param name="options"><see cref="Options"/> instance.</param>
        /// <returns>Returns the exit code. 0 means success.</returns>
        public static async Task<int> RemoveLabelsFromIssueAsync(this Task<IMessageHandler> value, Options options)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var instance = await value.ConfigureAwait(false);

            return await instance.RemoveLabelsFromIssueAsync(options).ConfigureAwait(false);
        }
    }
}
