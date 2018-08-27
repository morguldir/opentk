using System;
using AdvancedDLSupport;
using OpenTK.Platform.SDL2.Interfaces;

namespace OpenTK.Platform.SDL2
{
    internal abstract partial class SDL: NativeLibraryBase, ISDL2
    {
        /// <inheritdoc />
        internal abstract void AddEventWatch(EventFilter filter, IntPtr userdata);

        /// <inheritdoc />
        internal abstract void AddEventWatch(IntPtr filter, IntPtr userdata);

        /// <inheritdoc />
        internal abstract void DelEventWatch(EventFilter filter, IntPtr userdata);

        /// <inheritdoc />
        internal abstract void DelEventWatch(IntPtr filter, IntPtr userdata);

        /// <inheritdoc />
        internal abstract int PollEvent(out Event e);

        /// <inheritdoc />
        internal abstract int PushEvent(ref Event @event);
    }
}