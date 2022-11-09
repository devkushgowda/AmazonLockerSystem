using System;
using System.Collections.Generic;

namespace AmazonLockerSystem

{
    public class Locker
    {
        private readonly Size _size;

        private readonly int _capacity;

        public int Capacity => _capacity;
        public Size Size => _size;

        public Locker(Size size, int capacity)
        {
            _size = size;
            _capacity = capacity;
        }
        public Dictionary<int, Package> Storage { get; set; } = new Dictionary<int, Package>();

        public bool HasCapacity() => Storage.Count < _capacity;

        public bool Add(Package package)
        {
            if (!HasCapacity() || Storage.ContainsKey(package.Id))
            {
               Logger.Error($"Capacity full to insert package {package} to '{_size}' locker.");
                return false;
            }
            Storage.Add(package.Id, package);
           Logger.Info($"Added {package} to '{_size}' locker.");
            return true;
        }

        public Package Remove(int id)
        {
            if (!Storage.ContainsKey(id))
            {
               Logger.Error($"Package packageId: {id} does not exists in '{_size}' locker.");
                return null;
            }
            var res = Storage[id];
            Storage.Remove(id);
           Logger.Warn($"Removed packageId: {id}, {res} from '{_size}' locker.");
            return res;
        }
    }
}
