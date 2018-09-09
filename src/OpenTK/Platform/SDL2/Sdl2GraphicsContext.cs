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
using OpenTK.Graphics;

namespace OpenTK.Platform.SDL2
{
    internal class Sdl2GraphicsContext : DesktopGraphicsContext
    {
        private static readonly SDL SDL = Sdl2DisplayDeviceDriver.SDL;

        public static readonly SDL.GL GL = SDL.GL.GetAPI();

        private IWindowInfo Window { get; set; }
        private ContextHandle SdlContext { get; set; }

        private Sdl2GraphicsContext(IWindowInfo window)
        {
            // It is possible to create a GraphicsContext on a window
            // that is not owned by SDL (e.g. a GLControl). In that case,
            // we need to use SDL_CreateWindowFrom in order to
            // convert the foreign window to a SDL window.
            if (window is Sdl2WindowInfo)
            {
                Window = window;
            }
            else
            {
                Window = new Sdl2WindowInfo(
                    SDL.CreateWindowFrom(window.Handle),
                    null);
            }
        }

        public Sdl2GraphicsContext(GraphicsMode mode,
            IWindowInfo win, IGraphicsContext shareContext,
            int major, int minor,
            OpenTK.Graphics.GraphicsContextFlags flags) : this(win)
        {
            lock(SDL.Sync)
            {
                bool retry = false;
                do
                {
                    SetGLAttributes(mode, shareContext, major, minor, flags);
                    SdlContext = new ContextHandle(GL.CreateContext(Window.Handle));

                    // If we failed to create a valid context, relax the GraphicsMode
                    // and try again.
                    retry =
                        SdlContext == ContextHandle.Zero &&
                        Utilities.RelaxGraphicsMode(ref mode);
                }
                while (retry);

                if (SdlContext == ContextHandle.Zero)
                {
                    var error = SDL.GetError();
                    Debug.Print("SDL2 failed to create OpenGL context: {0}", error);
                    throw new GraphicsContextException(error);
                }

                Mode = GetGLAttributes(SdlContext, out flags);
            }
            Handle = GraphicsContext.GetCurrentContext();
            Debug.Print("SDL2 created GraphicsContext (handle: {0})", Handle);
            Debug.Print("    GraphicsMode: {0}", Mode);
            Debug.Print("    GraphicsContextFlags: {0}", flags);
        }

        private static GraphicsMode GetGLAttributes(ContextHandle sdlContext, out GraphicsContextFlags context_flags)
        {
            context_flags = 0;
            int accum_red, accum_green, accum_blue, accum_alpha;
            GL.GetAttribute(Attribute.ACCUM_RED_SIZE, out accum_red);
            GL.GetAttribute(Attribute.ACCUM_GREEN_SIZE, out accum_green);
            GL.GetAttribute(Attribute.ACCUM_BLUE_SIZE, out accum_blue);
            GL.GetAttribute(Attribute.ACCUM_ALPHA_SIZE, out accum_alpha);

            int buffers;
            GL.GetAttribute(Attribute.DOUBLEBUFFER, out buffers);
            // DOUBLEBUFFER return a boolean (0-false, 1-true), so we need
            // to adjust the buffer count (false->1 buffer, true->2 buffers)
            buffers++;

            int red, green, blue, alpha;
            GL.GetAttribute(Attribute.RED_SIZE, out red);
            GL.GetAttribute(Attribute.GREEN_SIZE, out green);
            GL.GetAttribute(Attribute.BLUE_SIZE, out blue);
            GL.GetAttribute(Attribute.ALPHA_SIZE, out alpha);

            int depth, stencil;
            GL.GetAttribute(Attribute.DEPTH_SIZE, out depth);
            GL.GetAttribute(Attribute.STENCIL_SIZE, out stencil);

            int samples;
            GL.GetAttribute(Attribute.MULTISAMPLESAMPLES, out samples);

            int stereo;
            GL.GetAttribute(Attribute.STEREO, out stereo);

            int major, minor;
            GL.GetAttribute(Attribute.CONTEXT_MAJOR_VERSION, out major);
            GL.GetAttribute(Attribute.CONTEXT_MINOR_VERSION, out minor);

            int flags;
            GL.GetAttribute(Attribute.CONTEXT_FLAGS, out flags);

            int egl;
            GL.GetAttribute(Attribute.CONTEXT_EGL, out egl);

            int profile;
            GL.GetAttribute(Attribute.CONTEXT_PROFILE_MASK, out profile);

            if (egl != 0 && (profile & (int) ContextProfileFlags.ES) != 0)
            {
                context_flags |= GraphicsContextFlags.Embedded;
            }

            if ((flags & (int) ContextFlags.DEBUG) != 0)
            {
                context_flags |= GraphicsContextFlags.Debug;
            }

            if ((profile & (int) ContextProfileFlags.CORE) != 0)
            {
                context_flags |= GraphicsContextFlags.ForwardCompatible;
            }

            return new GraphicsMode(
                new ColorFormat(red, green, blue, alpha),
                depth,
                stencil,
                samples,
                new ColorFormat(accum_red, accum_green, accum_blue, accum_alpha),
                buffers,
                stereo != 0 ? true : false);
        }

