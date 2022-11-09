using System;

namespace AmazonLockerSystem
{
    public class Package
    {
        public int Id { get; set; }
        public Size Size { get; set; }

        public override string ToString()
        {
            return $"{{Id: {Id}, Size: {Enum.GetName(Size.GetType(), Size)}}}";
        }
    }
}
