using System;
using AdvancedDLSupport;

namespace OpenTK.Platform.SDL2.Interfaces
{
    [NativeSymbols(Prefix = "SDL_")]
    internal interface IError
    {
        /// <summary>
        /// Use this function to retrieve a message about the last error that occurred. 
        /// </summary>
        /// <returns>Returns a message with information about the specific error that occurred, 
        /// or <c>IntPtr.Zero</c> if there hasn't been an error message set since the last call to <c>ClearError</c>.
        ///  The message is only applicable when an SDL function has signaled an error. 
        /// You must check the return values of SDL function calls to determine when to appropriately call <c>GetError</c>. </returns>
        /// <remarks>It is possible for multiple errors to occur before calling SDL_GetError(). Only the last error is returned.
        /// The returned string is statically allocated and must not be freed by the application. </remarks>
        [NativeSymbol("GetError")]
        IntPtr GetErrorInternal();

        /// <summary>
        /// Use this function to clear any previous error message. 
        /// </summary>
        void ClearError();
    }
}