        private static void ClearGLAttributes()
        {
            GL.SetAttribute(Attribute.ACCUM_ALPHA_SIZE, 0);
            GL.SetAttribute(Attribute.ACCUM_RED_SIZE, 0);
            GL.SetAttribute(Attribute.ACCUM_GREEN_SIZE, 0);
            GL.SetAttribute(Attribute.ACCUM_BLUE_SIZE, 0);
            GL.SetAttribute(Attribute.DOUBLEBUFFER, 0);
            GL.SetAttribute(Attribute.ALPHA_SIZE, 0);
            GL.SetAttribute(Attribute.RED_SIZE, 0);
            GL.SetAttribute(Attribute.GREEN_SIZE, 0);
            GL.SetAttribute(Attribute.BLUE_SIZE, 0);
            GL.SetAttribute(Attribute.DEPTH_SIZE, 0);
            GL.SetAttribute(Attribute.MULTISAMPLEBUFFERS, 0);
            GL.SetAttribute(Attribute.MULTISAMPLESAMPLES, 0);
            GL.SetAttribute(Attribute.STENCIL_SIZE, 0);
            GL.SetAttribute(Attribute.STEREO, 0);
            GL.SetAttribute(Attribute.CONTEXT_MAJOR_VERSION, 1);
            GL.SetAttribute(Attribute.CONTEXT_MINOR_VERSION, 0);
            GL.SetAttribute(Attribute.CONTEXT_FLAGS, 0);
            GL.SetAttribute(Attribute.CONTEXT_EGL, 0);
            GL.SetAttribute(Attribute.CONTEXT_PROFILE_MASK, 0);
            GL.SetAttribute(Attribute.SHARE_WITH_CURRENT_CONTEXT, 0);
        }

