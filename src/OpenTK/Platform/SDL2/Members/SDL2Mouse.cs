using System;
using AdvancedDLSupport;
using OpenTK.Platform.SDL2.Interfaces;

namespace OpenTK.Platform.SDL2
{
    using Cursor = IntPtr;
    using Surface = IntPtr;
    internal abstract partial class SDL : NativeLibraryBase, ISDL2
    {
        /// <inheritdoc/>
        internal abstract Cursor CreateColorCursor(Surface surface, int hot_x, int hot_y);

        /// <inheritdoc/>
        internal abstract IntPtr GetDefaultCursor();

        /// <inheritdoc/>
        internal abstract ButtonFlags GetGlobalMouseState(out int hx, out int hy);

        /// <inheritdoc/>
        internal abstract ButtonFlags GetMouseState(out int hx, out int hy);

        /// <inheritdoc/>
        internal abstract int SetRelativeMouseMode(bool enabled);

        /// <inheritdoc/>
        internal abstract int ShowCursor(bool toggle);

        /// <inheritdoc/>
        internal abstract void WarpMouseGlobal(int x, int y);

        /// <inheritdoc/>
        internal abstract void WarpMouseInWindow(IntPtr window, int x, int y);

    }
}