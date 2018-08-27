using System;
using AdvancedDLSupport;
using OpenTK.Platform.SDL2.Interfaces;

namespace OpenTK.Platform.SDL2
{
    internal abstract partial class SDL: NativeLibraryBase, ISDL2
    {
        /// <inheritdoc/>
        internal abstract void free(IntPtr memblock);

        /// <inheritdoc/>
        internal abstract IntPtr GetErrorInternal();
 
        /// <inheritdoc/>
        internal abstract void GetVersion(out Version version);

        /// <inheritdoc/>
        internal abstract bool PixelFormatEnumToMasks(uint format, out int bpp, out uint rmask, out uint gmask, out uint bmask, out uint amask);
    }
}
