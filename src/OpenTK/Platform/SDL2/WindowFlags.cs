//
// The Open Toolkit Library License
//
// Copyright (c) 2006 - 2013 Stefanos Apostolopoulos for the Open Toolkit library.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do
// so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
//

using System;

#pragma warning disable 0169

namespace OpenTK.Platform.SDL2
{
    public enum WindowFlags
    {
        Default = 0,
        FULLSCREEN = 0x00000001,
        OPENGL = 0x00000002,
        SHOWN = 0x00000004,
        HIDDEN = 0x00000008,
        BORDERLESS = 0x00000010,
        RESIZABLE = 0x00000020,
        MINIMIZED = 0x00000040,
        MAXIMIZED = 0x00000080,
        INPUT_GRABBED = 0x00000100,
        INPUT_FOCUS = 0x00000200,
        MOUSE_FOCUS = 0x00000400,
        FULLSCREEN_DESKTOP = (FULLSCREEN | 0x00001000),
        FOREIGN = 0x00000800,
        ALLOW_HIGHDPI = 0x00002000,
    }
}

