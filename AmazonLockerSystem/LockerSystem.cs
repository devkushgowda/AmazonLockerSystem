using System.Collections.Generic;
using System.Linq;

namespace AmazonLockerSystem

{
    /// <summary>
    /// Configurable locker system, That allows to store package based on the available locker size that is >= package size.
    /// 
    /// :::::::::Store:::::::::
    /// 
    /// Time complexity:    O(1)
    /// Space complexity:   O(1)
    /// 
    /// ::::::::Retrive:::::::::
    /// 
    /// Time complexity:    O(1)
    /// Space complexity:   O(1)
    /// 
    /// </summary>
    public class LockerSystem : ILocker
    {
        /// <summary>
        /// Dictionary containing all the different size of available lockers.
        /// </summary>
        private Dictionary<Size, Locker> lockers = new Dictionary<Size, Locker>();

        /// <summary>
        /// Dictionary mapping which package is stored in which locker.
        /// </summary>
        private Dictionary<int, Size> packageMap = new Dictionary<int, Size>();

        public bool AddLocker(Size s, int capacity)
        {
            lock (this)
            {
                if (lockers.ContainsKey(s))
                {
                    Logger.Error($"Locker of size '{s}' already exists.");
                    return false;
                }
                lockers.Add(s, new Locker(s, capacity));
                Logger.Trace($"Locker of size '{s}' initilized with capacity {capacity}.");

                return true;
            }
        }

        /// <summary>
        /// Retrive the package from the locker and free up the resource.
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns>Package if found or null.</returns>
        public Package Retrive(int packageId)
        {
            lock (this)
            {
                if (!packageMap.ContainsKey(packageId))
                {
                    Logger.Error($"Package with ID: {packageId} does not exists.");
                    return null;
                }
                var locker = packageMap[packageId];
                var package = lockers[locker].Remove(packageId);
                packageMap.Remove(packageId);
                return package;
            }
        }

        /// <summary>
        /// Store the package into best fit locker size.
        /// </summary>
        /// <param name="package"></param>
        /// <returns>True if success or False.</returns>
        public bool Store(Package package)
        {
            lock (this)
            {
                if (packageMap.ContainsKey(package.Id))
                {
                    Logger.Error($"Package {package} already exists in '{packageMap[package.Id]}' locker.");
                    return false;
                }
                var availableLockerSizes = GetAvailableLockerSizes(package);

                if (availableLockerSizes.Count == 0)
                {
                    Logger.Error($"Currently no lockers available to store the package {package}.");
                    return false;
                }
                availableLockerSizes.Sort();
                foreach (var size in availableLockerSizes)
                {
                    if (lockers[size].Add(package))
                    {
                        packageMap[package.Id] = size;
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Get all the available lockers that the package can fit and not full.
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        private List<Size> GetAvailableLockerSizes(Package package)
        {
            return lockers.Keys.ToArray().Where(x => (int)x >= (int)package.Size && lockers[x].HasCapacity()).ToList();
        }
    }
}
