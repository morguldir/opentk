using System;
using AdvancedDLSupport;
using OpenTK.Platform.SDL2.Interfaces;

namespace OpenTK.Platform.SDL2
{
    public abstract partial class SDL : NativeLibraryBase, ISDL2
    {
        /// <inheritdoc/>
        public abstract Keymod GetModState();

        /// <inheritdoc/>
        public abstract Scancode GetScancodeFromKey(Keycode key);
    }
}