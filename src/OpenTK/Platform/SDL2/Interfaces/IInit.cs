using System;
using AdvancedDLSupport;

namespace OpenTK.Platform.SDL2.Interfaces
{
    [NativeSymbols(Prefix = "SDL_")]
    internal interface IInit
    {
        /// <summary>
        /// Use this function to initialize the SDL library. This must be called before using most other SDL functions. 
        /// </summary>
        /// <param name="flags">subsystem initialization flags; see <see cref="SystemFlags"/></param>
        /// <returns>Returns 0 on success or a negative error code on failure; 
        /// call <see cref="GetError()"/>for more information. </returns>
        int Init(SystemFlags flags);

        /// <summary>
        /// Use this function to initialize specific SDL subsystems. 
        /// </summary>
        /// <param name="flags">any of the flags used by SDL_Init(); see <see cref="SystemFlags"/></param>
        /// <returns>Returns 0 on success or a negative error code on failure; 
        /// call <see cref="ISDL2.GetError()"/> for more information. </returns>
        int InitSubSystem(SystemFlags flags);

        /// <summary>
        /// Use this function to get a mask of the specified subsystems which have previously been initialized. 
        /// </summary>
        /// <param name="flags">any of the flags used by SDL_Init(); see <see cref="SystemFlags"/></param>
        /// <returns>If flags is 0 it returns a mask of all initialized subsystems, 
        /// otherwise it returns the initialization status of the specified subsystems.</returns>
        bool WasInit(SystemFlags flags);

    }
}
