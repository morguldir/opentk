using System;

namespace OpenTK.Platform.SDL2
{
    [Flags]
    public enum ContextProfileFlags
    {
        CORE = 0x0001,
        COMPATIBILITY = 0x0002,
        ES = 0x0004
    }
}