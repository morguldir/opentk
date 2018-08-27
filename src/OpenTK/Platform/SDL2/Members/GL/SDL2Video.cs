using System;
using AdvancedDLSupport;
using OpenTK.Platform.SDL2.Interfaces;

namespace OpenTK.Platform.SDL2.Interfaces
{
    internal abstract partial class SDL : NativeLibraryBase, ISDL2
    {
        internal abstract partial class GL
        {
            internal abstract IntPtr CreateContext(IntPtr window);

            internal abstract int GetAttribute(Attribute attr, out int value);

            internal abstract IntPtr GetCurrentContext();

            internal abstract void GetDrawableSize(IntPtr window, out int w, out int h);

            internal abstract IntPtr GetProcAddress(IntPtr proc);

            internal abstract int GetSwapInterval();

            internal abstract int MakeCurrent(IntPtr window, IntPtr context);

            internal abstract int SetAttribute(Attribute attr, int value);

            internal abstract void SwapWindow(IntPtr window);

        }
    }
}