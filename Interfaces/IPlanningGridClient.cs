namespace Interfaces
{
    /// <summary>
    /// Interface that defines the methods available at the client. Such an interface does not
    /// ensure that the methods exists on the client, but a hub can be typed with it in order
    /// to provide IntelliType and Code Completion in Visual Studio.
    /// </summary>
    public interface IPlanningGridClient
    {
        /// <summary>
        /// Signals the client, that account data has been changed.
        /// </summary>
        /// <param name="accountId">The id of the account.</param>
        /// <param name="values">The changed values.</param>
        void AccountDataChanged(string accountId, decimal[] values);
    }
}
