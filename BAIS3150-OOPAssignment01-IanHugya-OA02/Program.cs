using BAIS3150_OOPAssignment01_IanHugya_OA02.BLL;
using BAIS3150_OOPAssignment01_IanHugya_OA02.Domain;

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BAIS3150_OOPAssignment01_IanHugya_OA02
{
    class Program
    {
        static void Main(string[] args)
        {
            string confirm="yes";
            Random rnd = new Random();
            do
            {

        

            string[] fight1= { "Kevin Natividad", "Miles Johns", "Kevin Natividad", "Miles Johns", "Kevin Natividad", "Miles Johns", "Kevin Natividad", "Miles Johns", "Kevin Natividad", "Miles Johns", "Kevin Natividad", "Miles Johns", "Kevin Natividad", "Miles Johns", };
            string[] fight2 = {"Justin Ledet","Dustin Jacoby", "Justin Ledet", "Dustin Jacoby", "Justin Ledet", "Dustin Jacoby", "Justin Ledet", "Dustin Jacoby", "Justin Ledet", "Dustin Jacoby", "Justin Ledet", "Dustin Jacoby", "Justin Ledet", "Dustin Jacoby", "Justin Ledet", "Dustin Jacoby", };
            string[] fight3 = { "Cole Williams", "Jason Witt", "Cole Williams", "Jason Witt", "Cole Williams", "Jason Witt", "Cole Williams", "Jason Witt", "Cole Williams", "Jason Witt", "Cole Williams", "Jason Witt", "Cole Williams", "Jason Witt", "Cole Williams", "Jason Witt", };
            string[] fight4 = { "Jack Marshman", "Sean Strickland", "Jack Marshman", "Sean Strickland", "Jack Marshman", "Sean Strickland", "Jack Marshman", "Sean Strickland", "Jack Marshman", "Sean Strickland", "Jack Marshman", "Sean Strickland", "Jack Marshman", "Sean Strickland", "Jack Marshman", "Sean Strickland", };
            string[] fight5 = { "Charlie Ontiveros", "Kevin Holland", "Charlie Ontiveros", "Kevin Holland", "Charlie Ontiveros", "Kevin Holland", "Charlie Ontiveros", "Kevin Holland", "Charlie Ontiveros", "Kevin Holland", "Charlie Ontiveros", "Kevin Holland", "Charlie Ontiveros", "Kevin Holland", "Charlie Ontiveros", "Kevin Holland", };
            string[] fight6 = { "Andre Fili", "Bryce Mitchell", "Andre Fili", "Bryce Mitchell", "Andre Fili", "Bryce Mitchell", "Andre Fili", "Bryce Mitchell", "Andre Fili", "Bryce Mitchell", "Andre Fili", "Bryce Mitchell", "Andre Fili", "Bryce Mitchell", };
            string[] fight7 = { "Anderson Silva", "Uriah Hall", "Anderson Silva", "Uriah Hall", "Anderson Silva", "Uriah Hall", "Anderson Silva", "Uriah Hall", "Anderson Silva", "Uriah Hall", "Anderson Silva", "Uriah Hall", "Anderson Silva", "Uriah Hall", "Anderson Silva", "Uriah Hall", "Anderson Silva", "Uriah Hall", };
            string[] fight8 = { "Maurice Greene", "Greg Hardy", "Maurice Greene", "Greg Hardy", "Maurice Greene", "Greg Hardy", "Maurice Greene", "Greg Hardy", "Maurice Greene", "Greg Hardy", "Maurice Greene", "Greg Hardy", "Maurice Greene", "Greg Hardy", "Maurice Greene", "Greg Hardy", "Maurice Greene", "Greg Hardy", };
            string[] fight9 = { "Thiago Moises", "Bobby Green", "Thiago Moises", "Bobby Green", "Thiago Moises", "Bobby Green", "Thiago Moises", "Bobby Green", "Thiago Moises", "Bobby Green", "Thiago Moises", "Bobby Green", "Thiago Moises", "Bobby Green", "Thiago Moises", "Bobby Green", "Thiago Moises", "Bobby Green", "Thiago Moises", "Bobby Green", };
            string[] fight10 = { "Chris Gruetzemacher", "Alexander Hernandez", "Chris Gruetzemacher", "Alexander Hernandez", "Chris Gruetzemacher", "Alexander Hernandez", "Chris Gruetzemacher", "Alexander Hernandez", "Chris Gruetzemacher", "Alexander Hernandez", "Chris Gruetzemacher", "Alexander Hernandez", "Chris Gruetzemacher", "Alexander Hernandez", };
            string[] fight11 = { "Victor Rodriguez", "Adrian Yanez", "Victor Rodriguez", "Adrian Yanez", "Victor Rodriguez", "Adrian Yanez", "Victor Rodriguez", "Adrian Yanez", "Victor Rodriguez", "Adrian Yanez", "Victor Rodriguez", "Adrian Yanez", "Victor Rodriguez", "Adrian Yanez", "Victor Rodriguez", "Adrian Yanez", };
                if (rnd.Next(1,100) % 2 == 0 )
                {
                    Console.WriteLine(fight1[rnd.Next(0, 10)]);
                }
                if (rnd.Next(1, 100) % 2 != 0)
                {
                    Console.WriteLine(fight2[rnd.Next(0, 10)]);
                }
                if (rnd.Next(1, 100) % 2 != 0)
                {
                    Console.WriteLine(fight3[rnd.Next(0, 10)]);
                }
                if (rnd.Next(1, 100) % 2 == 0)
                {
                    Console.WriteLine(fight4[rnd.Next(0, 10)]);
                }
                if (rnd.Next(1, 100) % 2 != 0)
                {
                    Console.WriteLine(fight5[rnd.Next(0, 10)]);
                }
                if (rnd.Next(1, 100) % 2 == 3)
                {
                    Console.WriteLine(fight6[rnd.Next(0, 10)]);
                }
                if (rnd.Next(1, 100) < 50)
                {
                    Console.WriteLine(fight7[rnd.Next(0, 10)]);
                }
                if (rnd.Next(1, 100) > 50)
                {
                    Console.WriteLine(fight8[rnd.Next(0, 10)]);
                }
                if (rnd.Next(1, 100) < 25)
                {
                    Console.WriteLine(fight9[rnd.Next(0, 10)]);
                }
                if (rnd.Next(1, 100) > 33)
                {
                    Console.WriteLine(fight10[rnd.Next(0, 10)]);
                }

                Console.WriteLine("\n\n");
            confirm=Console.ReadLine();

            } while (confirm!="no");

        }
    }
}
