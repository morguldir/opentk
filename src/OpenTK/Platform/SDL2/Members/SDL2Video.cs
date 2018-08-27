using System;
using AdvancedDLSupport;
using OpenTK.Platform.SDL2.Interfaces;

namespace OpenTK.Platform.SDL2
{
    internal abstract partial class SDL: NativeLibraryBase, ISDL2
    {
        /// <inheritdoc /> 
        internal abstract IntPtr CreateWindow(string title, int x, int y, int w, int h, WindowFlags flags);

        /// <inheritdoc />             
        internal abstract IntPtr CreateWindowFrom(IntPtr data);

        /// <inheritdoc />     
        internal abstract void DestroyWindow(IntPtr window);

        /// <inheritdoc /> 
        internal abstract void DisableScreenSaver();

        /// <inheritdoc /> 
        internal abstract int GetCurrentDisplayMode(int displayIndex, out DisplayMode mode);

        /// <inheritdoc /> 
        internal abstract int GetDisplayBounds(int displayIndex, out Rect rect);

        /// <inheritdoc /> 
        internal abstract int GetDisplayMode(int displayIndex, int modeIndex, out DisplayMode mode);

        /// <inheritdoc /> 
        internal abstract int GetNumDisplayModes(int displayIndex);

        /// <inheritdoc /> 
        internal abstract int GetNumVideoDisplays();

        /// <inheritdoc /> 
        internal abstract uint GetWindowID(IntPtr window);

        /// <inheritdoc /> 
        internal abstract void GetWindowPosition(IntPtr window, out int x, out int y);

        /// <inheritdoc /> 
        internal abstract void GetWindowSize(IntPtr window, out int w, out int h);

        /// <inheritdoc /> 
        internal abstract IntPtr GetWindowTitlePrivate(IntPtr window);

        /// <inheritdoc /> 
        internal abstract bool GetWindowWMInfoInternal(IntPtr window, ref SysWMInfo info);

        /// <inheritdoc /> 
        internal abstract void HideWindow(IntPtr window);

        /// <inheritdoc /> 
        internal abstract void MaximizeWindow(IntPtr window);

        /// <inheritdoc /> 
        internal abstract void MinimizeWindow(IntPtr window);

        /// <inheritdoc /> 
        internal abstract void RaiseWindow(IntPtr window);

        /// <inheritdoc /> 
        internal abstract void RestoreWindow(IntPtr window);

        /// <inheritdoc /> 
        internal abstract void SetWindowBordered(IntPtr window, bool bordered);

        /// <inheritdoc /> 
        internal abstract int SetWindowFullscreen(IntPtr window, uint flags);

        /// <inheritdoc /> 
        internal abstract void SetWindowGrab(IntPtr window, bool grabbed);

        /// <inheritdoc /> 
        internal abstract void SetWindowIcon(IntPtr window, IntPtr icon);

        /// <inheritdoc /> 
        internal abstract void SetWindowPosition(IntPtr window, int x, int y);

        /// <inheritdoc /> 
        internal abstract void SetWindowSize(IntPtr window, int x, int y);

        /// <inheritdoc /> 
        internal abstract void SetWindowTitle(IntPtr window, string title);

        /// <inheritdoc /> 
        internal abstract void ShowWindow(IntPtr window);


    }
}