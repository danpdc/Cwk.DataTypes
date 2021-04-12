using System;
using System.Collections.Generic;
using System.Text;

namespace Cwk.DataTypes.Vector.Converters
{
    internal static class VectorTypeConverter<T>
    {
        internal static Vector<int> ConvertFromTToInt(Vector<T> v1)
        {
            int[] intV1 = new int[v1.Dimension];

            for (int i = 0; i < intV1.Length; i++)
            {
                intV1[i] = Convert.ToInt32(v1[i]);
            }

            return new Vector<int>(intV1);
        }

        internal static Vector<T> ConvertFromIntToT(Vector<int> v1)
        {
            T[] TV1 = new T[v1.Dimension];

            for (int i = 0; i < TV1.Length; i++)
            {
                TV1[i] = (T)(object)v1[i];
            }

            return new Vector<T>(TV1);
        }

        internal static Vector<double> ConvertFromTToDouble(Vector<T> v1)
        {
            double[] doubleV1 = new double[v1.Dimension];

            for (int i = 0; i < doubleV1.Length; i++)
            {
                doubleV1[i] = Convert.ToDouble(v1[i]);
            }

            return new Vector<double>(doubleV1);
        }

        internal static Vector<T> ConvertFromDoubleToT(Vector<double> v1)
        {
            T[] TV1 = new T[v1.Dimension];

            for (int i = 0; i < TV1.Length; i++)
            {
                TV1[i] = (T)(object)v1[i];
            }

            return new Vector<T>(TV1);
        }
    }
}
