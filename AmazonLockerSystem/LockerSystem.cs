using System.Collections.Generic;
using System.Linq;

namespace AmazonLockerSystem

{
    public class LockerSystem : ILocker
    {
        private Dictionary<Size, Locker> lockers = new Dictionary<Size, Locker>();
        private Dictionary<int, Size> packageMap = new Dictionary<int, Size>();
        public void Init()
        {
            AddLocker(Size.Large, 3);
            AddLocker(Size.Small, 3);
            AddLocker(Size.Medium, 3);
        }

        private bool AddLocker(Size s, int capacity)
        {
            if(lockers.ContainsKey(s))
            {
                Logger.Error($"Locker of size '{s}' already exists.");
                return false;
            }
            lockers.Add(s, new Locker(s, capacity));
            Logger.Trace($"Locker of size '{s}' initilized with capacity {capacity}.");

            return true;
        }

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
                var parcel = lockers[locker].Remove(packageId);
                packageMap.Remove(packageId);
                return parcel;
            }
        }

        public bool Store(Package package)
        {
            lock (this)
            {
                if (packageMap.ContainsKey(package.Id))
                {
                   Logger.Error($"Package {package} already exists in '{packageMap[package.Id]}' locker.");
                    return false;
                }
                var availableLockerSizes = lockers.Keys.ToArray().Where(x => (int)x >= (int)package.Size).ToList();
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
    }
}
