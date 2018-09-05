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
    [StructLayout(LayoutKind.Explicit)]
    public struct Event
    {
        [FieldOffset(0)]
        public EventType Type;
        [FieldOffset(0)]
        public WindowEvent Window;
        [FieldOffset(0)]
        public KeyboardEvent Key;
        [FieldOffset(0)]
        public TextEditingEvent Edit;
        [FieldOffset(0)]
        public TextInputEvent Text;
        [FieldOffset(0)]
        public MouseMotionEvent Motion;
        [FieldOffset(0)]
        public MouseButtonEvent Button;
        [FieldOffset(0)]
        public MouseWheelEvent Wheel;
        [FieldOffset(0)]
        public JoyAxisEvent JoyAxis;
        [FieldOffset(0)]
        public JoyBallEvent JoyBall;
        [FieldOffset(0)]
        public JoyHatEvent JoyHat;
        [FieldOffset(0)]
        public JoyButtonEvent JoyButton;
        [FieldOffset(0)]
        public JoyDeviceEvent JoyDevice;
        [FieldOffset(0)]
        public ControllerAxisEvent ControllerAxis;
        [FieldOffset(0)]
        public ControllerButtonEvent ControllerButton;
        [FieldOffset(0)]
        public ControllerDeviceEvent ControllerDevice;
        [FieldOffset(0)]
        public DropEvent Drop;
#if false
        [FieldOffset(0)]
        public QuitEvent quit;
        [FieldOffset(0)]
        public UserEvent user;
        [FieldOffset(0)]
        public SysWMEvent syswm;
        [FieldOffset(0)]
        public TouchFingerEvent tfinger;
        [FieldOffset(0)]
        public MultiGestureEvent mgesture;
        [FieldOffset(0)]
        public DollarGestureEvent dgesture;
#endif

        // Ensure the structure is big enough
        // This hack is necessary to ensure compatibility
        // with different SDL versions, which might have
        // different sizeof(SDL_Event).
        [FieldOffset(0)]
        private unsafe fixed byte reserved[128];
    }
}

