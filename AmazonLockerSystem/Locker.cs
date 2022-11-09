using System;
using System.Collections.Generic;

namespace AmazonLockerSystem

{
    public class Locker
    {
        public int Capacity { private set; get; }
        public Size Size { private set; get; }

        public Locker(Size size, int capacity)
        {
            Size = size;
            Capacity = capacity;
        }
        public Dictionary<int, Package> Storage { get; set; } = new Dictionary<int, Package>();

        public bool HasCapacity() => Storage.Count < Capacity;

        public bool Add(Package package)
        {
            if (!HasCapacity() || Storage.ContainsKey(package.Id))
            {
                Logger.Error($"Capacity full to insert package {package} to '{Size}' locker.");
                return false;
            }
            Storage.Add(package.Id, package);
            Logger.Info($"Added {package} to '{Size}' locker.");
            return true;
        }

        public Package Remove(int id)
        {
            if (!Storage.ContainsKey(id))
            {
                Logger.Error($"Package packageId: {id} does not exists in '{Size}' locker.");
                return null;
            }
            var res = Storage[id];
            Storage.Remove(id);
            Logger.Warn($"Removed packageId: {id}, {res} from '{Size}' locker.");
            return res;
        }
    }
}
