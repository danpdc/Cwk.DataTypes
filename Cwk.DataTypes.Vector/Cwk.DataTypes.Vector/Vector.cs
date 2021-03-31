using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Cwk.DataTypes.Vector
{
    public struct Vector : IEnumerable, IEqualityComparer, IEquatable<Vector>
    {
        #region Fields and constructors
        private readonly int[] _elements;

        /// <summary>
        ///     Creates a new vector
        /// </summary>
        /// <param name="elements">A list of integers defining the vector elements</param>
        public Vector(List<int> elements)
        {
            _elements = elements.ToArray();
            Dimension = _elements.Length;
        }

        /// <summary>
        ///     Creates a new vector
        /// </summary>
        /// <param name="elements">An array of int defining the vector elements</param>
        public Vector(int[] elements)
        {
            _elements = elements;
            Dimension = _elements.Length;
        }
        #endregion

        #region Public properties
        public int Dimension { get; private set; }

        public int this[int i]
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
        public static bool Equals(Vector v1, Vector v2)
        {
            return v1.Equals(v2);
        }

        public override int GetHashCode()
        {
            return GetHashCode(this);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector))
                return false;

            var v1 = (Vector)obj;
            
            return Equals(v1);
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
            if (!(obj is Vector))
                return obj.GetHashCode();

            var v1 = (Vector)obj;
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

        #endregion

        #region Private methods
        #endregion
    }
}
