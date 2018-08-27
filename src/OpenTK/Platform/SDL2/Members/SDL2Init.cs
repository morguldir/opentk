using System;
using OpenTK.Platform.SDL2.Interfaces;
using AdvancedDLSupport;

namespace OpenTK.Platform.SDL2
{
    internal abstract partial class SDL: NativeLibraryBase, ISDL2
    {
        /// <inheritdoc /> 
        internal abstract int Init(SystemFlags flags);

        /// <inheritdoc /> 
        internal abstract int InitSubSystem(SystemFlags flags);

        /// <inheritdoc /> 
        internal abstract bool WasInit(SystemFlags flags);

    }
}