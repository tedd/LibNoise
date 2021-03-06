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

namespace LibNoise.Transformer
{
    /// <summary>
    /// Noise module that scales the coordinates of the input value before
    /// returning the output value from a source module.
    ///
    /// The GetValue() method multiplies the (x, y, z) coordinates
    /// of the input value with a scaling factor before returning the output
    /// value from the source module. 
    ///
    /// </summary>
    public class ScalePoint : TransformerModule, IModule3D
    {
        #region Constants

        /// <summary>
        /// The default scaling factor applied to the x coordinate
        /// </summary>
        public const double DEFAULT_POINT_X = 1.0f;

        /// <summary>
        /// The default scaling factor applied to the y coordinate
        /// </summary>
        public const double DEFAULT_POINT_Y = 1.0f;

        /// <summary>
        /// The default scaling factor applied to the z coordinate
        /// </summary>
        public const double DEFAULT_POINT_Z = 1.0f;

        #endregion

        #region Fields

        /// <summary>
        /// The source input module
        /// </summary>
        protected IModule _sourceModule;

        /// <summary>
        /// the scaling factor applied to the x coordinate
        /// </summary>
        protected double _xScale = DEFAULT_POINT_X;

        /// <summary>
        /// the scaling factor applied to the y coordinate
        /// </summary>
        protected double _yScale = DEFAULT_POINT_Y;

        /// <summary>
        /// the scaling factor applied to the z coordinate
        /// </summary>
        protected double _zScale = DEFAULT_POINT_Z;

        #endregion

        #region Accessors

        /// <summary>
        /// Gets or sets the source module
        /// </summary>
        public IModule SourceModule
        {
            get { return _sourceModule; }
            set { _sourceModule = value; }
        }

        /// <summary>
        /// Gets or sets the scaling factor applied to the x coordinate
        /// </summary>
        public double XScale
        {
            get { return _xScale; }
            set { _xScale = value; }
        }

        /// <summary>
        /// Gets or sets the scaling factor applied to the y coordinate
        /// </summary>
        public double YScale
        {
            get { return _yScale; }
            set { _yScale = value; }
        }

        /// <summary>
        /// Gets or sets the scaling factor applied to the z coordinate
        /// </summary>
        public double ZScale
        {
            get { return _zScale; }
            set { _zScale = value; }
        }

        #endregion

        #region Ctor/Dtor

        /// <summary>
        /// Create a new noise module with default values
        /// </summary>
        public ScalePoint()
        {
        }


        public ScalePoint(IModule source)
        {
            _sourceModule = source;
        }


        /// <summary>
        /// Create a new noise module with given values
        /// </summary>
        /// <param name="source">the source module</param>
        /// <param name="x">the scaling factor applied to the x coordinate</param>
        /// <param name="y">the scaling factor applied to the y coordinate</param>
        /// <param name="z">the scaling factor applied to the z coordinate</param>
        public ScalePoint(IModule source, double x, double y, double z)
            : this(source)
        {
            _xScale = x;
            _yScale = y;
            _zScale = z;
        }

        #endregion

        #region IModule3D Members

        /// <summary>
        /// Generates an output value given the coordinates of the specified input value.
        /// </summary>
        /// <param name="x">The input coordinate on the x-axis.</param>
        /// <param name="y">The input coordinate on the y-axis.</param>
        /// <param name="z">The input coordinate on the z-axis.</param>
        /// <returns>The resulting output value.</returns>
        public double GetValue(double x, double y, double z)
        {
            return ((IModule3D) _sourceModule).GetValue(x*_xScale, y*_yScale, z*_zScale);
        }

        #endregion
    }
}
