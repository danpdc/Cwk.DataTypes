using Cwk.DataTypes.Vector.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Cwk.DataTypes.Vector
{
    public struct Vector<T> : IEnumerable, IEqualityComparer, IEquatable<Vector<T>>
    {
        #region Fields and constructors
        private readonly T[] _elements;

        /// <summary>
        ///     Creates a new vector
        /// </summary>
        /// <param name="elements">A list of integers defining the vector elements</param>
        public Vector(List<T> elements)
        {
            _elements = elements.ToArray();
            Dimension = _elements.Length;
            Magnitude = GetMagnitude(_elements);
        }

        /// <summary>
        ///     Creates a new vector
        /// </summary>
        /// <param name="elements">An array of int defining the vector elements</param>
        public Vector(T[] elements)
        {
            _elements = elements;
            Dimension = _elements.Length;
            Magnitude = GetMagnitude(_elements);
        }
        #endregion

        #region Public properties
        public int Dimension { get; private set; }
        public double Magnitude { get; private set; }

        public T this[int i]
        {
            get
            {
                if (i < 0 || i >= Dimension)
                    throw new ArgumentOutOfRangeException("The provided indes is outside the vector dimension or is negative");

                return _elements[i];
            }

            private set
            {
                if (i < 0 || i >= Dimension)
                    throw new ArgumentOutOfRangeException("The provided indes is outside the vector dimension or is negative");

                _elements[i] = value;
            }
        }
        #endregion

        #region Public methods
        public static bool Equals(Vector<T> v1, Vector<T> v2)
        {
            return v1.Equals(v2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector<T>))
                return false;

            var v1 = (Vector<T>)obj;

            return Equals(v1);
        }

        public override int GetHashCode()
        {
            return GetHashCode(this);
        }
        #endregion

        #region Public mathematical operations
        
        /// <summary>
        ///     Performs vector addition on the current vector with the one provided as a parameter
        /// </summary>
        /// <param name="other">The vector that needs to be added to the current vector</param>
        /// <returns></returns>
        public Vector<T> Sum(Vector<T> other)
        {
            if (Dimension != other.Dimension)
                throw new VectorAdditionException("The provided vectors can't be added as their dimension doesn't match");

            T[] sum = new T[Dimension];

            for (int i = 0; i < Dimension; i++)
            {
                sum[i] = _elements[i] + other[i];
            }

            return new Vector(sum);
        }

        /// <summary>
        /// Performs vector addition on the current vector with the one provided as a parameter
        /// </summary>
        /// <param name="v1">First vector to be added</param>
        /// <param name="v2">Second vector to be added</param>
        /// <returns></returns>
        public static Vector Sum(Vector v1, Vector v2)
        {
            if (v1.Dimension != v2.Dimension)
                throw new VectorAdditionException("The provided vectors can't be added as their dimension doesn't match");

            int[] sum = new int[v1.Dimension];
            for (int i = 0; i < v1.Dimension; i++)
            {
                sum[i] = v1[i] + v2[i];
            }

            return new Vector(sum);
        }

        /// <summary>
        /// Multiplies the vector by a scalar value
        /// </summary>
        /// <param name="scalar">The scalare used for multiplication</param>
        /// <returns>a new Vector containing the result of the multiplication</returns>
        public Vector ScalarMultiplication(int scalar)
        {
            int[] products = new int[Dimension];
            for (int i = 0; i < Dimension; i++)
            {
                products[i] = _elements[i] * scalar;
            }

            return new Vector(products);
        }

        /// <summary>
        /// Multiplies a vector by a scalar value
        /// </summary>
        /// <param name="v1">The vector to be multiplied</param>
        /// <param name="scalar">The scalar value to multiply by</param>
        /// <returns></returns>
        public static Vector ScalarMultiplication(Vector v1, int scalar)
        {
            int[] products = new int[v1.Dimension];
            for (int i = 0; i < v1.Dimension; i++)
            {
                products[i] = v1[i] * scalar;
            }

            return new Vector(products);
        }

        /// <summary>
        /// Multiplies two vectors of the same dimension
        /// </summary>
        /// <param name="v2">Second vector for the multiplication</param>
        /// <returns>A new vector as resulted after the dor product operation</returns>
        public Vector DotProduct(Vector v2)
        {
            if (Dimension != v2.Dimension)
                throw new VectorAdditionException("The provided vectors can't be added as their dimension doesn't match");
            int[] products = new int[Dimension];

            for (int i = 0; i < Dimension; i++)
            {
                products[i] = _elements[i] * v2[i];
            }

            return new Vector(products);
        }

        /// <summary>
        /// Generates the dot product of two vectors
        /// </summary>
        /// <param name="v1">First Vector</param>
        /// <param name="v2">Second Vector</param>
        /// <returns></returns>
        public static Vector DotProduct(Vector v1, Vector v2)
        {
            if (v1.Dimension != v2.Dimension)
                throw new VectorAdditionException("The provided vectors can't be added as their dimension doesn't match");

            int[] products = new int[v2.Dimension];

            for (int i = 0; i < v1.Dimension; i++)
            {
                products[i] = v1[i] * v2[i];
            }

            return new Vector(products);
        }
        #endregion

        #region Interface implementations
        public IEnumerator GetEnumerator()
        {
            foreach (var element in _elements)
            {
                yield return element;
            }
        }

        public new bool Equals(object x, object y)
        {
            if (!(x is Vector) && !(y is Vector))
                return false;

            var v1 = (Vector)x;
            var v2 = (Vector)y;

            if (v1.Dimension != v2.Dimension)
                return false;

            for (int i = 0; i < v1.Dimension; i++)
            {
                if (v1[i] != v2[i])
                    return false;
            }

            return true;
        }

        public bool Equals(Vector other)
        {
            if (Dimension != other.Dimension)
                return false;

            for (int i = 0; i < Dimension; i++)
            {
                if (_elements[i] != other[i])
                    return false;
            }

            return true;
        }

        public int GetHashCode(object obj)
        {
            if (!(obj is Vector<T>))
                return obj.GetHashCode();

            var v1 = (Vector<T>)obj;
            int hashSum = 0;
            foreach (var element in v1)
            {
                hashSum += element.GetHashCode();
            }

            return hashSum;
        }
        #endregion

        #region Overrides
        /// <summary>
        ///     Return a string representation of the vector
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //[ x, y, z ]
            var sb = new StringBuilder();
            sb.Append("[ ");
            for (int i = 0; i < _elements.Length; i++)
            {
                if (i == _elements.Length - 1)
                    sb.Append($"{_elements[i]} ]");
                else
                    sb.Append($"{_elements[i]}, ");
            }
            return sb.ToString();
        }
        #endregion

        #region Operators

        public static bool operator ==(Vector v1, Vector v2)
        {
            return v1.Equals(v2);
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1 == v2);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return v1.Sum(v2);
        }

        public static Vector operator *(Vector v1, Vector v2)
        {
            return v1.DotProduct(v2);
        }

        #endregion

        #region Private methods
        private static double GetMagnitude(T[] elements)
        {
            double squareSum = 0;

            foreach (var element in elements)
            {
                var convertedElement = Convert.ToDouble(element);
                squareSum += Math.Pow(convertedElement, 2);
            }

            var result = Math.Sqrt(squareSum);
            return Math.Round(result, 3);
        }
        #endregion
    }
}