        private static void SetGLAttributes(GraphicsMode mode,
            IGraphicsContext shareContext,
            int major, int minor,
            GraphicsContextFlags flags)
        {
            ContextProfileFlags cpflags = 0;
            ClearGLAttributes();

            if (mode.AccumulatorFormat.BitsPerPixel > 0)
            {
                GL.SetAttribute(Attribute.ACCUM_ALPHA_SIZE, mode.AccumulatorFormat.Alpha);
                GL.SetAttribute(Attribute.ACCUM_RED_SIZE, mode.AccumulatorFormat.Red);
                GL.SetAttribute(Attribute.ACCUM_GREEN_SIZE, mode.AccumulatorFormat.Green);
                GL.SetAttribute(Attribute.ACCUM_BLUE_SIZE, mode.AccumulatorFormat.Blue);
            }

            if (mode.Buffers > 0)
            {
                GL.SetAttribute(Attribute.DOUBLEBUFFER, mode.Buffers > 1 ? 1 : 0);
            }

            if (mode.ColorFormat > 0)
            {
                GL.SetAttribute(Attribute.ALPHA_SIZE, mode.ColorFormat.Alpha);
                GL.SetAttribute(Attribute.RED_SIZE, mode.ColorFormat.Red);
                GL.SetAttribute(Attribute.GREEN_SIZE, mode.ColorFormat.Green);
                GL.SetAttribute(Attribute.BLUE_SIZE, mode.ColorFormat.Blue);
            }

            if (mode.Depth > 0)
            {
                GL.SetAttribute(Attribute.DEPTH_SIZE, mode.Depth);
            }

            if (mode.Samples > 0)
            {
                GL.SetAttribute(Attribute.MULTISAMPLEBUFFERS, 1);
                GL.SetAttribute(Attribute.MULTISAMPLESAMPLES, mode.Samples);
            }

            if (mode.Stencil > 0)
            {
                GL.SetAttribute(Attribute.STENCIL_SIZE, 1);
            }

            if (mode.Stereo)
            {
                GL.SetAttribute(Attribute.STEREO, 1);
            }

            if (major > 0)
            {
                // Workaround for https://github.com/opentk/opentk/issues/44
                // Mac OS X desktop OpenGL 3.x/4.x contexts require require
                // ContextProfileFlags.Core, otherwise they will fail to construct.
                if (Configuration.RunningOnMacOS && major >= 3 &&
                    (flags & GraphicsContextFlags.Embedded) == 0)
                {
                    cpflags |= ContextProfileFlags.CORE;

                    // According to https://developer.apple.com/graphicsimaging/opengl/capabilities/GLInfo_1075_Core.html
                    // Mac OS X supports 3.2+. Indeed, requesting 3.0 or 3.1 results in failure.
                    if (major == 3 && minor < 2)
                    {
                        minor = 2;
                    }
                }

                GL.SetAttribute(Attribute.CONTEXT_MAJOR_VERSION, major);
                GL.SetAttribute(Attribute.CONTEXT_MINOR_VERSION, minor);
            }

            if ((flags & GraphicsContextFlags.Debug) != 0)
            {
                GL.SetAttribute(Attribute.CONTEXT_FLAGS, ContextFlags.DEBUG);
            }

            /*
            if ((flags & GraphicsContextFlags.Robust) != 0)
            {
                GL.SetAttribute(ContextAttribute.CONTEXT_FLAGS, ContextFlags.ROBUST_ACCESS_FLAG);
            }

            if ((flags & GraphicsContextFlags.ResetIsolation) != 0)
            {
                GL.SetAttribute(ContextAttribute.CONTEXT_FLAGS, ContextFlags.RESET_ISOLATION_FLAG);
            }
            */

            {
                if ((flags & GraphicsContextFlags.Embedded) != 0)
                {
                    cpflags |= ContextProfileFlags.ES;
                    GL.SetAttribute(Attribute.CONTEXT_EGL, 1);
                }

                if ((flags & GraphicsContextFlags.ForwardCompatible) != 0)
                {
                    cpflags |= ContextProfileFlags.CORE;
                }

                if (cpflags != 0)
                {
                    GL.SetAttribute(Attribute.CONTEXT_PROFILE_MASK, cpflags);
                }
            }

            if (shareContext != null)
            {
                if (shareContext.IsCurrent)
                {
                    GL.SetAttribute(Attribute.SHARE_WITH_CURRENT_CONTEXT, 1);
                }
                else
                {
                    Trace.WriteLine("Warning: SDL2 requires a shared context to be current before sharing. Sharing failed.");
                }
            }
        }

        public static ContextHandle GetCurrentContext()
        {
            return new ContextHandle(GL.GetCurrentContext());
        }

        public override void SwapBuffers()
        {
            GL.SwapWindow(Window.Handle);
        }

        public override void MakeCurrent(IWindowInfo window)
        {
            int result = 0;
            if (window != null)
            {
                result = GL.MakeCurrent(window.Handle, SdlContext.Handle);
            }
            else
            {
                result = GL.MakeCurrent(IntPtr.Zero, IntPtr.Zero);
            }

            if (result < 0)
            {
                Debug.Print("SDL2 MakeCurrent failed with: {0}", SDL.GetError());
            }
        }

        public override IntPtr GetAddress(IntPtr function)
        {
            return GL.GetProcAddress(function);
        }

        public override bool IsCurrent
        {
            get
            {
                return GraphicsContext.GetCurrentContext() == Context;
            }
        }

        public override int SwapInterval
        {
            get
            {
                return GL.GetSwapInterval();
            }
            set
            {
                if (GL.SetSwapInterval(value) < 0)
                {
                    Debug.Print("SDL2 failed to set swap interval: {0}", SDL.GetError());
                }
            }
        }

        protected override void Dispose(bool manual)
        {
            if (!IsDisposed)
            {
                if (manual)
                {
                    Debug.Print("Disposing {0} (handle: {1})", GetType(), Handle);
                    lock(SDL.Sync)
                    {
                        GL.DeleteContext(SdlContext.Handle);
                    }
                }
                else
                {
                    Debug.Print("Sdl2GraphicsContext (handle: {0}) leaked, did you forget to call Dispose()?",
                        Handle);
                }
                IsDisposed = true;
            }
        }
    }
}
