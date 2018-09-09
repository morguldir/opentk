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
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using AdvancedDLSupport;
using OpenTK.Loader;
using OpenTK.Platform.SDL2.Interfaces;

#pragma warning disable 0169

namespace OpenTK.Platform.SDL2
{
    using Surface = IntPtr;
    using Cursor = IntPtr;

    public abstract partial class SDL : NativeLibraryBase, ISDL2
    {
        /// <inheritdoc cref="NativeLibraryBase"/> 
        protected SDL(string path, ImplementationOptions options) : base(path, options)
        { }

        /// <inheritdoc/>
        public abstract void Free(IntPtr memblock);

        public readonly static object Sync = new object();
        private Nullable<Version> version;
        public Version Version
        {
            get
            {
                try
                {
                    if (!version.HasValue)
                    {
                        version = GetVersion();
                    }
                    return version.Value;
                }
                catch
                {
                    // nom nom
                    Debug.Print("[SDL2] Failed to retrieve version");
                    return new Version();
                }
            }
        }

        private string IntPtrToString(IntPtr ptr)
        {
            return Marshal.PtrToStringAnsi(ptr);
            //int strlen = 0;
            //while (Marshal.ReadByte(ptr) != 0)
            //    strlen++;
        }

        /// <summary>
        /// Return the name for an openend game controller instance.
        /// </summary>
        /// <returns>The name of the game controller name.</returns>
        /// <param name="gamecontroller">Pointer to a game controller instance returned by <c>GameControllerOpen</c>.</param>
        public string GameControllerName(IntPtr gamecontroller)
        {
            unsafe
            {
                return new string((sbyte * ) GameControllerNameInternal(gamecontroller));
            }
        }

        public string GetError()
        {
            return IntPtrToString(GetErrorInternal());
        }

        public Version GetVersion()
        {
            Version v;
            GetVersion(out v);
            return v;
        }

        public string GetWindowTitle(IntPtr window)
        {
            return Marshal.PtrToStringAnsi(GetWindowTitlePrivate(window));
        }

        public string JoystickName(IntPtr joystick)
        {
            unsafe
            {
                return new string((sbyte * ) JoystickNameInternal(joystick));
            }
        }

        public int PeepEvents(ref Event e, EventAction action, EventType min, EventType max)
        {
            unsafe
            {
                fixed(Event * pe = & e)
                {
                    return PeepEvents(pe, 1, action, min, max);
                }
            }
        }

        public int PeepEvents(Event[] e, int count, EventAction action, EventType min, EventType max)
        {
            if (e == null)
            {
                throw new ArgumentNullException();
            }
            if (count <= 0 || count > e.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            unsafe
            {
                fixed(Event * pe = e)
                {
                    return PeepEvents(pe, count, action, min, max);
                }
            }
        }

        /// <summary>
        /// Retrieves driver-dependent window information.
        /// </summary>
        /// <param name="window">
        /// The window about which information is being requested.
        /// </param>
        /// <param name="info">
        /// Returns driver-dependent information about the specified window.
        /// </param>
        /// <returns>
        /// True, if the function is implemented and the version number of the info struct is valid;
        /// false, otherwise.
        /// </returns>
        public bool GetWindowWMInfo(IntPtr window, out SysWMInfo info)
        {
            info = new SysWMInfo();
            info.Version = GetVersion();
            return GetWindowWMInfoInternal(window, ref info);
        }

        public abstract partial class GL : NativeLibraryBase, IGLVideo
        {
            public IntPtr GetProcAddress(string proc)
            {
                IntPtr p = Marshal.StringToHGlobalAnsi(proc);
                try
                {
                    return GetProcAddress(p);
                }
                finally
                {
                    Marshal.FreeHGlobal(p);
                }
            }

            public int SetAttribute(Attribute attr, ContextFlags value)
            {
                return SetAttribute(attr, (int) value);
            }
            public int SetAttribute(Attribute attr, ContextProfileFlags value)
            {
                return SetAttribute(attr, (int) value);
            }
            public static GL GetAPI()
            {
                return APILoader.Load<GL, SDL2LibraryNameController>();
            }
        }

        public static SDL GetAPI()
        {
            return APILoader.Load<SDL, SDL2LibraryNameController>();
        }
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int EventFilter(IntPtr userdata, IntPtr @event);
}
