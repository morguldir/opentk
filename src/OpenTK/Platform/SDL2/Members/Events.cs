using System;
using AdvancedDLSupport;
using OpenTK.Platform.SDL2.Interfaces;

namespace OpenTK.Platform.SDL2
{
    public abstract partial class SDL : NativeLibraryBase, ISDL2
    {
        /// <inheritdoc />
        public abstract void AddEventWatch(EventFilter filter, IntPtr userdata);

        /// <inheritdoc />
        public abstract void AddEventWatch(IntPtr filter, IntPtr userdata);

        /// <inheritdoc />
        public abstract void DelEventWatch(EventFilter filter, IntPtr userdata);

        /// <inheritdoc />
        public abstract void DelEventWatch(IntPtr filter, IntPtr userdata);

        /// <inheritdoc />
        public abstract int PollEvent(out Event e);

        /// <inheritdoc />
        public abstract void PumpEvents();

        /// <inheritdoc />
        public abstract int PushEvent(ref Event @event);

        /// <inheritdoc />
        public abstract unsafe int PeepEvents(Event * e, int count, EventAction action, EventType min, EventType max);
    }
}
