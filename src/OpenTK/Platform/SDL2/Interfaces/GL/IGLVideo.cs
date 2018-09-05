using System;
using AdvancedDLSupport;

namespace OpenTK.Platform.SDL2.Interfaces
{
    internal partial interface IGLVideo
    {
        /// <summary>
        /// Use this function to create an OpenGL context for use with an OpenGL window, and make it current. 
        /// </summary>
        /// <param name="window">the window to associate with the context.</param>
        /// <returns>Returns the OpenGL context associated with window or <see cref="IntPtr.Zero"/> on error; call <see
        /// cref="ISDL2.GetError()"/> for more details. </returns>
        [NativeSymbol("GL_CreateContext")]
        IntPtr CreateContext(IntPtr window);

        /// <summary>
        /// Use this function to delete an OpenGL context. 
        /// </summary>
        /// <param name="context">the OpenGL context to be deleted.</param>
        [NativeSymbol("GL_DeleteContext")]
        void DeleteContext(IntPtr context);

        /// <summary>
        /// Use this function to get the actual value for an attribute from the current context.
        /// </summary>
        /// <param name="attr">the <see cref="System.Attribute"/> structure to query.</param>
        /// <param name="value">a pointer filled in with the current value of attr.</param>
        /// <returns>Returns 0 on success or a negative error code on failure; 
        /// call <see cref="GetError()"/> for more information. </returns>
        [NativeSymbol("GL_GetAttribute")]
        int GetAttribute(System.Attribute attr, out int value);

        /// <summary>
        /// Use this function to get the currently active OpenGL context. 
        /// </summary>
        /// <returns>Returns the currently active OpenGL context or <see cref="IntPtr.Zero"/> on failure; 
        /// call <see cref="GetError()"/> for more information.</returns>
        [NativeSymbol("GL_GetCurrentContext")]
        IntPtr GetCurrentContext();

        /// <summary>
        /// Use this function to get the size of a window's underlying drawable in pixels (for use with glViewport). 
        /// </summary>
        /// <param name="window">the window from which the drawable size should be queried</param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        [NativeSymbol("GL_GetDrawableSize")]
        void GetDrawableSize(IntPtr window, out int w, out int h);

        /// <summary>
        /// Use this function to get an OpenGL function by name. 
        /// </summary>
        /// <param name="proc">the name of an OpenGL function</param>
        /// <returns>Returns a pointer to the named OpenGL function. The returned pointer should be cast to the appropriate function signature.</returns>
        [NativeSymbol("GL_GetProcAddress")]
        IntPtr GetProcAddress(IntPtr proc);

        /// <summary>
        /// Use this function to get the swap interval for the current OpenGL context. 
        /// </summary>
        /// <returns>Returns 0 if there is no vertical retrace synchronization, 1 if the buffer swap is synchronized with the vertical retrace, and -1 if late swaps happen immediately instead of waiting for the next retrace; 
        /// call <see cref="GetError()"/> for more information. </returns>
        [NativeSymbol("GL_GetSwapInterval")]
        int GetSwapInterval();

        /// <summary>
        /// Use this function to set up an OpenGL context for rendering into an OpenGL window. 
        /// </summary>
        /// <param name="window">the window to associate with the context</param>
        /// <param name="context">the OpenGL context to associate with the window</param>
        /// <returns>Returns 0 on success or a negative error code on failure; call <see cref="GetError()"/> for more information. </returns>
        [NativeSymbol("GL_MakeCurrent")]
        int MakeCurrent(IntPtr window, IntPtr context);

        /// <summary>
        /// Use this function to set an OpenGL window attribute before window creation. 
        /// </summary>
        /// <param name="attr">the OpenGL attribute to set; see <see cref="Attribute"/> for details</param>
        /// <param name="value">the desired value for the attribute</param>
        /// <returns></returns>
        [NativeSymbol("GL_SetAttribute")]
        int SetAttribute(System.Attribute attr, int value);

        /// <summary>
        /// Use this function to set the swap interval for the current OpenGL context. 
        /// </summary>
        /// <param name="interval">0 for immediate updates, 1 for updates synchronized with the vertical retrace, -1 for adaptive vsync; see Remarks</param>
        /// <returns>Returns 0 on success or -1 if setting the swap interval is not supported; call <see cref="GetError()"/> for more information. </returns>
        /// <remarks>Some systems allow specifying -1 for the interval, to enable adaptive vsync. 
        /// Adaptive vsync works the same as vsync, but if you've already missed the vertical retrace for a given frame, it swaps buffers immediately, which might be less
        ///  jarring for the user during occasional framerate drops. If application requests adaptive vsync and the system does not support it, this function will fail and return -1.
        ///  In such a case, you should probably retry the call with 1 for the interval. </remarks>

        /// <summary>
        /// Use this function to update a window with OpenGL rendering. 
        /// </summary>
        /// <param name="window">the window to change.</param>
        /// <remarks>This is used with double-buffered OpenGL contexts, which are the default.
        /// On Mac OS X make sure you bind 0 to the draw framebuffer before swapping the window, otherwise nothing will happen.</remarks>
        [NativeSymbol("GL_SwapWindow")]
        void SwapWindow(IntPtr window);
    }
}