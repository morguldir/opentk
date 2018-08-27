using System;
using AdvancedDLSupport;

namespace OpenTK.Platform.SDL2
{
    internal abstract partial class SDL : NativeLibraryBase, Interfaces.ISDL2
    {
        /// <inheritdoc/>
        internal abstract EventState GameControllerEventState(EventState state);

        /// <inheritdoc/>
        internal abstract short GameControllerGetAxis(IntPtr gamecontroller, GameControllerAxis axis);

        /// <inheritdoc/>
        internal abstract GameControllerButtonBind GameControllerGetBindForAxis(IntPtr gamecontroller, GameControllerAxis axis);

        /// <inheritdoc/>
        internal abstract GameControllerButtonBind GameControllerGetBindForButton(IntPtr gamecontroller, GameControllerButton button);

        /// <inheritdoc/>
        internal abstract bool GameControllerGetButton(IntPtr gamecontroller, GameControllerButton button);

        /// <inheritdoc/>
        internal abstract IntPtr GameControllerGetJoystick(IntPtr gamecontroller);

        /// <inheritdoc/>
        internal abstract IntPtr GameControllerNameInternal(IntPtr gamecontroller);

        /// <inheritdoc/>
        internal abstract IntPtr GameControllerOpen(int joystick_index);

        /// <inheritdoc/>
        internal abstract bool IsGameController(int joystick_index);
    }
}