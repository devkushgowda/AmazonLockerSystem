using System;

namespace AmazonLockerSystem
{
    public class Package
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Minimum size of the locker required to store this package.
        /// </summary>
        public Size Size { get; set; }

        public override string ToString()
        {
            return $"{{Id: {Id}, Size: {Enum.GetName(Size.GetType(), Size)}}}";
        }
    }
}
