﻿using System;

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
            ls.Init();
            ls.Store(new Package { Size = Size.Medium, Id = 1 });
            ls.Store(new Package { Size = Size.Medium, Id = 2 });
            ls.Store(new Package { Size = Size.Medium, Id = 3 });
            ls.Store(new Package { Size = Size.Medium, Id = 4 });
            ls.Retrive(3);
            ls.Retrive(5);
            ls.Store(new Package { Size = Size.Medium, Id = 3 });
            Console.ReadKey();
        }
    }
}
