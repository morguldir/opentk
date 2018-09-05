using System;

namespace OpenTK.Platform.SDL2
{
    [Flags]
    public enum ContextFlags
    {
        DEBUG = 0x0001,
        FORWARD_COMPATIBLE = 0x0002,
        ROBUST_ACCESS = 0x0004,
        RESET_ISOLATION = 0x0008
    }
}