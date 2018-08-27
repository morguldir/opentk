using System;
using AdvancedDLSupport;

namespace OpenTK.Platform.SDL2.Interfaces
{
    [NativeSymbols(Prefix = "SDL_")]
    internal interface ISDL2: ISDL2Mouse, ISDL2Surface, ISDL2Events, ISDL2Video, ISDL2Joystick, ISDL2Init, ISDL2GLVideo
    {
        void free(IntPtr memblock);
  
        [NativeSymbol("GetError")]
        IntPtr GetErrorInternal();
 
        void GetVersion(out Version version);

        bool PixelFormatEnumToMasks(uint format, out int bpp, out uint rmask, out uint gmask, out uint bmask, out uint amask);

    }
}
