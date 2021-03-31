using System;
using System.Collections.Generic;
using Cwk.DataTypes.Vector;

namespace Cwk.DataTypes.Vector.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var v1 = new Vector(new List<int> { 1, 2, 3, 4});
            var v2 = new Vector(new int[] { 1, 2, 3, 4});

            Console.WriteLine(v1);
            Console.WriteLine($"Vector dimension: {v1.Dimension}");

            foreach (var element in v1)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine(v1 == v2);
            Console.WriteLine(v1.GetHashCode());

        }
    }
}
