using System;
using AdvancedDLSupport;

namespace OpenTK.Platform.SDL2.Interfaces
{
    [NativeSymbols(Prefix = "SDL_")]
    internal interface IJoystick
    {
        /// <summary>
        /// Use this function to close a joystick previously opened with SDL_JoystickOpen(). 
        /// </summary>
        /// <param name="joystick">the joystick handle created by <see cref="JoystickOpen()"/></param>
        void JoystickClose(IntPtr joystick);

        /// <summary>
        /// Use this function to enable/disable joystick event polling. 
        /// </summary>
        /// <param name="state">can be <see cref="EventState.Query"/>,<see cref="EventState.Ignore"/> or <see cref="EventState.Query"/></param>
        /// <returns>Returns 1 if enabled, 0 if disabled, or a negative error code on failure; call <see cref="GetError()"/>for more information. </returns>
        EventState JoystickEventState(EventState state);

        /// <summary>
        /// Use this function to get the current state of an axis control on a joystick. 
        /// </summary>
        /// <param name="joystick">the joystick handle</param>
        /// <param name="axis">the axis to query; the axis indices start at index 0; see Remarks for details</param>
        /// <remarks>On most modern joysticks the X axis is usually represented by axis 0 and the Y axis by axis 1. 
        /// The value returned by SDL_JoystickGetAxis() is a signed integer (-32768 to 32767) representing the current position of the axis. 
        /// It may be necessary to impose certain tolerances on these values to account for jitter. </remarks>
        /// <returns></returns>
        short JoystickGetAxis(IntPtr joystick, int axis);

        /// <summary>
        /// Use this function to get the current state of a button on a joystick. 
        /// </summary>
        /// <param name="joystick">the joystick handle</param>
        /// <param name="button">the button index to get the state from; indices start at index 0</param>
        /// <returns>Returns <c>true</c> if the specified button is pressed, <c>false</c> otherwise. </returns>
        byte JoystickGetButton(IntPtr joystick, int button);

        /// <summary>
        /// Use this function to get the implementation-dependent GUID for the joystick. 
        /// </summary>
        /// <param name="joystick">an open joystick</param>
        /// <returns>Returns the GUID of the given joystick. If called on an invalid index, 
        /// this function returns a zero GUID; call <see cref="GetError()"/> for more information. </returns>
        JoystickGuid JoystickGetGUID(IntPtr joystick);

        /// <summary>
        /// Use this function to get the instance ID of an opened joystick. 
        /// </summary>
        /// <param name="joystick">the joystick handle</param>
        /// <returns>Returns the instance ID of the specified joystick on success or
        ///  a negative error code on failure; call <see "GetError()"/>for more information. </returns>
        int JoystickInstanceID(IntPtr joystick);

        /// <summary>
        /// Use this function to get the implementation dependent name of a joystick. 
        /// </summary>
        /// <param name="joystick">the joystick handle obtained from <see cref="JoystickOpen()"/></param>
        /// <returns>Returns the name of the selected joystick. If no name can be found, 
        /// this function returns NULL; call <see cref="GetError()"/>for more information. </returns>
        IntPtr JoystickNameInternal(IntPtr joystick);

        /// <summary>
        /// Use this function to get the number of general axis controls on a joystick. 
        /// </summary>
        /// <param name="joystick">the joystick handle</param>
        /// <returns>Returns the number of axis controls/number of axes on success or
        ///  a negative error code on failure; call <see cref="GetError()"/>for more information. </returns>
        int JoystickNumAxes(IntPtr joystick);

        /// <summary>
        /// Use this function to get the number of trackballs on a joystick. 
        /// </summary>
        /// <param name="joystick">the joystick handle</param>
        /// <returns>Returns the number of trackballs on success or
        ///  a negative error code on failure; call <see cref="GetError()"/>for more information. </returns>
        int JoystickNumBalls(IntPtr joystick);

        /// <summary>
        /// Use this function to get the number of buttons on a joystick. 
        /// </summary>
        /// <param name="joystick">the joystick handle</param>
        /// <returns>Returns the number of buttons on success or a negative 
        /// error code on failure; call <see cref="GetError()"/>for more information. </returns>
        int JoystickNumButtons(IntPtr joystick);

        /// <summary>
        /// Use this function to get the number of POV hats on a joystick. 
        /// </summary>
        /// <param name="joystick">the joystick handle</param>
        /// <returns>Returns the number of POV hats on success or a negative 
        /// error code on failure; call <see cref="GetError()"/>for more information. </returns>
        int JoystickNumHats(IntPtr joystick);

        /// <summary>
        /// Use this function to open a joystick for use. 
        /// </summary>
        /// <param name="device_index">the index of the joystick to query</param>
        /// <returns>Returns a joystick identifier or <c>IntPtr.Zero</c> 
        /// if an error occurred; call <see cref="GetError()"/> for more information. </returns>
        /// <remarks>
        /// The device_index passed as an argument refers to the N'th joystick presently recognized by SDL on the system. 
        /// It is NOT the same as the instance ID used to identify the joystick in future events. See <see cref="JoystickInstanceID()"/>for more details about instance IDs.
        /// The joystick subsystem must be initialized before a joystick can be opened for use. 
        /// </remarks>
        IntPtr JoystickOpen(int device_index);

        /// <summary>
        /// Use this function to update the current state of the open joysticks. 
        /// 
        /// </summary>
        /// <remarks>This is called automatically by the event loop if any joystick events are enabled.</remarks>
        void JoystickUpdate();

        /// <summary>
        /// Use this function to count the number of joysticks attached to the system. 
        /// </summary>
        /// <returns>Returns the number of attached joysticks on success or a negative 
        /// error code on failure; call <see cref="GetError()"/>for more information. </returns>
        int NumJoysticks();
    }
}