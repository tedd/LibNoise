﻿// This file is part of libnoise-dotnet.
//
// libnoise-dotnet is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// libnoise-dotnet is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with libnoise-dotnet.  If not, see <http://www.gnu.org/licenses/>.
// 
// From the original Jason Bevins's Libnoise (http://libnoise.sourceforge.net)


namespace LibNoise.Renderer
{
    using System;

    /// <summary>
    /// Defines a point used to build a color gradient.
    ///
    /// A color gradient is a list of gradually-changing colors.  A color
    /// gradient is defined by a list of <i>gradient points</i>.  Each
    /// gradient point has a position and a color.  In a color gradient, the
    /// colors between two adjacent gradient points are linearly interpolated.
    ///
    /// The ColorGradient class defines a color gradient by a list of these
    /// objects.
    /// </summary>
    public struct GradientPoint : IEquatable<GradientPoint>
    {
        #region fields

        /// <summary>
        /// Internal hashcode
        /// </summary>
        private readonly int _hashcode;

        /// <summary>
        /// The color of this gradient point.
        /// </summary>
        public IColor Color;

        /// <summary>
        /// The position of this gradient point.
        /// </summary>
        public double Position;

        #endregion

        #region Ctor/Dtor

        public GradientPoint(double position, IColor color)
        {
            Color = color;
            Position = position;
            _hashcode = (int) Position ^ Color.GetHashCode();
        }

        #endregion

        #region Interface implementation

        public bool Equals(GradientPoint other)
        {
            return Position == other.Position;
        }

        #endregion

        #region Overloading

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _hashcode;
        }

        #endregion
    }
}
