using System;
using OpenTK.Platform.SDL2.Interfaces;
using AdvancedDLSupport;

namespace OpenTK.Platform.SDL2
{
    public abstract partial class SDL : NativeLibraryBase, ISDL2
    {
        public abstract void JoystickClose(IntPtr joystick);

        /// <inheritdoc/>
        public abstract EventState JoystickEventState(EventState state);

        /// <inheritdoc/>
        public abstract short JoystickGetAxis(IntPtr joystick, int axis);

        /// <inheritdoc/>
        public abstract byte JoystickGetButton(IntPtr joystick, int button);

        /// <inheritdoc/>
        public abstract JoystickGuid JoystickGetGUID(IntPtr joystick);

        /// <inheritdoc/>
        public abstract int JoystickInstanceID(IntPtr joystick);

        /// <inheritdoc/>
        public abstract IntPtr JoystickNameInternal(IntPtr joystick);

        /// <inheritdoc/>
        public abstract int JoystickNumAxes(IntPtr joystick);

        /// <inheritdoc/>
        public abstract int JoystickNumBalls(IntPtr joystick);

        /// <inheritdoc/>
        public abstract int JoystickNumButtons(IntPtr joystick);

        /// <inheritdoc/>
        public abstract int JoystickNumHats(IntPtr joystick);

        /// <inheritdoc/>
        public abstract IntPtr JoystickOpen(int device_index);

        /// <inheritdoc/>
        public abstract void JoystickUpdate();

        /// <inheritdoc/>
        public abstract int NumJoysticks();
    }
}