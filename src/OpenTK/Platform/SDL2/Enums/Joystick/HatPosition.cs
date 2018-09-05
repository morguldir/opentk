using System;

namespace OpenTK.Platform.SDL2
{
    /// <summary>
    /// The position of a POV hat
    /// </summary>
    [Flags]
    public enum HatPosition : byte
    {
        Centered = 0x00,
        Up = 0x01,
        Right = 0x02,
        Down = 0x04,
        Left = 0x08,
        RightUp = Right | Up,
        RightDown = Right | Down,
        LeftUp = Left | Up,
        LeftDown = Left | Down
    }
}