using System;
using AdvancedDLSupport;

namespace OpenTK.Platform.SDL2.Interfaces
{
    [NativeSymbols(Prefix = "SDL_")]
    internal interface ISDL2: IMouse, ISurface, IEvents, IVideo, IJoystick, IInit
    {
        void free(IntPtr memblock);
  

 
        void GetVersion(out Version version);


    }
}
