using System;
using AdvancedDLSupport;
using AdvancedDLSupport.AOT;

namespace OpenTK.Platform.SDL2.Interfaces
{
    [NativeSymbols(Prefix = "SDL_"), AOTType]
    internal partial interface IVideo
    {
        /// <summary>
        /// Use this function to create a window with the specified position, dimensions, and flags. 
        /// </summary>
        /// <param name="title">the title of the window, in UTF-8 encoding</param>
        /// <param name="x">the x position of the window</param>
        /// <param name="y">the y position of the window</param>
        /// <param name="w">the width of the window, in screen coordinates</param>
        /// <param name="h">the height of the window, in screen coordinates</param>
        /// <param name="flags">0, or one or more <see cref="SDL2.WindowFlags"/> OR'd together; 
        /// see Remarks for details</param>
        /// <returns>Returns the window that was created or <see cref="ISDL2.GetError"/> on failure; call <see cref="GetError()"/> for more information.</returns>
        IntPtr CreateWindow(string title, int x, int y, int w, int h, WindowFlags flags);

        /// <summary>
        /// Use this function to create an SDL window from an existing native window. 
        /// </summary>
        /// <param name="data">a pointer to driver-dependent window creation data, typically your native window cast to a <see cref="IntPtr"/></param>
        /// <returns>Returns the window that was created or <see cref="IntPtr.Zero"/> on failure; call <see cref="GetError"/> for more information. </returns>
        IntPtr CreateWindowFrom(IntPtr data);

        /// <summary>
        /// Use this function to destroy a window. 
        /// </summary>
        /// <param name="window"></param>
        /// <remarks>If window is <see cref="IntPtr.Zero"/>, this function will return immediately after setting the SDL error message to "Invalid window". 
        /// See <see cref="ISDL2.GetError()"/> </remarks>
        void DestroyWindow(IntPtr window);

        /// <summary>
        /// Use this function to prevent the screen from being blanked by a screen saver. 
        /// </summary>
        void DisableScreenSaver();

        /// <summary>
        /// Use this function to get information about the current display mode. 
        /// </summary>
        /// <param name="displayIndex">the index of the display to query.</param>
        /// <param name="mode">an <see cref="DisplayMode"/> structure filled in with the current display mode.</param>
        /// <returns></returns>
        int GetCurrentDisplayMode(int displayIndex, out DisplayMode mode);

        /// <summary>
        /// Use this function to get the desktop area represented by a display, with the primary display located at 0,0.
        /// </summary>
        /// <param name="displayIndex">the index of the display to query.</param>
        /// <param name="rect">the <see cref="Rect"/> structure filled in with the display bounds.</param>
        /// <returns></returns>
        int GetDisplayBounds(int displayIndex, out Rect rect);

        /// <summary>
        /// Use this function to get information about a specific display mode. 
        /// </summary>
        /// <param name="displayIndex">the index of the display to query</param>
        /// <param name="modeIndex">the index of the display mode to query</param>
        /// <param name="mode">an <see cref="DisplayMode"/> structure filled in with the mode at modeIndex</param>
        /// <returns>Returns 0 on success or a negative error code on failure; call <see cref="GetError()"/> for more information. </returns>
        int GetDisplayMode(int displayIndex, int modeIndex, out DisplayMode mode);

        /// <summary>
        /// Use this function to get the number of available display modes. 
        /// </summary>
        /// <param name="displayIndex">the index of the display to query</param>
        /// <returns>Returns a number >= 1 on success or a negative error code on failure; call <see cref="GetError()"/> for more information. </returns>        
        int GetNumDisplayModes(int displayIndex);

        /// <summary>
        /// Use this function to get the number of available video displays. 
        /// </summary>
        /// <returns>Returns a number >= 1 or a negative error code on failure; call <see cref="GetError()"/> for more information. </returns>
        int GetNumVideoDisplays();

        /// <summary>
        /// Use this function to get the numeric ID of a window, for logging purposes. 
        /// </summary>
        /// <param name="window">the window to query</param>
        /// <returns>Returns the ID of the window on success or 0 on failure; call <see cref="GetError()"/>for more information. </returns>
        uint GetWindowID(IntPtr window);

        /// <summary>
        /// Use this function to get the position of a window. 
        /// </summary>
        /// <param name="window">the window to query</param>
        /// <param name="x">the x position of the window, in screen coordinates</param>
        /// <param name="y">the y position of the window, in screen coordinates</param>
        void GetWindowPosition(IntPtr window, out int x, out int y);

        /// <summary>
        /// Use this function to get the size of a window's client area. 
        /// </summary>
        /// <param name="window">the window to query the width and height from</param>
        /// <param name="w">the length of the window, in screen coordinates.</param>
        /// <param name="h">the height of the window, in screen coordinates.</param>
        void GetWindowSize(IntPtr window, out int w, out int h);

