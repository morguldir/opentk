using System;
using AdvancedDLSupport;

namespace OpenTK.Platform.SDL2
{
    public abstract partial class SDL : NativeLibraryBase, Interfaces.ISDL2
    {
        /// <inheritdoc/>
        public abstract EventState GameControllerEventState(EventState state);

        /// <inheritdoc/>
        public abstract short GameControllerGetAxis(IntPtr gamecontroller, GameControllerAxis axis);

        /// <inheritdoc/>
        public abstract GameControllerButtonBind GameControllerGetBindForAxis(IntPtr gamecontroller, GameControllerAxis axis);

        /// <inheritdoc/>
        public abstract GameControllerButtonBind GameControllerGetBindForButton(IntPtr gamecontroller, GameControllerButton button);

        /// <inheritdoc/>
        public abstract bool GameControllerGetButton(IntPtr gamecontroller, GameControllerButton button);

        /// <inheritdoc/>
        public abstract IntPtr GameControllerGetJoystick(IntPtr gamecontroller);

        /// <inheritdoc/>
        public abstract IntPtr GameControllerNameInternal(IntPtr gamecontroller);

        /// <inheritdoc/>
        public abstract IntPtr GameControllerOpen(int joystick_index);

        /// <inheritdoc/>
        public abstract bool IsGameController(int joystick_index);
    }
}
