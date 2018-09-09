using System;
using AdvancedDLSupport;

namespace OpenTK.Platform.SDL2.Interfaces
{
    [NativeSymbols(Prefix = "SDL_")]
    internal interface IPixels
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="bpp"></param>
        /// <param name="rmask"></param>
        /// <param name="gmask"></param>
        /// <param name="bmask"></param>
        /// <param name="amask"></param>
        /// <returns></returns>
        bool PixelFormatEnumToMasks(uint format, out int bpp, out uint rmask, out uint gmask, out uint bmask, out uint amask);

    }
}
