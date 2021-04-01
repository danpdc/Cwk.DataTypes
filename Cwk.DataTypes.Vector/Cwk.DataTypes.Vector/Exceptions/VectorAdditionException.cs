using System;
using System.Collections.Generic;
using System.Text;

namespace Cwk.DataTypes.Vector.Exceptions
{
    public class VectorAdditionException : Exception
    {
        public VectorAdditionException() {}

        public VectorAdditionException(string message) : base(message) {}
    }
}
