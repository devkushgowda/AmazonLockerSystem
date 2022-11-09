namespace AmazonLockerSystem
{
    public interface ILocker
    {
        bool Store(Package package);
        Package Retrive(int packageId);
    }
}
