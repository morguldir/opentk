using System;
using AdvancedDLSupport;
using OpenTK.Platform.SDL2.Interfaces;

namespace OpenTK.Platform.SDL2
{
    using Cursor = IntPtr;
    using Surface = IntPtr;
    public abstract partial class SDL : NativeLibraryBase, ISDL2
    {
        /// <inheritdoc /> 
        public abstract Cursor CreateColorCursor(Surface surface, int hot_x, int hot_y);

        /// <inheritdoc /> 
        public abstract void FreeCursor(Cursor cursor);

        /// <inheritdoc /> 
        public abstract IntPtr GetDefaultCursor();

        /// <inheritdoc /> 
        public abstract ButtonFlags GetGlobalMouseState(out int hx, out int hy);

        /// <inheritdoc /> 
        public abstract ButtonFlags GetMouseState(out int hx, out int hy);

        /// <inheritdoc /> 
        public abstract void SetCursor(Cursor cursor);

        /// <inheritdoc /> 
        public abstract int SetRelativeMouseMode(bool enabled);

        /// <inheritdoc /> 
        public abstract int ShowCursor(bool toggle);

        /// <inheritdoc /> 
        public abstract void WarpMouseGlobal(int x, int y);

        /// <inheritdoc /> 
        public abstract void WarpMouseInWindow(IntPtr window, int x, int y);
    }
}
