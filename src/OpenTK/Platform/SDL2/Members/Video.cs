using System;
using AdvancedDLSupport;
using OpenTK.Platform.SDL2.Interfaces;

namespace OpenTK.Platform.SDL2
{
    public abstract partial class SDL : NativeLibraryBase, ISDL2
    {
        /// <inheritdoc /> 
        public abstract IntPtr CreateWindow(string title, int x, int y, int w, int h, WindowFlags flags);

        /// <inheritdoc />             
        public abstract IntPtr CreateWindowFrom(IntPtr data);

        /// <inheritdoc />     
        public abstract void DestroyWindow(IntPtr window);

        /// <inheritdoc /> 
        public abstract void DisableScreenSaver();

        /// <inheritdoc /> 
        public abstract int GetCurrentDisplayMode(int displayIndex, out DisplayMode mode);

        /// <inheritdoc /> 
        public abstract int GetDisplayBounds(int displayIndex, out Rect rect);

        /// <inheritdoc /> 
        public abstract int GetDisplayMode(int displayIndex, int modeIndex, out DisplayMode mode);

        /// <inheritdoc /> 
        public abstract int GetNumDisplayModes(int displayIndex);

        /// <inheritdoc /> 
        public abstract int GetNumVideoDisplays();

        /// <inheritdoc /> 
        public abstract uint GetWindowID(IntPtr window);

        /// <inheritdoc /> 
        public abstract void GetWindowPosition(IntPtr window, out int x, out int y);

        /// <inheritdoc /> 
        public abstract void GetWindowSize(IntPtr window, out int w, out int h);

        /// <inheritdoc /> 
        public abstract IntPtr GetWindowTitlePrivate(IntPtr window);

        /// <inheritdoc /> 
        public abstract bool GetWindowWMInfoInternal(IntPtr window, ref SysWMInfo info);

        /// <inheritdoc /> 
        public abstract void HideWindow(IntPtr window);

        /// <inheritdoc /> 
        public abstract void MaximizeWindow(IntPtr window);

        /// <inheritdoc /> 
        public abstract void MinimizeWindow(IntPtr window);

        /// <inheritdoc /> 
        public abstract void RaiseWindow(IntPtr window);

        /// <inheritdoc /> 
        public abstract void RestoreWindow(IntPtr window);

        /// <inheritdoc /> 
        public abstract void SetWindowBordered(IntPtr window, bool bordered);

        /// <inheritdoc /> 
        public abstract int SetWindowFullscreen(IntPtr window, uint flags);

        /// <inheritdoc /> 
        public abstract void SetWindowGrab(IntPtr window, bool grabbed);

        /// <inheritdoc /> 
        public abstract void SetWindowIcon(IntPtr window, IntPtr icon);

        /// <inheritdoc /> 
        public abstract void SetWindowPosition(IntPtr window, int x, int y);

        /// <inheritdoc /> 
        public abstract void SetWindowSize(IntPtr window, int x, int y);

        /// <inheritdoc /> 
        public abstract void SetWindowTitle(IntPtr window, string title);

        /// <inheritdoc /> 
        public abstract void ShowWindow(IntPtr window);

    }
}
