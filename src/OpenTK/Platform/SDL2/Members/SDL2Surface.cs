using System;
using AdvancedDLSupport;
using OpenTK.Platform.SDL2.Interfaces;

namespace OpenTK.Platform.SDL2
{
    internal abstract partial class SDL : NativeLibraryBase, ISDL2
    {
        /// <inheritdoc/>
        internal abstract IntPtr CreateRGBSurfaceFrom(IntPtr pixels, int width, int height, int depth,
            int pitch, uint Rmask, uint Gmask, uint Bmask, uint Amask);

        /// <inheritdoc/>
        internal abstract void FreeSurface(IntPtr surface);
    }
}