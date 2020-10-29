using BAIS3150_OOPAssignment01_IanHugya_OA02.BLL;
using BAIS3150_OOPAssignment01_IanHugya_OA02.Domain;

using System;
using System.Collections.Generic;

namespace BAIS3150_OOPAssignment01_IanHugya_OA02
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
           

            string[] fight1= { "Joel Alvarez", "Alexander Yakovlev", "Joel Alvarez", "Alexander Yakovlev", "Joel Alvarez", "Alexander Yakovlev", "Joel Alvarez", "Alexander Yakovlev", "Joel Alvarez", "Alexander Yakovlev", "Joel Alvarez", "Alexander Yakovlev" };
            string[] fight2 = { "Liana Jojua", "Miranda Maverick", "Liana Jojua", "Miranda Maverick", "Liana Jojua", "Miranda Maverick", "Liana Jojua", "Miranda Maverick", "Liana Jojua", "Miranda Maverick", "Liana Jojua", "Miranda Maverick" };
            string[] fight3 = { "Sam Alvey", "Da Un Jung", "Sam Alvey", "Da Un Jung", "Sam Alvey", "Da Un Jung", "Sam Alvey", "Da Un Jung", "Sam Alvey", "Da Un Jung", "Sam Alvey", "Da Un Jung", "Sam Alvey", "Da Un Jung" };
            string[] fight4 = { "Shavkat Rakhmonov", "Alex Oliveira", "Shavkat Rakhmonov", "Alex Oliveira", "Shavkat Rakhmonov", "Alex Oliveira", "Shavkat Rakhmonov", "Alex Oliveira", "Shavkat Rakhmonov", "Alex Oliveira", "Shavkat Rakhmonov", "Alex Oliveira", "Shavkat Rakhmonov", "Alex Oliveira" };
            string[] fight5 = { "Nathaniel Wood", "Casey Kenney", "Nathaniel Wood", "Casey Kenney", "Nathaniel Wood", "Casey Kenney", "Nathaniel Wood", "Casey Kenney", "Nathaniel Wood", "Casey Kenney", "Nathaniel Wood", "Casey Kenney", "Nathaniel Wood", "Casey Kenney" };
            string[] fight6 = { "Tai Tuivasa", "Stefan Struve", "Tai Tuivasa", "Stefan Struve", "Tai Tuivasa", "Stefan Struve", "Tai Tuivasa", "Stefan Struve", "Tai Tuivasa", "Stefan Struve", "Tai Tuivasa", "Stefan Struve", "Tai Tuivasa", "Stefan Struve" };
            string[] fight7 = { "Ion Cutelaba", "Magomed Ankalaev", "Ion Cutelaba", "Magomed Ankalaev", "Ion Cutelaba", "Magomed Ankalaev", "Ion Cutelaba", "Magomed Ankalaev", "Ion Cutelaba", "Magomed Ankalaev", "Ion Cutelaba", "Magomed Ankalaev", "Ion Cutelaba", "Magomed Ankalaev" };
            string[] fight8 = { "Liliya Shakirova", "Lauren Murphy", "Liliya Shakirova", "Lauren Murphy", "Liliya Shakirova", "Lauren Murphy", "Liliya Shakirova", "Lauren Murphy", "Liliya Shakirova", "Lauren Murphy", "Liliya Shakirova", "Lauren Murphy", "Liliya Shakirova", "Lauren Murphy" };
            string[] fight9 = { "Phil Hawes", "Jacob Malkoun", "Phil Hawes", "Jacob Malkoun", "Phil Hawes", "Jacob Malkoun", "Phil Hawes", "Jacob Malkoun", "Phil Hawes", "Jacob Malkoun", "Phil Hawes", "Jacob Malkoun", "Phil Hawes", "Jacob Malkoun" };
            string[] fight10 = { "Walt Harris", "Alexander Volkov", "Walt Harris", "Alexander Volkov", "Walt Harris", "Alexander Volkov", "Walt Harris", "Alexander Volkov", "Walt Harris", "Alexander Volkov", "Walt Harris", "Alexander Volkov", "Walt Harris", "Alexander Volkov" };
            string[] fight11 = { "Rob Whit", "Jared C", "Rob Whit", "Jared C", "Rob Whit", "Jared C", "Rob Whit", "Jared C", "Rob Whit", "Jared C", "Rob Whit", "Jared C", "Rob Whit", "Jared C", };
            Console.WriteLine(fight1[rnd.Next(0,10)]);
            Console.WriteLine(fight2[rnd.Next(0, 10)]);
            Console.WriteLine(fight3[rnd.Next(0, 10)]);
            Console.WriteLine(fight4[rnd.Next(0, 10)]);
            Console.WriteLine(fight5[rnd.Next(0, 10)]);
            Console.WriteLine(fight6[rnd.Next(0, 10)]);
            Console.WriteLine(fight7[rnd.Next(0, 10)]);
            Console.WriteLine(fight8[rnd.Next(0, 10)]);
            Console.WriteLine(fight9[rnd.Next(0, 10)]);
            Console.WriteLine(fight10[rnd.Next(0, 10)]);
            Console.WriteLine(fight11[rnd.Next(0, 10)]);




        }
    }
}
