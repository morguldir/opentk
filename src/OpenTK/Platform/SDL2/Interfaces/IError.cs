using System;
using AdvancedDLSupport;

namespace OpenTK.Platform.SDL2.Interfaces
{
    [NativeSymbols(Prefix = "SDL_")]
    internal interface IError
    {
        [NativeSymbol("GetError")]
        IntPtr GetErrorInternal();
    }
}