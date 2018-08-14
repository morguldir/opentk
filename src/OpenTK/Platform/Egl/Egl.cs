//
// The Open Toolkit Library License
//
// Copyright (c) 2006 - 2011 the Open Toolkit library.
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
using System.Runtime.CompilerServices;
using OpenTK.Graphics;
using AdvancedDLSupport;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

#pragma warning disable 1591 // Missing XML comments

[assembly: InternalsVisibleTo("DLSupportDynamicAssembly")]
namespace OpenTK.Platform.Egl
{
    using EGLNativeDisplayType = IntPtr;
    using EGLNativeWindowType = IntPtr;
    using EGLNativePixmapType = IntPtr;
    using EGLConfig = IntPtr;
    using EGLContext = IntPtr;
    using EGLDisplay = IntPtr;
    using EGLSurface = IntPtr;
    using EGLClientBuffer = IntPtr;

    internal enum RenderApi
    {
        ES = EglValues.OPENGL_ES_API,
        GL = EglValues.OPENGL_API,
        VG = EglValues.OPENVG_API
    }

    [Flags]
    internal enum RenderableFlags
    {
        ES = EglValues.OPENGL_ES_BIT,
        ES2 = EglValues.OPENGL_ES2_BIT,
        ES3 = EglValues.OPENGL_ES3_BIT,
        GL = EglValues.OPENGL_BIT,
        VG = EglValues.OPENVG_BIT,
    }

    public enum ErrorCode
    {
        SUCCESS = 12288,
        NOT_INITIALIZED = 12289,
        BAD_ACCESS = 12290,
        BAD_ALLOC = 12291,
        BAD_ATTRIBUTE = 12292,
        BAD_CONFIG = 12293,
        BAD_CONTEXT = 12294,
        BAD_CURRENT_SURFACE = 12295,
        BAD_DISPLAY = 12296,
        BAD_MATCH = 12297,
        BAD_NATIVE_PIXMAP = 12298,
        BAD_NATIVE_WINDOW = 12299,
        BAD_PARAMETER = 12300,
        BAD_SURFACE = 12301,
        CONTEXT_LOST = 12302,
    }

    internal enum SurfaceType
    {
        PBUFFER_BIT = 0x0001,
        PIXMAP_BIT = 0x0002,
        WINDOW_BIT = 0x0004,
        VG_COLORSPACE_LINEAR_BIT = 0x0020,
        VG_ALPHA_FORMAT_PRE_BIT = 0x0040,
        MULTISAMPLE_RESOLVE_BOX_BIT = 0x0200,
        SWAP_BEHAVIOR_PRESERVED_BIT = 0x0400,
    }

    internal interface IEgl : IDisposable
    {
        bool eglQuerySurfacePointerANGLE(EGLDisplay display, EGLSurface surface, int attribute, out IntPtr value);

        EGLDisplay eglGetPlatformDisplay(int platform, EGLNativeDisplayType displayId, int[] attribList);

        ErrorCode eglGetError();

        EGLDisplay eglGetDisplay(EGLNativeDisplayType display_id);

        bool eglInitialize(EGLDisplay dpy, out int major, out int minor);

        bool eglTerminate(EGLDisplay dpy);

        IntPtr eglQueryString(EGLDisplay dpy, int name);

        [return: MarshalAsAttribute(UnmanagedType.I1)]
        bool eglGetConfigs(EGLDisplay dpy, EGLConfig[] configs, int config_size, out int num_config);

        [return: MarshalAsAttribute(UnmanagedType.I1)]
        bool eglChooseConfig(EGLDisplay dpy, int[] attrib_list, [In, Out] EGLConfig[] configs, int config_size, out int num_config);

        [return: MarshalAsAttribute(UnmanagedType.I1)]
        bool eglGetConfigAttrib(EGLDisplay dpy, EGLConfig config, int attribute, out int value);

        EGLSurface eglCreateWindowSurface(EGLDisplay dpy, EGLConfig config, IntPtr win, IntPtr attrib_list);

        EGLSurface eglCreatePbufferSurface(EGLDisplay dpy, EGLConfig config, int[] attrib_list);

        EGLSurface eglCreatePixmapSurface(EGLDisplay dpy, EGLConfig config, EGLNativePixmapType pixmap, int[] attrib_list);

        [return: MarshalAsAttribute(UnmanagedType.I1)]
        bool eglDestroySurface(EGLDisplay dpy, EGLSurface surface);

        [return: MarshalAsAttribute(UnmanagedType.I1)]
        bool eglQuerySurface(EGLDisplay dpy, EGLSurface surface, int attribute, out int value);

        [return: MarshalAsAttribute(UnmanagedType.I1)]
        bool eglBindAPI(RenderApi api);

        int eglQueryAPI();

        [return: MarshalAsAttribute(UnmanagedType.I1)]
        bool eglWaitClient();

