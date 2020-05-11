namespace Common.BookTransaction
{
    public enum TransactionStatus
    {
        Pending,
        InProcess,
        Closed,
        Delayed,
        Unknown,
        Stolen
    }
}