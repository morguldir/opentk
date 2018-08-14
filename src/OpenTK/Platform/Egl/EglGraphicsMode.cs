//
// The Open Toolkit Library License
//
// Copyright (c) 2006 - 2009 the Open Toolkit library.
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
using OpenTK.Graphics;

namespace OpenTK.Platform.Egl
{
    internal class EglGraphicsMode
    {
        IEgl Egl = EglWrapper.CreateLibraryInterface();

        public GraphicsMode SelectGraphicsMode(EglWindowInfo window,
            GraphicsMode mode, RenderableFlags flags)
        {
            return SelectGraphicsMode(window,
                mode.ColorFormat, mode.Depth, mode.Stencil,
                mode.Samples, mode.AccumulatorFormat, mode.Buffers, mode.Stereo,
                flags);
        }

        public GraphicsMode SelectGraphicsMode(EglWindowInfo window,
            ColorFormat color, int depth, int stencil,
            int samples, ColorFormat accum, int buffers, bool stereo,
            RenderableFlags renderableFlags)
        {
            return SelectGraphicsMode(
                SurfaceType.WINDOW_BIT,
                window.Display,
                color, depth, stencil, samples, accum, buffers, stereo, renderableFlags);
        }

        public GraphicsMode SelectGraphicsMode(SurfaceType surfaceType,
            IntPtr display, ColorFormat color, int depth, int stencil,
            int samples, ColorFormat accum, int buffers, bool stereo,
            RenderableFlags renderableFlags)
        {
            IntPtr[] configs = new IntPtr[1];
            int[] attribList = new int[]
            {
                EglValues.SURFACE_TYPE, (int)surfaceType,
                EglValues.RENDERABLE_TYPE, (int)renderableFlags,

                EglValues.RED_SIZE, color.Red,
                EglValues.GREEN_SIZE, color.Green,
                EglValues.BLUE_SIZE, color.Blue,
                EglValues.ALPHA_SIZE, color.Alpha,

                EglValues.DEPTH_SIZE, depth > 0 ? depth : 0,
                EglValues.STENCIL_SIZE, stencil > 0 ? stencil : 0,

                EglValues.SAMPLE_BUFFERS, samples > 0 ? 1 : 0,
                EglValues.SAMPLES, samples > 0 ? samples : 0,

                EglValues.NONE,
            };

            int numConfigs;
            if (!Egl.eglChooseConfig(display, attribList, configs, configs.Length, out numConfigs) || numConfigs == 0)
            {
                throw new GraphicsModeException(String.Format("Failed to retrieve GraphicsMode, error {0}", Egl.eglGetError()));
            }

            // See what we really got
            IntPtr activeConfig = configs[0];
            int r, g, b, a;
            Egl.eglGetConfigAttrib(display, activeConfig, EglValues.RED_SIZE, out r);
            Egl.eglGetConfigAttrib(display, activeConfig, EglValues.GREEN_SIZE, out g);
            Egl.eglGetConfigAttrib(display, activeConfig, EglValues.BLUE_SIZE, out b);
            Egl.eglGetConfigAttrib(display, activeConfig, EglValues.ALPHA_SIZE, out a);
            int d, s;
            Egl.eglGetConfigAttrib(display, activeConfig, EglValues.DEPTH_SIZE, out d);
            Egl.eglGetConfigAttrib(display, activeConfig, EglValues.STENCIL_SIZE, out s);
            int sampleBuffers;
            Egl.eglGetConfigAttrib(display, activeConfig, EglValues.SAMPLES, out sampleBuffers);
            Egl.eglGetConfigAttrib(display, activeConfig, EglValues.SAMPLES, out samples);

            return new GraphicsMode(activeConfig, new ColorFormat(r, g, b, a), d, s, sampleBuffers > 0 ? samples : 0, 0, 2, false);
        }
    }
}
