using System;
using AdvancedDLSupport;
using OpenTK.Platform.SDL2.Interfaces;

namespace OpenTK.Platform.SDL2
{
    public abstract partial class GL : NativeLibraryBase, IGLVideo
    {
        protected GL(string path, ImplementationOptions options) : base(path, options)
        { }

        /// <inheritdoc />
        public abstract IntPtr CreateContext(IntPtr window);

        /// <inheritdoc />
        public abstract void DeleteContext(IntPtr context);

        /// <inheritdoc />
        public abstract int GetAttribute(ContextAttribute attr, out int value);

        /// <inheritdoc />
        public abstract IntPtr GetCurrentContext();

        /// <inheritdoc />
        public abstract void GetDrawableSize(IntPtr window, out int w, out int h);

        /// <inheritdoc />
        public abstract IntPtr GetProcAddress(IntPtr proc);

        /// <inheritdoc />
        public abstract int GetSwapInterval();

        /// <inheritdoc />
        public abstract int MakeCurrent(IntPtr window, IntPtr context);

        /// <inheritdoc />
        public abstract int SetAttribute(ContextAttribute attr, int value);

        /// <inheritdoc />
        public abstract int SetSwapInterval(int interval);

        /// <inheritdoc />
        public abstract void SwapWindow(IntPtr window);
    }
}
