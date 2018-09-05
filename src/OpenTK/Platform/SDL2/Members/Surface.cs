using System;
using AdvancedDLSupport;
using OpenTK.Platform.SDL2.Interfaces;

namespace OpenTK.Platform.SDL2
{
    public abstract partial class SDL : NativeLibraryBase, ISDL2
    {
        /// <inheritdoc/>
        public abstract IntPtr CreateRGBSurfaceFrom(IntPtr pixels, int width, int height, int depth,
            int pitch, uint Rmask, uint Gmask, uint Bmask, uint Amask);

        /// <inheritdoc/>
        public abstract void FreeSurface(IntPtr surface);
    }
}