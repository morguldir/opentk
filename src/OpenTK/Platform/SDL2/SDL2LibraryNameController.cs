using OpenTK.Loader;

namespace OpenTK.Platform.SDL2
{
    /// <summary>
    /// Contains the library name of OpenAL.
    /// </summary>
    internal class SDL2LibraryNameController : PlatformLibraryNameContainerBase
    {
        /// <inheritdoc />
        public override string Linux => "libSDL2-2.0.so.0";
        /// <inheritdoc />
        public override string MacOS => "libSDL2.dylib";
        /// <inheritdoc />
        public override string Android => Linux;
        /// <inheritdoc />
        public override string IOS => MacOS;
        /// <inheritdoc />
        public override string Windows => "SDL2.dll";
    }
}