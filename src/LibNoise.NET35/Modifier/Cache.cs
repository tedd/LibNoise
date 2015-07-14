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

namespace LibNoise.Modifier
{
    /// <summary>
    /// Noise module that caches the last output value generated by a source
    /// module.
    ///
    /// If an application passes an input value to the GetValue() method that
    /// differs from the previously passed-in input value, this noise module
    /// instructs the source module to calculate the output value.  This
    /// value, as well as the ( @a x, @a y, @a z ) coordinates of the input
    /// value, are stored (cached) in this noise module.
    ///
    /// If the application passes an input value to the GetValue() method
    /// that is equal to the previously passed-in input value, this noise
    /// module returns the cached output value without having the source
    /// module recalculate the output value.
    ///
    /// If an application passes a new source module to the SetSourceModule()
    /// method, the cache is invalidated.
    ///
    /// Caching a noise module is useful if it is used as a source module for
    /// multiple noise modules.  If a source module is not cached, the source
    /// module will redundantly calculate the same output value once for each
    /// noise module in which it is included.
    /// </summary>
    public class Cache : ModifierModule, IModule3D
    {
        #region Fields

        /// <summary>
        /// The cached output value at the cached input value.
        /// </summary>
        protected double _cachedValue = 0.0f;

        /// <summary>
        /// Determines if a cached output value is stored in this noise
        /// module.
        /// </summary>
        protected bool _isCached = false;

        /// <summary>
        /// x coordinate of the cached input value.
        /// </summary>
        protected double _xCache = 0.0f;

        /// <summary>
        /// y coordinate of the cached input value.
        /// </summary>
        protected double _yCache = 0.0f;

        /// <summary>
        /// z coordinate of the cached input value.
        /// </summary>
        protected double _zCache = 0.0f;

        #endregion

        #region Accessors

        /// <summary>
        /// Gets or sets the source module
        /// </summary>
        public new IModule SourceModule
        {
            get { return _sourceModule; }
            set
            {
                _isCached = false;
                _sourceModule = value;
            }
        }

        #endregion

        #region Ctor/Dtor

        public Cache()
        {
        }


        public Cache(IModule source)
            : base(source)
        {
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
            //original code
            //if(!(_isCached && x == _xCache && y == _yCache && z == _zCache)){ // Original condition
            if (!_isCached || x != _xCache || y != _yCache || z != _zCache)
            {
                _cachedValue = ((IModule3D) _sourceModule).GetValue(x, y, z);
                _xCache = x;
                _yCache = y;
                _zCache = z;

                _isCached = true;
            }

            return _cachedValue;
        }

        #endregion
    }
}