        [return: MarshalAsAttribute(UnmanagedType.I1)]
        bool eglReleaseThread();

        EGLSurface eglCreatePbufferFromClientBuffer(EGLDisplay dpy, int buftype, EGLClientBuffer buffer, EGLConfig config, int[] attrib_list);

        [return: MarshalAsAttribute(UnmanagedType.I1)]
        bool eglSurfaceAttrib(EGLDisplay dpy, EGLSurface surface, int attribute, int value);

        [return: MarshalAsAttribute(UnmanagedType.I1)]
        bool eglBindTexImage(EGLDisplay dpy, EGLSurface surface, int buffer);

        [return: MarshalAsAttribute(UnmanagedType.I1)]
        bool eglReleaseTexImage(EGLDisplay dpy, EGLSurface surface, int buffer);

        [return: MarshalAsAttribute(UnmanagedType.I1)]
        bool eglSwapInterval(EGLDisplay dpy, int interval);

        IntPtr eglCreateContext(EGLDisplay dpy, EGLConfig config, EGLContext share_context, int[] attrib_list);

        [return: MarshalAsAttribute(UnmanagedType.I1)]
        bool eglDestroyContext(EGLDisplay dpy, EGLContext ctx);

        [return: MarshalAsAttribute(UnmanagedType.I1)]
        bool eglMakeCurrent(EGLDisplay dpy, EGLSurface draw, EGLSurface read, EGLContext ctx);

        EGLContext eglGetCurrentContext();

        EGLSurface eglGetCurrentSurface(int readdraw);

        EGLDisplay eglGetCurrentDisplay();

        [return: MarshalAsAttribute(UnmanagedType.I1)]
        bool eglQueryContext(EGLDisplay dpy, EGLContext ctx, int attribute, out int value);

        [return: MarshalAsAttribute(UnmanagedType.I1)]
        bool eglWaitGL();

        [return: MarshalAsAttribute(UnmanagedType.I1)]
        bool eglWaitNative(int engine);

        [return: MarshalAsAttribute(UnmanagedType.I1)]
        bool eglSwapBuffers(EGLDisplay dpy, EGLSurface surface);

        [return: MarshalAsAttribute(UnmanagedType.I1)]
        bool eglCopyBuffers(EGLDisplay dpy, EGLSurface surface, EGLNativePixmapType target);

        IntPtr eglGetProcAddress(string funcname);

        IntPtr eglGetProcAddress(IntPtr funcname);

        EGLDisplay eglGetPlatformDisplayEXT(int platform, EGLNativeDisplayType native_display, int[] attrib_list); 

        EGLSurface eglCreatePlatformWindowSurfaceEXT(EGLDisplay dpy, EGLConfig config, EGLNativeWindowType native_window, int[] attrib_list);

        EGLSurface eglCreatePlatformPixmapSurfaceEXT(EGLDisplay dpy, EGLConfig config, EGLNativePixmapType native_pixmap, int[] attrib_list);
    }
    internal static partial class EglWrapper
    {
        private static string GetLibraryName()
        {
            #if NETSTANDARD
                if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    return "libEGL.dll";
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    return "libEGL.dylib";
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    return "libEGL.so.1";
                else
                    return "libEGL.dll";
            #else
                return "libEGL.dll";
            #endif
        }
        private static string LibraryName = GetLibraryName();
        public static IEgl CreateLibraryInterface() => new NativeLibraryBuilder(ImplementationOptions.UseLazyBinding).ActivateInterface<IEgl>(LibraryName);
        private static IEgl Egl = CreateLibraryInterface();
        // EGL_ANGLE_software_display
        public static readonly EGLNativeDisplayType SOFTWARE_DISPLAY_ANGLE = new EGLNativeDisplayType(-1);
        // EGL_ANGLE_direct3d_display
        public static readonly EGLNativeDisplayType D3D11_ELSE_D3D9_DISPLAY_ANGLE = new EGLNativeDisplayType(-2);
        public static readonly EGLNativeDisplayType D3D11_ONLY_DISPLAY_ANGLE = new EGLNativeDisplayType(-3);
        // EGL_ANGLE_device_d3d

        public static EGLContext CreateContext(EGLDisplay dpy, EGLConfig config, EGLContext share_context, int[] attrib_list)
        {
            IntPtr ptr = Egl.eglCreateContext(dpy, config, share_context, attrib_list);
            if (ptr == IntPtr.Zero)
            {
                throw new GraphicsContextException(String.Format("Failed to create EGL context, error: {0}.", Egl.eglGetError()));
            }
            return ptr;
        }

        // Returns true if Egl drivers exist on the system.
        public static bool IsSupported
        {
            get
            {
                try { Egl.eglGetCurrentContext(); }
                catch (Exception) { return false; }
                return true;
            }
        }
    }
}
