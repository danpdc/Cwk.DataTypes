using Cwk.DataTypes.Vector;
using Cwk.DataTypes.Vector.Exceptions;
using System;
using System.Collections.Generic;

namespace VectorPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            var v1 = new Vector(new List<int> { 1, 2 });
            var v2 = new Vector(new int[] { 4, 5, 8 });

            var v3 = v1.DotProduct(v2);
            Console.WriteLine(v3);

            var v4 = Vector.DotProduct(v1, v2);
            Console.WriteLine(v4);

            var v5 = v1 * v2;
            Console.WriteLine(v5);
        }
    }
}
