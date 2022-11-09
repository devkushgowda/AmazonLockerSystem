using System;

namespace AmazonLockerSystem
{
    class Program
    {
        /// <summary>
        /// Author:     Kushan devarajegowda
        /// Github:     devkushgowda
        /// LinkedIn:   kushan-devarajegowda
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var ls = new LockerSystem();
            ls.AddLocker(Size.Large, 3);
            ls.AddLocker(Size.Small, 3);
            ls.AddLocker(Size.Medium, 3);

            // Duplicate locker size.
            ls.AddLocker(Size.Small, 3);
            
            //Add three packages
            ls.Store(new Package { Size = Size.Medium, Id = 1 });
            ls.Store(new Package { Size = Size.Medium, Id = 2 });
            ls.Store(new Package { Size = Size.Medium, Id = 3 });

            // Now medium locker is full and the following package should be stored in next avilable locker space.
            ls.Store(new Package { Size = Size.Medium, Id = 4 });

            //Remove package
            ls.Retrive(3);

            //Already removed and does not exists.
            ls.Retrive(3);

            //Now another package can be stored in the released space.
            ls.Store(new Package { Size = Size.Medium, Id = 3 });

            Console.ReadKey();
        }
    }
}
