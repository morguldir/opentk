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
using System.Runtime.InteropServices;

#pragma warning disable 0169

namespace OpenTK.Platform.SDL2
{
    public struct SysWMInfo
    {
        public Version Version;
        public SysWMType Subsystem;
        public SysInfo Info;

        [StructLayout(LayoutKind.Explicit)]
        public struct SysInfo
        {
            [FieldOffset(0)]
            public WindowsInfo Windows;
            [FieldOffset(0)]
            public X11Info X11;
            [FieldOffset(0)]
            public WaylandInfo Wayland;
            [FieldOffset(0)]
            public DirectFBInfo DirectFB;
            [FieldOffset(0)]
            public CocoaInfo Cocoa;
            [FieldOffset(0)]
            public UIKitInfo UIKit;

            public struct WindowsInfo
            {
                public IntPtr Window;
            }

            public struct X11Info
            {
                public IntPtr Display;
                public IntPtr Window;
            }

            public struct WaylandInfo
            {
                public IntPtr Display;
                public IntPtr Surface;
                public IntPtr ShellSurface;
            }

            public struct DirectFBInfo
            {
                public IntPtr Dfb;
                public IntPtr Window;
                public IntPtr Surface;
            }

            public struct CocoaInfo
            {
                public IntPtr Window;
            }

            public struct UIKitInfo
            {
                public IntPtr Window;
            }
        }
    }
}
