using System;
using System.Collections.Generic;
using System.Text;

namespace Cwk.DataTypes.Vector.Abstractions
{
    public interface IVectorCalculator<T>
    {
        Vector<T> Sum(Vector<T> v1, Vector<T> v2);
        Vector<T> ScalarMultiplication(Vector<T> v1, int scalar);
        Vector<T> ScalarMultiplication(Vector<T> v1, double scalar);
        Vector<T> DotProduct(Vector<T> v1, Vector<T> v2);
    }
}
