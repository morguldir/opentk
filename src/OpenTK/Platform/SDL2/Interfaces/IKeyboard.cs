using System;
using AdvancedDLSupport;

namespace OpenTK.Platform.SDL2.Interfaces
{
    [NativeSymbols(Prefix = "SDL_")]
    internal interface IKeyboard
    {
        /// <summary>
        /// Use this function to get the current key modifier state for the keyboard. 
        /// </summary>
        /// <returns>Returns an OR'd combination of the modifier keys for the keyboard. See <see cref="Keymod"/> for details.</returns>
        Keymod GetModState();

        /// <summary>
        /// Use this function to get the scancode corresponding to the given key code according to the current keyboard layout. 
        /// </summary>
        /// <param name="key">the desired <see cref="Keycode"/> to query</param>
        /// <returns>Returns the <see cref="Scancode"/> that corresponds to the given <see cref="Keycode"/>. </returns>
        Scancode GetScancodeFromKey(Keycode key);


    }
}