using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Particle.Infrastructure.Model
{
    /// <summary>
    /// Defines the base type for all domain value objects.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValueObject
    {
        #region Fields

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Key
        { get; set; }

        #endregion

        #region Constructors

        #endregion

        #region Methods

        public override bool Equals(object obj)
        {
            var @object = obj as ValueObject;
            return @object != null &&
                   Key == @object.Key;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Key);
        }

        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }


        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }

        #endregion
    }
}
