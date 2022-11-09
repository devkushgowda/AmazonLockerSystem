namespace AmazonLockerSystem
{
    /// <summary>
    /// Interface for the locker system.
    /// </summary>
    public interface ILocker
    {
        /// <summary>
        /// Store the package in best available locker size and return the status.
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        bool Store(Package package);

        /// <summary>
        /// Retrive the package from the locker and free up the resources.
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        Package Retrive(int packageId);
    }
}
