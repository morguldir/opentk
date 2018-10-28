using System;
using AdvancedDLSupport;
using AdvancedDLSupport.AOT;

namespace OpenTK.Platform.SDL2.Interfaces
{
    [NativeSymbols(Prefix = "SDL_"), AOTType]
    internal interface IMouse
    {
        /// <summary>
        /// Use this function to create a color cursor. 
        /// </summary>
        /// <param name="surface">a <see cref="IntPtr" /> structure representing the cursor image</param>
        /// <param name="hot_x">the x position of the cursor hot spot</param>
        /// <param name="hot_y">the y position of the cursor hot spot</param>
        /// <returns>Returns the new cursor on success or <see cref="IntPtr.Zero" /> on failure; call <see cref="GetError()" /> for more information. </returns>
        IntPtr CreateColorCursor(IntPtr surface, int hot_x, int hot_y);

        /// <summary>
        /// Use this function to free a cursor created with SDL_CreateColorCursor() 
        /// </summary>
        /// <param name="cursor">the cursor to free</param>
        void FreeCursor(IntPtr cursor);

        /// <summary>
        /// Use this function to get the default cursor. 
        /// </summary>
        /// <returns>Returns the default cursor on success or <see cref="IntPtr.Zero"> on failure. </returns>
        IntPtr GetDefaultCursor();

        /// <summary>
        /// Use this function to get the current state of the mouse in relation to the desktop.
        /// </summary>
        /// <param name="x">the current X coord relative to the desktop</param>
        /// <param name="y">the current Y coord relative to the desktop</param>
        /// <returns>Returns the current button state as an enum which can be tested against the <see cref="OpenTK.Input.MouseButton"/> enum. </returns>
        ButtonFlags GetGlobalMouseState(out int hx, out int hy);

        /// <summary>
        /// Use this function to retrieve the current state of the mouse. 
        /// </summary>
        /// <param name="hx">the x coordinate of the mouse cursor position relative to the focus window</param>
        /// <param name="hy">the y coordinate of the mouse cursor position relative to the focus window</param>
        /// <returns>Returns a 32-bit button bitmask of the current button state.</returns>
        ButtonFlags GetMouseState(out int hx, out int hy);

        /// <summary>
        /// Use this function to set the active cursor.
        /// </summary>
        /// <param name="cursor">a cursor to make active; see remarks for details</param>
        /// <remarks>This function sets the currently active cursor to the specified one. 
        /// If the cursor is currently visible, the change will be immediately represented on the display. 
        /// <see cref="SetCursor(IntPtr.Zero)"/> can be used to force cursor redraw, if this is desired for any reason. </remarks>
        void SetCursor(IntPtr cursor);

        /// <summary>
        /// Use this function to set relative mouse mode. 
        /// </summary>
        /// <param name="enabled">whether or not to enable relative mode, SDL_TRUE for enabled relative mode</param>
        /// <returns>Returns 0 on success or a negative error code on failure; call <see cref="GetError()"/> for more information.
        /// If relative mode is not supported this returns -1. </returns>
        int SetRelativeMouseMode(bool enabled);

        /// <summary>
        /// Use this function to toggle whether or not the cursor is shown. 
        /// </summary>
        /// <param name="toggle"><see cref="true"/>to show the cursor, <see cref="false"/>to hide it</param>
        /// <returns>Returns <see cref="true"/> if the cursor is shown, or <see cref="false"/> if the cursor is hidden, or a negative error code on failure; call <see cref="GetError()"/> for more information. </returns>
        int ShowCursor(bool toggle);

        /// <summary>
        /// Use this function to move the mouse to the given position in global screen space. 
        /// </summary>
        /// <param name="x">the x coordinate</param>
        /// <param name="y">the y coordinate</param>
        void WarpMouseGlobal(int x, int y);

        /// <summary>
        /// Use this function to move the mouse to the given position within the window. 
        /// </summary>
        /// <param name="window">the window to move the mouse into, or <see cref="IntPtr.Zero"/>for the current mouse focus</param>
        /// <param name="x">the x coordinate within the window</param>
        /// <param name="y">the y coordinate within the window</param>
        void WarpMouseInWindow(IntPtr window, int x, int y);
    }
}
