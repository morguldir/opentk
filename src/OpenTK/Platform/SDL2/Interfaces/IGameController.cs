using System;
using AdvancedDLSupport;

namespace OpenTK.Platform.SDL2.Interfaces
{
    [NativeSymbols(Prefix="SDL_")]
    internal interface IGameController
    {
        /// <summary>
        /// Use this function to find the current state of, enable, or disable events dealing with Game Controllers. 
        /// This will not disable Joystick events, which can also be fired by a controller (see SDL_JoystickEventState()). 
        /// </summary>
        /// <param name="state">can be one of <see cref="EventState.Query"/>, <see cref="EventState.Ignore"/>, or <see cref="EventState.Enable"/></param>
        /// <returns>Returns the same value passed to the function, with exception to <see cref="EventState.Query"/>which will return the current state. </returns>
        /// <remarks>If controller events are disabled, you must call SDL_GameControllerUpdate() yourself and check the state of the controller when you want controller information. 
        /// Any number can be passed to SDL_GameControllerEventState(), but only -1, 0, and 1 will have any effect. 
        /// Other numbers will just be returned. </remarks>
        EventState GameControllerEventState(EventState state);

        /// <summary>
        /// Use this function to get the current state of an axis control on a game controller. 
        /// </summary>
        /// <param name="gamecontroller">a game controller</param>
        /// <param name="axis">an axis index (one of the <c>GameControllerAxis</c> values)</param>
        /// <returns>Returns axis state (including 0) on success or 0 (also) on failure; call <see cref="GetError()"/>for more information. </returns>
        short GameControllerGetAxis(IntPtr gamecontroller, GameControllerAxis axis);

        /// <summary>
        /// Gets the SDL joystick layer binding for the specified game controller axis
        /// </summary>
        /// <param name="gamecontroller">Pointer to a game controller instance returned by <c>GameControllerOpen</c>.</param>
        /// <param name="axis">A value from the <c>GameControllerAxis</c> enumeration</param>
        /// <returns>A GameControllerButtonBind instance describing the specified binding</returns>
        GameControllerButtonBind GameControllerGetBindForAxis(IntPtr gamecontroller, GameControllerAxis axis);

        /// <summary>
        /// Gets the SDL joystick layer binding for the specified game controller button
        /// </summary>
        /// <param name="gamecontroller">Pointer to a game controller instance returned by <c>GameControllerOpen</c>.</param>
        /// <param name="button">A value from the <c>GameControllerButton</c> enumeration</param>
        /// <returns>A GameControllerButtonBind instance describing the specified binding</returns>
        GameControllerButtonBind GameControllerGetBindForButton(IntPtr gamecontroller, GameControllerButton button);

        /// <summary>
        /// Gets the current state of a button on a game controller.
        /// </summary>
        /// <param name="gamecontroller">A game controller handle previously opened with <c>GameControllerOpen</c>.</param>
        /// <param name="button">A zero-based <c>GameControllerButton</c> value.</param>
        /// <returns><c>true</c> if the specified button is pressed;
        /// <c>false</c> otherwise.</returns>
        bool GameControllerGetButton(IntPtr gamecontroller, GameControllerButton button);

        /// <summary>
        /// Retrieve the joystick handle that corresponds to the specified game controller.
        /// </summary>
        /// <param name="gamecontroller">A game controller handle previously opened with <c>GameControllerOpen</c>.</param>
        /// <returns>A handle to a joystick, or IntPtr.Zero in case of error. The pointer is owned by the callee. Use <c>SDL.GetError</c> to retrieve error information</returns>
        IntPtr GameControllerGetJoystick(IntPtr gamecontroller);


        /// <summary>
        /// Use this function to get the implementation dependent name for an opened game controller. 
        /// </summary>
        /// <param name="gamecontroller">a game controller identifier previously returned by <c>GameControllerOpen()</c>.</param>
        /// <returns>Returns the implementation dependent name for the game controller, 
        /// or <c>IntPtr.Zero</c> if there is no name or the identifier passed is invalid.</returns>
        [NativeSymbol("GameControllerName")]
        IntPtr GameControllerNameInternal(IntPtr gamecontroller);

        /// <summary>
        /// Opens a game controller for use.
        /// </summary>
        /// <param name="joystick_index">
        /// A zero-based index for the game controller.
        /// This index is the value which will identify this controller in future controller events.
        /// </param>
        /// <returns>A handle to the game controller instance, or <c>IntPtr.Zero</c> in case of error.</returns>
        IntPtr GameControllerOpen(int joystick_index);

        /// <summary>
        /// Determines if the specified joystick is supported by the GameController API.
        /// </summary>
        /// <returns><c>true</c> if joystick_index is supported by the GameController API;
        /// <c>false</c> otherwise.</returns>
        /// <param name="joystick_index">The index of the joystick to check.</param>
        bool IsGameController(int joystick_index);
    }
}