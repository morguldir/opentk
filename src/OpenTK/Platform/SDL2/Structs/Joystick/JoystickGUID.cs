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
    public struct JoystickGUID
    {
        private long data0;
        private long data1;

        public Guid ToGuid()
        {
            byte[] data = new byte[16];

            unsafe
            {
                fixed(JoystickGUID* pdata = &this)
                {
                    Marshal.Copy(new IntPtr(pdata), data, 0, data.Length);
                }
            }

            // The Guid(byte[]) constructor swaps the first 4+2+2 bytes.
            // Compensate for that, otherwise we will not be able to match
            // the Guids in the configuration database.
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(data, 0, 4);
                Array.Reverse(data, 4, 2);
                Array.Reverse(data, 6, 2);
            }

            return new Guid(data);
        }
    }
}
