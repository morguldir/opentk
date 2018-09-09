using System;

namespace OpenTK.Platform.SDL2
{
    public enum Button : byte
    {
        Left = 1,
        Middle,
        Right,
        X1,
        X2
    }

    [Flags]
    public enum ButtonFlags
    {
        Left = 1 << (Button.Left - 1),
        Middle = 1 << (Button.Middle - 1),
        Right = 1 << (Button.Right - 1),
        X1 = 1 << (Button.X1 - 1),
        X2 = 1 << (Button.X2 - 1),
    }
}