        /// <summary>
        /// Use this function to get the title of a window. 
        /// </summary>
        /// <param name="window">the window to query</param>
        /// <returns>Returns the title of the window in UTF-8 format or "" if there is no title. </returns>
        [NativeSymbol("GetWindowTitle")]
        IntPtr GetWindowTitlePrivate(IntPtr window);

        /// <summary>
        /// Use this function to get driver specific information about a window. 
        /// </summary>
        /// <param name="window">the window about which information is being requested</param>
        /// <param name="info">an <see cref="SysWMInfo"/> structure filled in with window information; see Remarks for details</param>
        /// <returns></returns>
        /// <remarks>The info structure must be initialized with the SDL version, and is then filled in with information about the given window</remarks>
        [NativeSymbol("GetWindowWMInfo")]
        bool GetWindowWMInfoInternal(IntPtr window, ref SysWMInfo info);

        /// <summary>
        /// Use this function to hide a window. 
        /// </summary>
        /// <param name="window">the window to hide</param>
        void HideWindow(IntPtr window);

        /// <summary>
        /// Use this function to make a window as large as possible. 
        /// </summary>
        /// <param name="window">the window to maximize</param>
        void MaximizeWindow(IntPtr window);

        /// <summary>
        /// Use this function to minimize a window to an iconic representation. 
        /// </summary>
        /// <param name="window">the window to minimize</param>
        void MinimizeWindow(IntPtr window);

        /// <summary>
        /// Use this function to raise a window above other windows and set the input focus. 
        /// </summary>
        /// <param name="window">the window to raise</param>
        void RaiseWindow(IntPtr window);

        /// <summary>
        /// Use this function to restore the size and position of a minimized or maximized window. 
        /// </summary>
        /// <param name="window">the window to restore</param>
        void RestoreWindow(IntPtr window);

        /// <summary>
        /// Use this function to set the border state of a window. 
        /// </summary>
        /// <param name="window">the window of which to change the border state</param>
        /// <param name="bordered"><c>false</c> to remove border, <c>true</c> to add border</param>
        void SetWindowBordered(IntPtr window, bool bordered);

        /// <summary>
        /// Use this function to set a window's fullscreen state. 
        /// </summary>
        /// <param name="window">the window to change</param>
        /// <param name="flags"><see cref="WindowFlags.FULLSCREEN"/>, <see cref="WindowFlags.FULLSCREEN_DESKTOP"/> or 0; see Remarks for details</param>
        /// <returns></returns>
        /// <remarks>flags may be <see cref="WindowFlags.FULLSCREEN"/>, for "real" fullscreen with a videomode change; 
        /// <see cref="WindowFlags.FULLSCREEN_DESKTOP"/> for "fake" fullscreen that takes the size of the desktop; and 0 for windowed mode. </remarks>
        int SetWindowFullscreen(IntPtr window, uint flags);

        /// <summary>
        /// Use this function to set a window's input grab mode. 
        /// </summary>
        /// <param name="window">the window for which the input grab mode should be set</param>
        /// <param name="grabbed"><c>true</c> to grab input or <c>false</c> to release input</param>
        /// <remarks>
        /// When input is grabbed the mouse is confined to the window.
        /// If the caller enables a grab while another window is currently grabbed, 
        /// the other window loses its grab in favor of the caller's window. 
        /// </remarks>
        void SetWindowGrab(IntPtr window, bool grabbed);

        /// <summary>
        /// Use this function to set the icon for a window. 
        /// </summary>
        /// <param name="window">the window to change</param>
        /// <param name="icon">a surface structure containing the icon for the window</param>
        void SetWindowIcon(IntPtr window, IntPtr icon);

        /// <summary>
        /// Use this function to set the position of a window. 
        /// </summary>
        /// <param name="window">the window to reposition</param>
        /// <param name="x">the x coordinate of the window in screen coordinates</param>
        /// <param name="y">the y coordinate of the window in screen coordinates</param>
        void SetWindowPosition(IntPtr window, int x, int y);

        /// <summary>
        /// Use this function to set the size of a window's client area. 
        /// </summary>
        /// <param name="window">the window to change</param>
        /// <param name="x">the width of the window in pixels, in screen coordinates, must be > 0</param>
        /// <param name="y">the height of the window in pixels, in screen coordinates, must be > 0</param>
        void SetWindowSize(IntPtr window, int x, int y);

        /// <summary>
        /// Use this function to set the title of a window. 
        /// </summary>
        /// <param name="window">the window to change</param>
        /// <param name="title">the desired window title in UTF-8 format</param>
        void SetWindowTitle(IntPtr window, string title);

        /// <summary>
        /// Use this function to show a window. 
        /// </summary>
        /// <param name="window">the window to show</param>
        void ShowWindow(IntPtr window);
    }
}
