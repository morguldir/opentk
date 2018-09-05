using System;
using OpenTK.Platform.SDL2.Interfaces;
using AdvancedDLSupport;

namespace OpenTK.Platform.SDL2
{
    public abstract partial class SDL: NativeLibraryBase, ISDL2
    {
        /// <inheritdoc /> 
        public abstract int Init(SystemFlags flags);

        /// <inheritdoc /> 
        public abstract int InitSubSystem(SystemFlags flags);

        /// <inheritdoc /> 
        public abstract bool WasInit(SystemFlags flags);

    }
}