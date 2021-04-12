using Cwk.DataTypes.Vector.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cwk.DataTypes.Vector
{
    public class VectorCalculator<T> : IVectorCalculator<T>
    {
        public Vector<T> DotProduct(Vector<T> v1, Vector<T> v2)
        {
            throw new NotImplementedException();
        }

        public Vector<T> ScalarMultiplication(Vector<T> v1, int scalar)
        {
            throw new NotImplementedException();
        }

        public Vector<T> ScalarMultiplication(Vector<T> v1, double scalar)
        {
            throw new NotImplementedException();
        }

        public Vector<T> Sum(Vector<T> v1, Vector<T> v2)
        {
            var v1TType = v1[0].GetType().Name;
            var v2TType = v2[0].GetType().Name;

            if (v1TType == nameof(Int32))
            {
                //1. Convert v1 and v2 to Vector<int>
                var intV1 = VectorTypeConverter<int>.
                //2. Int calculator
                //3. Convert the sum vector to Vector<T>

            }
        }
    }
}
