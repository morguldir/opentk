using System;

namespace OpenTK.Platform.SDL2.Interfaces
{
    internal interface ISDL2Surface
    {
        /// <summary>
        /// Use this function to allocate a new RGB surface with existing pixel data. 
        /// </summary>
        /// <param name="pixels">a pointer to existing pixel data</param>
        /// <param name="width">the width of the surface</param>
        /// <param name="height">the height of the surface</param>
        /// <param name="depth">the depth of the surface in bits; see Remarks for details</param>
        /// <param name="pitch">the length of a row of pixels in bytes</param>
        /// <param name="Rmask">the red mask for the pixels</param>
        /// <param name="Gmask">the green mask for the pixels</param>
        /// <param name="Bmask">the blue mask for the pixels</param>
        /// <param name="Amask">the alpha mask for the pixels</param>
        /// <returns>Returns a new <see cref="Surface"/> that is created or <see cref="IntPtr.Zero"/> if it fails; 
        /// call <see cref="GetError()"/> for more information. </returns>
        IntPtr CreateRGBSurfaceFrom(IntPtr pixels, int width, int height, int depth, 
            int pitch, uint Rmask, uint Gmask, uint Bmask, uint Amask);

        /// <summary>
        /// Use this function to free an RGB surface. 
        /// </summary>
        /// <param name="surface">the <see cref="IntPtr"/> to free</param>
        /// <remarks>If the surface was created using <see cref="CreateRGBSurfaceFrom()"/> then the pixel data is not freed.
        /// It is safe to pass <see cref="IntPtr.Zero"/> to this function. </remarks>
        void FreeSurface(IntPtr surface);

        
    }
}