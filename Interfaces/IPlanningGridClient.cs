namespace Interfaces
{
    public interface IPlanningGridClient
    {
        void AccountDataChanged(string accountId, decimal[] values);
    }
}
