using System;
using AdvancedDLSupport;
using OpenTK.Platform.SDL2.Interfaces;

namespace OpenTK.Platform.SDL2
{
    internal abstract partial class SDL : NativeLibraryBase, ISDL2
    {
        /// <inheritdoc/>
        internal abstract Keymod GetModState();

        /// <inheritdoc/>
        internal abstract Scancode GetScancodeFromKey(Keycode key);
    }
}