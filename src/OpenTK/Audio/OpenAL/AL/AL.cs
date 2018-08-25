/* AlFunctions.cs
 * C header: \OpenAL 1.1 SDK\include\Al.h
 * Spec: http://www.openal.org/openal_webstf/specs/OpenAL11Specification.pdf
 * Copyright (c) 2008 Christoph Brandtner and Stefanos Apostolopoulos
 * See license.txt for license details
 * http://www.OpenTK.net */

using System;
using System.Runtime.InteropServices;
using System.Security;
using AdvancedDLSupport;

/* Type Mapping
// 8-bit boolean
typedef char ALboolean;
 * bool
// character
typedef char ALchar;
 * byte
// signed 8-bit 2's complement integer
typedef char ALbyte;
 * byte

// unsigned 8-bit integer
typedef unsigned char ALubyte;
 * byte

// signed 16-bit 2's complement integer
typedef short ALshort;
 * short

// unsigned 16-bit integer
typedef unsigned short ALushort;
 * ushort

// unsigned 32-bit integer
typedef unsigned int ALuint;
 * uint

// signed 32-bit 2's complement integer
typedef int ALint;
 * int
// non-negative 32-bit binary integer size
typedef int ALsizei;
 * int
// enumerated 32-bit value
typedef int ALenum;
 * int

// 32-bit IEEE754 floating-point
typedef float ALfloat;
 * float

// 64-bit IEEE754 floating-point
typedef double ALdouble;
 * double

// void type (for opaque pointers only)
typedef void ALvoid;
 * void
*/

namespace OpenTK.Audio.OpenAL
{
    internal interface IAL
    {
        void alEnable(ALCapability capability); 
        // AL_API void AL_APIENTRY alEnable( ALenum capability );

        void alDisable(ALCapability capability); 
        // AL_API void AL_APIENTRY alDisable( ALenum capability );

        bool alIsEnabled(ALCapability capability); 
        // AL_API ALboolean AL_APIENTRY alIsEnabled( ALenum capability );

        IntPtr alGetString(ALGetString param); // accepts the enums AlError, AlContextString 
        // AL_API const ALchar* AL_APIENTRY alGetString( ALenum param );

        /* no functions return more than 1 result ..
        // AL_API void AL_APIENTRY alGetBooleanv( ALenum param, ALboolean* buffer );

        // AL_API void AL_APIENTRY alGetIntegerv( ALenum param, ALint* buffer );

        // AL_API void AL_APIENTRY alGetFloatv( ALenum param, ALfloat* buffer );

        // AL_API void AL_APIENTRY alGetDoublev( ALenum param, ALdouble* buffer );

        */

        /* disabled due to no token using it
        bool alGetBoolean( ALGetBoolean param ); 
        // AL_API ALboolean AL_APIENTRY alGetBoolean( ALenum param );

        */

        int alGetInteger(ALGetInteger param); 
        // AL_API ALint AL_APIENTRY alGetInteger( ALenum param );

        float alGetFloat(ALGetFloat param); 
        // AL_API ALfloat AL_APIENTRY alGetFloat( ALenum param );

        /* disabled due to no token using it
        double alGetDouble( ALGetDouble param ); 
        // AL_API ALdouble AL_APIENTRY alGetDouble( ALenum param );

        */

        ALError alGetError(); 
        // AL_API ALenum AL_APIENTRY alGetError( void );

        bool alIsExtensionPresent([In] string extname); 
        // AL_API ALboolean AL_APIENTRY alIsExtensionPresent( const ALchar* extname );

        IntPtr alGetProcAddress([In] string fname); 
        // AL_API void* AL_APIENTRY alGetProcAddress( const ALchar* fname );

        int alGetEnumValue([In] string ename); 
        // AL_API ALenum AL_APIENTRY alGetEnumValue( const ALchar* ename );

        /* Listener
         * Listener represents the location and orientation of the
         * 'user' in 3D-space.
         *
         * Properties include: -
         *
         * Gain         AL_GAIN         ALfloat
         * Position     AL_POSITION     ALfloat[3]
         * Velocity     AL_VELOCITY     ALfloat[3]
         * Orientation  AL_ORIENTATION  ALfloat[6] (Forward then Up vectors)
         */

        void alListenerf(ALListenerf param, float value); 
        // AL_API void AL_APIENTRY alListenerf( ALenum param, ALfloat value );

        void alListener3f(ALListener3f param, float value1, float value2, float value3); 
        // AL_API void AL_APIENTRY alListener3f( ALenum param, ALfloat value1, ALfloat value2, ALfloat value3 );

        unsafe void alListenerfv(ALListenerfv param, float* values); 
        // AL_API void AL_APIENTRY alListenerfv( ALenum param, const ALfloat* values );

        // Not used by any Enums

        // AL_API void AL_APIENTRY alListeneri( ALenum param, ALint value );

        // AL_API void AL_APIENTRY alListener3i( ALenum param, ALint value1, ALint value2, ALint value3 );

        // AL_API void AL_APIENTRY alListeneriv( ALenum param, const ALint* values );

        void alGetListenerf(ALListenerf param, [Out] out float value); 
        // AL_API void AL_APIENTRY alGetListenerf( ALenum param, ALfloat* value );

        void alGetListener3f(ALListener3f param, [Out] out float value1, [Out] out float value2, [Out] out float value3); 
        // AL_API void AL_APIENTRY alGetListener3f( ALenum param, ALfloat *value1, ALfloat *value2, ALfloat *value3 );

        /// <summary>This function retrieves a floating-point vector property of the listener. You must pin it manually.</summary>
        /// <param name="param">the name of the attribute to be retrieved: ALListener3f.Position, ALListener3f.Velocity, ALListenerfv.Orientation</param>
        /// <param name="values">A pointer to the floating-point vector value being retrieved.</param>
        unsafe void alGetListenerfv(ALListenerfv param, float* values); 
        // AL_API void AL_APIENTRY alGetListenerfv( ALenum param, ALfloat* values );

        // Not used by any Enum:

        // AL_API void AL_APIENTRY alGetListeneri( ALenum param, ALint* value );

        // AL_API void AL_APIENTRY alGetListener3i( ALenum param, ALint *value1, ALint *value2, ALint *value3 );

        // AL_API void AL_APIENTRY alGetListeneriv( ALenum param, ALint* values );

        /* Source
         * Sources represent individual sound objects in 3D-space.
         * Sources take the PCM buffer provided in the specified Buffer,
         * apply Source-specific modifications, and then
         * submit them to be mixed according to spatial arrangement etc.
         *
         * Properties include: -
         *
         * Position                          AL_POSITION             ALfloat[3]
         * Velocity                          AL_VELOCITY             ALfloat[3]
         * Direction                         AL_DIRECTION            ALfloat[3]
         * Head Relative Mode                AL_SOURCE_RELATIVE      ALint (AL_TRUE or AL_FALSE)
         * Looping                           AL_LOOPING              ALint (AL_TRUE or AL_FALSE)
         *
         * Reference Distance                AL_REFERENCE_DISTANCE   ALfloat
         * Max Distance                      AL_MAX_DISTANCE         ALfloat
         * RollOff Factor                    AL_ROLLOFF_FACTOR       ALfloat
         * Pitch                             AL_PITCH                ALfloat
         * Gain                              AL_GAIN                 ALfloat
         * Min Gain                          AL_MIN_GAIN             ALfloat
         * Max Gain                          AL_MAX_GAIN             ALfloat
         * Inner Angle                       AL_CONE_INNER_ANGLE     ALint or ALfloat
         * Outer Angle                       AL_CONE_OUTER_ANGLE     ALint or ALfloat
         * Cone Outer Gain                   AL_CONE_OUTER_GAIN      ALint or ALfloat
         *
         * MS Offset                         AL_MSEC_OFFSET          ALint or ALfloat
         * Byte Offset                       AL_BYTE_OFFSET          ALint or ALfloat
         * Sample Offset                     AL_SAMPLE_OFFSET        ALint or ALfloat
         * Attached Buffer                   AL_BUFFER               ALint
         *
         * State (Query only)                AL_SOURCE_STATE         ALint
         * Buffers Queued (Query only)       AL_BUFFERS_QUEUED       ALint
         * Buffers Processed (Query only)    AL_BUFFERS_PROCESSED    ALint
         */

        unsafe void alGenSources(int n, [Out] uint* sources); 
        // AL_API void AL_APIENTRY alGenSources( ALsizei n, ALuint* Sources );

        unsafe void alDeleteSources(int n, [In] uint* sources); // Delete Source objects 
        // AL_API void AL_APIENTRY alDeleteSources( ALsizei n, const ALuint* Sources );

        void alDeleteSources(int n, ref uint sources); 
        void alDeleteSources(int n, ref int sources); 
        /// <summary>This function tests if a source name is valid, returning True if valid and False if not.</summary>
        /// <param name="sid">A source name to be tested for validity</param>
        /// <returns>Success.</returns>
        bool alIsSource(uint sid); 
        // AL_API ALboolean AL_APIENTRY alIsSource( ALuint sid );

        /// <summary>This function sets a floating-point property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being set</param>
        /// <param name="param">The name of the attribute to set: ALSourcef.Pitch, Gain, MinGain, MaxGain, MaxDistance, RolloffFactor, ConeOuterGain, ConeInnerAngle, ConeOuterAngle, ReferenceDistance, EfxAirAbsorptionFactor, EfxRoomRolloffFactor, EfxConeOuterGainHighFrequency.</param>
        /// <param name="value">The value to set the attribute to.</param>
        void alSourcef(uint sid, ALSourcef param, float value); 
        // AL_API void AL_APIENTRY alSourcef( ALuint sid, ALenum param, ALfloat value );

        /// <summary>This function sets a source property requiring three floating-point values.</summary>
        /// <param name="sid">Source name whose attribute is being set.</param>
        /// <param name="param">The name of the attribute to set: ALSource3f.Position, Velocity, Direction.</param>
        /// <param name="value1">The three ALfloat values which the attribute will be set to.</param>
        /// <param name="value2">The three ALfloat values which the attribute will be set to.</param>
        /// <param name="value3">The three ALfloat values which the attribute will be set to.</param>
        void alSource3f(uint sid, ALSource3f param, float value1, float value2, float value3); 
        // AL_API void AL_APIENTRY alSource3f( ALuint sid, ALenum param, ALfloat value1, ALfloat value2, ALfloat value3 );

        /// <summary>This function sets an integer property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being set.</param>
        /// <param name="param">The name of the attribute to set: ALSourcei.SourceRelative, ConeInnerAngle, ConeOuterAngle, Looping, Buffer, SourceState.</param>
        /// <param name="value">The value to set the attribute to.</param>
        void alSourcei(uint sid, ALSourcei param, int value); 
        // AL_API void AL_APIENTRY alSourcei( ALuint sid, ALenum param, ALint value );

        void alSource3i(uint sid, ALSource3i param, int value1, int value2, int value3); 
        // AL_API void AL_APIENTRY alSource3i( ALuint sid, ALenum param, ALint value1, ALint value2, ALint value3 );

        // Not used by any Enum:

        // AL_API void AL_APIENTRY alSourcefv( ALuint sid, ALenum param, const ALfloat* values );

        // AL_API void AL_APIENTRY alSourceiv( ALuint sid, ALenum param, const ALint* values );

        /// <summary>This function retrieves a floating-point property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being retrieved.</param>
        /// <param name="param">The name of the attribute to set: ALSourcef.Pitch, Gain, MinGain, MaxGain, MaxDistance, RolloffFactor, ConeOuterGain, ConeInnerAngle, ConeOuterAngle, ReferenceDistance, EfxAirAbsorptionFactor, EfxRoomRolloffFactor, EfxConeOuterGainHighFrequency.</param>
        /// <param name="value">A pointer to the floating-point value being retrieved</param>
        void alGetSourcef(uint sid, ALSourcef param, [Out] out float value); 
        // AL_API void AL_APIENTRY alGetSourcef( ALuint sid, ALenum param, ALfloat* value );

        /// <summary>This function retrieves three floating-point values representing a property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being retrieved.</param>
        /// <param name="param">the name of the attribute being retrieved: ALSource3f.Position, Velocity, Direction.</param>
        /// <param name="value1">Pointer to the value to retrieve.</param>
        /// <param name="value2">Pointer to the value to retrieve.</param>
        /// <param name="value3">Pointer to the value to retrieve.</param>
        void alGetSource3f(uint sid, ALSource3f param, [Out] out float value1, [Out] out float value2, [Out] out float value3); 
        // AL_API void AL_APIENTRY alGetSource3f( ALuint sid, ALenum param, ALfloat* value1, ALfloat* value2, ALfloat* value3);

        /// <summary>This function retrieves an integer property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being retrieved.</param>
        /// <param name="param">The name of the attribute to retrieve: ALSourcei.SourceRelative, Buffer, SourceState, BuffersQueued, BuffersProcessed.</param>
        /// <param name="value">A pointer to the integer value being retrieved.</param>
        void alGetSourcei(uint sid, ALGetSourcei param, [Out] out int value); 
        // AL_API void AL_APIENTRY alGetSourcei( ALuint sid,  ALenum param, ALint* value );

        // Not used by any Enum:

        // AL_API void AL_APIENTRY alGetSource3i( ALuint sid, ALenum param, ALint* value1, ALint* value2, ALint* value3);

        // AL_API void AL_APIENTRY alGetSourcefv( ALuint sid, ALenum param, ALfloat* values );

        // AL_API void AL_APIENTRY alGetSourceiv( ALuint sid,  ALenum param, ALint* values );

        /// <summary>This function plays a set of sources. The playing sources will have their state changed to ALSourceState.Playing. When called on a source which is already playing, the source will restart at the beginning. When the attached buffer(s) are done playing, the source will progress to the ALSourceState.Stopped state.</summary>
        /// <param name="ns">The number of sources to be played.</param>
        /// <param name="sids">A pointer to an array of sources to be played.</param>
        unsafe void alSourcePlayv(int ns, [In] uint* sids); 
        // AL_API void AL_APIENTRY alSourcePlayv( ALsizei ns, const ALuint *sids );

        /// <summary>This function stops a set of sources. The stopped sources will have their state changed to ALSourceState.Stopped.</summary>
        /// <param name="ns">The number of sources to stop.</param>
        /// <param name="sids">A pointer to an array of sources to be stopped.</param>
        unsafe void alSourceStopv(int ns, [In] uint* sids); 
        // AL_API void AL_APIENTRY alSourceStopv( ALsizei ns, const ALuint *sids );

        /// <summary>This function stops a set of sources and sets all their states to ALSourceState.Initial.</summary>
        /// <param name="ns">The number of sources to be rewound.</param>
        /// <param name="sids">A pointer to an array of sources to be rewound.</param>
        unsafe void alSourceRewindv(int ns, [In] uint* sids); 
        // AL_API void AL_APIENTRY alSourceRewindv( ALsizei ns, const ALuint *sids );

        /// <summary>This function pauses a set of sources. The paused sources will have their state changed to ALSourceState.Paused.</summary>
        /// <param name="ns">The number of sources to be paused.</param>
        /// <param name="sids">A pointer to an array of sources to be paused.</param>
        unsafe void alSourcePausev(int ns, [In] uint* sids); 
        // AL_API void AL_APIENTRY alSourcePausev( ALsizei ns, const ALuint *sids );

        /// <summary>This function plays, replays or resumes a source. The playing source will have it's state changed to ALSourceState.Playing. When called on a source which is already playing, the source will restart at the beginning. When the attached buffer(s) are done playing, the source will progress to the ALSourceState.Stopped state.</summary>
        /// <param name="sid">The name of the source to be played.</param>
        void alSourcePlay(uint sid); 
        // AL_API void AL_APIENTRY alSourcePlay( ALuint sid );

        /// <summary>This function stops a source. The stopped source will have it's state changed to ALSourceState.Stopped.</summary>
        /// <param name="sid">The name of the source to be stopped.</param>
        void alSourceStop(uint sid); 
        // AL_API void AL_APIENTRY alSourceStop( ALuint sid );

        /// <summary>This function stops the source and sets its state to ALSourceState.Initial.</summary>
        /// <param name="sid">The name of the source to be rewound.</param>
        void alSourceRewind(uint sid); 
        // AL_API void AL_APIENTRY alSourceRewind( ALuint sid );

        /// <summary>This function pauses a source. The paused source will have its state changed to ALSourceState.Paused.</summary>
        /// <param name="sid">The name of the source to be paused.</param>
        void alSourcePause(uint sid); 
        // AL_API void AL_APIENTRY alSourcePause( ALuint sid );

        /// <summary>This function queues a set of buffers on a source. All buffers attached to a source will be played in sequence, and the number of processed buffers can be detected using AL.GetSource with parameter ALGetSourcei.BuffersProcessed. When first created, a source will be of type ALSourceType.Undetermined. A successful AL.SourceQueueBuffers call will change the source type to ALSourceType.Streaming.</summary>
        /// <param name="sid">The name of the source to queue buffers onto.</param>
        /// <param name="numEntries">The number of buffers to be queued.</param>
        /// <param name="bids">A pointer to an array of buffer names to be queued.</param>
        unsafe void alSourceQueueBuffers(uint sid, int numEntries, [In] uint* bids); 
        // AL_API void AL_APIENTRY alSourceQueueBuffers( ALuint sid, ALsizei numEntries, const ALuint *bids );

        /// <summary>This function unqueues a set of buffers attached to a source. The number of processed buffers can be detected using AL.GetSource with parameter ALGetSourcei.BuffersProcessed, which is the maximum number of buffers that can be unqueued using this call. The unqueue operation will only take place if all n buffers can be removed from the queue.</summary>
        /// <param name="sid">The name of the source to unqueue buffers from.</param>
        /// <param name="numEntries">The number of buffers to be unqueued.</param>
        /// <param name="bids">A pointer to an array of buffer names that were removed.</param>
        unsafe void alSourceUnqueueBuffers(uint sid, int numEntries, [In] uint* bids); 
        // AL_API void AL_APIENTRY alSourceUnqueueBuffers( ALuint sid, ALsizei numEntries, ALuint *bids );

        void alSourceUnqueueBuffers(uint sid, int numEntries, [Out] uint[] bids); 
        void alSourceUnqueueBuffers(int sid, int numEntries, [Out] int[] bids); 
        void alSourceUnqueueBuffers(uint sid, int numEntries, ref uint bids); 
        void alSourceUnqueueBuffers(int sid, int numEntries, ref int bids); 
        /*
         * Buffer
         * Buffer objects are storage space for sample buffer.
         * Buffers are referred to by Sources. One Buffer can be used
         * by multiple Sources.
         *
         * Properties include: -
         *
         * Frequency (Query only)    AL_FREQUENCY      ALint
         * Size (Query only)         AL_SIZE           ALint
         * Bits (Query only)         AL_BITS           ALint
         * Channels (Query only)     AL_CHANNELS       ALint
         */

        unsafe void alGenBuffers(int n, [Out] uint* buffers); 
        // AL_API void AL_APIENTRY alGenBuffers( ALsizei n, ALuint* Buffers );

        unsafe void alGenBuffers(int n, [Out] int* buffers); 
        unsafe void alDeleteBuffers(int n, [In] uint* buffers); 
        // AL_API void AL_APIENTRY alDeleteBuffers( ALsizei n, const ALuint* Buffers );

        unsafe void alDeleteBuffers(int n, [In] int* buffers); 
        /// <summary>This function tests if a buffer name is valid, returning True if valid, False if not.</summary>
        /// <param name="bid">A buffer Handle previously allocated with <see cref="GenBuffers(int)"/>.</param>
        /// <returns>Success.</returns>
        bool alIsBuffer(uint bid); 
        // AL_API ALboolean AL_APIENTRY alIsBuffer( ALuint bid );

        /// <summary>This function fills a buffer with audio buffer. All the pre-defined formats are PCM buffer, but this function may be used by extensions to load other buffer types as well.</summary>
        /// <param name="bid">buffer Handle/Name to be filled with buffer.</param>
        /// <param name="format">Format type from among the following: ALFormat.Mono8, ALFormat.Mono16, ALFormat.Stereo8, ALFormat.Stereo16.</param>
        /// <param name="buffer">Pointer to a pinned audio buffer.</param>
        /// <param name="size">The size of the audio buffer in bytes.</param>
        /// <param name="freq">The frequency of the audio buffer.</param>
        void alBufferData(uint bid, ALFormat format, IntPtr buffer, int size, int freq); 
        // AL_API void AL_APIENTRY alBufferData( ALuint bid, ALenum format, const ALvoid* buffer, ALsizei size, ALsizei freq );

        /*
         * There are no relevant buffer properties defined in OpenAL 1.1 which can be affected by this call,
         * but this function may be used by OpenAL extensions.
        // AL_API void AL_APIENTRY alBufferf( ALuint bid, ALenum param, ALfloat value );

        // AL_API void AL_APIENTRY alBufferfv( ALuint bid, ALenum param, const ALfloat* values );

        // AL_API void AL_APIENTRY alBufferi( ALuint bid, ALenum param, ALint value );

        // AL_API void AL_APIENTRY alBuffer3i( ALuint bid, ALenum param, ALint value1, ALint value2, ALint value3 );

        // AL_API void AL_APIENTRY alBufferiv( ALuint bid, ALenum param, const ALint* values );

        // AL_API void AL_APIENTRY alBuffer3f( ALuint bid, ALenum param, ALfloat value1, ALfloat value2, ALfloat value3 );

        */

        /*
        void alBuffer3f( uint bid, ALenum param, ALfloat value1, ALfloat value2, ALfloat value3 ); 
        */

        /// <summary>This function retrieves an integer property of a buffer.</summary>
        /// <param name="bid">Buffer name whose attribute is being retrieved</param>
        /// <param name="param">The name of the attribute to be retrieved: ALGetBufferi.Frequency, Bits, Channels, Size, and the currently hidden AL_DATA (dangerous).</param>
        /// <param name="value">A pointer to an int to hold the retrieved buffer</param>
        void alGetBufferi(uint bid, ALGetBufferi param, [Out] out int value); 
        // AL_API void AL_APIENTRY alGetBufferi( ALuint bid, ALenum param, ALint* value );

        // AL_API void AL_APIENTRY alGetBufferf( ALuint bid, ALenum param, ALfloat* value );
        // AL_API void AL_APIENTRY alGetBuffer3f( ALuint bid, ALenum param, ALfloat* value1, ALfloat* value2, ALfloat* value3);
        // AL_API void AL_APIENTRY alGetBufferfv( ALuint bid, ALenum param, ALfloat* values );
        // AL_API void AL_APIENTRY alGetBuffer3i( ALuint bid, ALenum param, ALint* value1, ALint* value2, ALint* value3);
        // AL_API void AL_APIENTRY alGetBufferiv( ALuint bid, ALenum param, ALint* values );

        void alDopplerFactor(float value); 
        // AL_API void AL_APIENTRY alDopplerFactor( ALfloat value );

        void alDopplerVelocity(float value); 
        // AL_API void AL_APIENTRY alDopplerVelocity( ALfloat value );

        void alSpeedOfSound(float value); 
        // AL_API void AL_APIENTRY alSpeedOfSound( ALfloat value );
    }

    /// <summary>
    /// Provides access to the OpenAL 1.1 flat API.
    /// </summary>
    public static partial class ALWrapper
    {
        internal static string library = "openal32.dll";

        private static IAL AL = NativeLibraryBuilder.Default.ActivateInterface<IAL>(library);

        internal const string Lib = "openal32.dll";
        private const CallingConvention Style = CallingConvention.Cdecl;

        /// <summary>This function retrieves an OpenAL string property.</summary>
        /// <param name="param">The property to be returned: Vendor, Version, Renderer and Extensions</param>
        /// <returns>Returns a pointer to a null-terminated string.</returns>
        public static string Get(ALGetString param)
        {
            return Marshal.PtrToStringAnsi(AL.alGetString(param));
        }

        /// <summary>This function retrieves an OpenAL string property.</summary>
        /// <param name="param">The human-readable errorstring to be returned.</param>
        /// <returns>Returns a pointer to a null-terminated string.</returns>
        public static string GetErrorString(ALError param)
        {
            return Marshal.PtrToStringAnsi(AL.alGetString((ALGetString)param));
        }

        /* no functions return more than 1 result ..
        // AL_API void AL_APIENTRY alGetBooleanv( ALenum param, ALboolean* buffer );
        // AL_API void AL_APIENTRY alGetIntegerv( ALenum param, ALint* buffer );
        // AL_API void AL_APIENTRY alGetFloatv( ALenum param, ALfloat* buffer );
        // AL_API void AL_APIENTRY alGetDoublev( ALenum param, ALdouble* buffer );
        */

        /* disabled due to no token using it
        /// <summary>This function returns a boolean OpenAL state.</summary>
        /// <param name="param">the state to be queried: AL_DOPPLER_FACTOR, AL_SPEED_OF_SOUND, AL_DISTANCE_MODEL</param>
        /// <returns>The boolean state described by param will be returned.</returns>
        [DllImport( AL.Lib, EntryPoint = "alGetBoolean", ExactSpelling = true, CallingConvention = AL.Style ), SuppressUnmanagedCodeSecurity( )]
        public static extern bool Get( ALGetBoolean param );
        // AL_API ALboolean AL_APIENTRY alGetBoolean( ALenum param );
        */

        /* disabled due to no token using it
        /// <summary>This function returns a double-precision floating-point OpenAL state.</summary>
        /// <param name="param">the state to be queried: AL_DOPPLER_FACTOR, AL_SPEED_OF_SOUND, AL_DISTANCE_MODEL</param>
        /// <returns>The double value described by param will be returned.</returns>
        [DllImport( AL.Lib, EntryPoint = "alGetDouble", ExactSpelling = true, CallingConvention = AL.Style ), SuppressUnmanagedCodeSecurity( )]
        public static extern double Get( ALGetDouble param );
        // AL_API ALdouble AL_APIENTRY alGetDouble( ALenum param );
        */

        /* Listener
         * Listener represents the location and orientation of the
         * 'user' in 3D-space.
         *
         * Properties include: -
         *
         * Gain         AL_GAIN         ALfloat
         * Position     AL_POSITION     ALfloat[3]
         * Velocity     AL_VELOCITY     ALfloat[3]
         * Orientation  AL_ORIENTATION  ALfloat[6] (Forward then Up vectors)
         */

        /// <summary>This function sets a Math.Vector3 property for the listener.</summary>
        /// <param name="param">The name of the attribute to set: ALListener3f.Position, ALListener3f.Velocity</param>
        /// <param name="values">The Math.Vector3 to set the attribute to.</param>
        public static void Listener(ALListener3f param, ref Vector3 values)
        {
            AL.alListener3f(param, values.X, values.Y, values.Z);
        }

        /// <summary>This function sets a floating-point vector property of the listener.</summary>
        /// <param name="param">The name of the attribute to be set: ALListener3f.Position, ALListener3f.Velocity, ALListenerfv.Orientation</param>
        /// <param name="values">Pointer to floating-point vector values.</param>
        public static void Listener(ALListenerfv param, ref float[] values)
        {
            unsafe
            {
                fixed (float* ptr = &values[0])
                {
                    AL.alListenerfv(param, ptr);
                }
            }
        }

        /// <summary>This function sets two Math.Vector3 properties of the listener.</summary>
        /// <param name="param">The name of the attribute to be set: ALListenerfv.Orientation</param>
        /// <param name="at">A Math.Vector3 for the At-Vector.</param>
        /// <param name="up">A Math.Vector3 for the Up-Vector.</param>
        public static void Listener(ALListenerfv param, ref Vector3 at, ref Vector3 up)
        {
            float[] temp = new float[6];

            temp[0] = at.X;
            temp[1] = at.Y;
            temp[2] = at.Z;

            temp[3] = up.X;
            temp[4] = up.Y;
            temp[5] = up.Z;

            unsafe
            {
                fixed (float* ptr = &temp[0])
                {
                    AL.alListenerfv(param, ptr);
                }
            }
        }

        // Not used by any Enums
        // AL_API void AL_APIENTRY alListeneri( ALenum param, ALint value );
        // AL_API void AL_APIENTRY alListener3i( ALenum param, ALint value1, ALint value2, ALint value3 );
        // AL_API void AL_APIENTRY alListeneriv( ALenum param, const ALint* values );

        /// <summary>This function retrieves a Math.Vector3 from a property of the listener.</summary>
        /// <param name="param">The name of the attribute to be retrieved: ALListener3f.Position, ALListener3f.Velocity</param>
        /// <param name="values">A Math.Vector3 to hold the three floats being retrieved.</param>
        public static void GetListener(ALListener3f param, out Vector3 values)
        {
            AL.alGetListener3f(param, out values.X, out values.Y, out values.Z);
        }

        /// <summary>This function retrieves two Math.Vector3 properties of the listener.</summary>
        /// <param name="param">the name of the attribute to be retrieved: ALListenerfv.Orientation</param>
        /// <param name="at">A Math.Vector3 for the At-Vector.</param>
        /// <param name="up">A Math.Vector3 for the Up-Vector.</param>
        public static void GetListener(ALListenerfv param, out Vector3 at, out Vector3 up)
        {
            float[] pinned = new float[6]; // should lose scope when the function exits
            unsafe
            {
                fixed (float* ptr = &pinned[0])
                {
                    AL.alGetListenerfv(param, ptr);

                    at.X = pinned[0];
                    at.Y = pinned[1];
                    at.Z = pinned[2];

                    up.X = pinned[3];
                    up.Y = pinned[4];
                    up.Z = pinned[5];
                }
            }
        }

        // Not used by any Enum:
        // AL_API void AL_APIENTRY alGetListeneri( ALenum param, ALint* value );
        // AL_API void AL_APIENTRY alGetListener3i( ALenum param, ALint *value1, ALint *value2, ALint *value3 );
        // AL_API void AL_APIENTRY alGetListeneriv( ALenum param, ALint* values );

        /* Source
         * Sources represent individual sound objects in 3D-space.
         * Sources take the PCM buffer provided in the specified Buffer,
         * apply Source-specific modifications, and then
         * submit them to be mixed according to spatial arrangement etc.
         *
         * Properties include: -
         *

         * Position                          AL_POSITION             ALfloat[3]
         * Velocity                          AL_VELOCITY             ALfloat[3]
         * Direction                         AL_DIRECTION            ALfloat[3]

         * Head Relative Mode                AL_SOURCE_RELATIVE      ALint (AL_TRUE or AL_FALSE)
         * Looping                           AL_LOOPING              ALint (AL_TRUE or AL_FALSE)
         *
         * Reference Distance                AL_REFERENCE_DISTANCE   ALfloat
         * Max Distance                      AL_MAX_DISTANCE         ALfloat
         * RollOff Factor                    AL_ROLLOFF_FACTOR       ALfloat
         * Pitch                             AL_PITCH                ALfloat
         * Gain                              AL_GAIN                 ALfloat
         * Min Gain                          AL_MIN_GAIN             ALfloat
         * Max Gain                          AL_MAX_GAIN             ALfloat
         * Inner Angle                       AL_CONE_INNER_ANGLE     ALint or ALfloat
         * Outer Angle                       AL_CONE_OUTER_ANGLE     ALint or ALfloat
         * Cone Outer Gain                   AL_CONE_OUTER_GAIN      ALint or ALfloat
         *
         * MS Offset                         AL_MSEC_OFFSET          ALint or ALfloat
         * Byte Offset                       AL_BYTE_OFFSET          ALint or ALfloat
         * Sample Offset                     AL_SAMPLE_OFFSET        ALint or ALfloat
         * Attached Buffer                   AL_BUFFER               ALint
         *
         * State (Query only)                AL_SOURCE_STATE         ALint
         * Buffers Queued (Query only)       AL_BUFFERS_QUEUED       ALint
         * Buffers Processed (Query only)    AL_BUFFERS_PROCESSED    ALint
         */

        /// <summary>This function generates one or more sources. References to sources are uint values, which are used wherever a source reference is needed (in calls such as AL.DeleteSources and AL.Source with parameter ALSourcei).</summary>
        /// <param name="n">The number of sources to be generated.</param>
        /// <param name="sources">Pointer to an array of uint values which will store the names of the new sources.</param>
        [CLSCompliant(false)]
        public static void GenSources(int n, out uint sources)
        {
            unsafe
            {
                fixed (uint* sources_ptr = &sources)
                {
                     AL.alGenSources(n, sources_ptr);
                }
            }
        }

        /// <summary>This function generates one or more sources. References to sources are int values, which are used wherever a source reference is needed (in calls such as AL.DeleteSources and AL.Source with parameter ALSourcei).</summary>
        /// <param name="n">The number of sources to be generated.</param>
        /// <param name="sources">Pointer to an array of int values which will store the names of the new sources.</param>
        public static void GenSources(int n, out int sources)
        {
            unsafe
            {
                fixed (int* sources_ptr = &sources)
                {
                     AL.alGenSources(n, (uint*)sources_ptr);
                }
            }
        }

        /// <summary>This function generates one or more sources. References to sources are int values, which are used wherever a source reference is needed (in calls such as AL.DeleteSources and AL.Source with parameter ALSourcei).</summary>
        /// <param name="sources">Pointer to an array of int values which will store the names of the new sources.</param>
        public static void GenSources(int[] sources)
        {
            uint[] temp = new uint[sources.Length];
            GenSources(temp.Length, out temp[0]);
            for (int i = 0; i < temp.Length; i++)
            {
                sources[i] = (int)temp[i];
            }
        }

        /// <summary>This function generates one or more sources. References to sources are int values, which are used wherever a source reference is needed (in calls such as AL.DeleteSources and AL.Source with parameter ALSourcei).</summary>
        /// <param name="n">The number of sources to be generated.</param>
        /// <returns>Pointer to an array of int values which will store the names of the new sources.</returns>
        public static int[] GenSources(int n)
        {
            uint[] temp = new uint[n];
            GenSources(temp.Length, out temp[0]);
            int[] sources = new int[n];
            for (int i = 0; i < temp.Length; i++)
            {
                sources[i] = (int)temp[i];
            }
            return sources;
        }

        /// <summary>This function generates one source only. References to sources are int values, which are used wherever a source reference is needed (in calls such as AL.DeleteSources and AL.Source with parameter ALSourcei).</summary>
        /// <returns>Pointer to an int value which will store the name of the new source.</returns>
        public static int GenSource()
        {
            int temp;
            GenSources(1, out temp);
            return (int)temp;
        }

        /// <summary>This function generates one source only. References to sources are uint values, which are used wherever a source reference is needed (in calls such as AL.DeleteSources and AL.Source with parameter ALSourcei).</summary>
        /// <param name="source">Pointer to an uint value which will store the name of the new source.</param>
        [CLSCompliant(false)]
        public static void GenSource(out uint source)
        {
            GenSources(1, out source);
        }

        /// <summary>This function deletes one or more sources.</summary>
        /// <param name="sources">An array of source names identifying the sources to be deleted.</param>
        [CLSCompliant(false)]
        public static void DeleteSources(uint[] sources)
        {
            if (sources == null)
            {
                throw new ArgumentNullException();
            }
            if (sources.Length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            DeleteBuffers(sources.Length, ref sources[0]);
        }

        /// <summary>This function deletes one or more sources.</summary>
        /// <param name="sources">An array of source names identifying the sources to be deleted.</param>
        public static void DeleteSources(int[] sources)
        {
            if (sources == null)
            {
                throw new ArgumentNullException();
            }
            if (sources.Length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            DeleteBuffers(sources.Length, ref sources[0]);
        }

        /// <summary>This function deletes one source only.</summary>
        /// <param name="source">Pointer to a source name identifying the source to be deleted.</param>
        [CLSCompliant(false)]
        public static void DeleteSource(ref uint source)
        {
            AL.alDeleteSources(1, ref source);
        }

        /// <summary>This function deletes one source only.</summary>
        /// <param name="source">Pointer to a source name identifying the source to be deleted.</param>
        public static void DeleteSource(int source)
        {
            AL.alDeleteSources(1, ref source);
        }

        /// <summary>This function tests if a source name is valid, returning True if valid and False if not.</summary>
        /// <param name="sid">A source name to be tested for validity</param>
        /// <returns>Success.</returns>
        public static bool IsSource(int sid)
        {
            return AL.alIsSource((uint)sid);
        }

        /// <summary>This function sets a floating-point property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being set</param>
        /// <param name="param">The name of the attribute to set: ALSourcef.Pitch, Gain, MinGain, MaxGain, MaxDistance, RolloffFactor, ConeOuterGain, ConeInnerAngle, ConeOuterAngle, ReferenceDistance, EfxAirAbsorptionFactor, EfxRoomRolloffFactor, EfxConeOuterGainHighFrequency.</param>
        /// <param name="value">The value to set the attribute to.</param>
        public static void Source(int sid, ALSourcef param, float value)
        {
            AL.alSourcef((uint)sid, param, value);
        }

        /// <summary>This function sets a source property requiring three floating-point values.</summary>
        /// <param name="sid">Source name whose attribute is being set.</param>
        /// <param name="param">The name of the attribute to set: ALSource3f.Position, Velocity, Direction.</param>
        /// <param name="value1">The three ALfloat values which the attribute will be set to.</param>
        /// <param name="value2">The three ALfloat values which the attribute will be set to.</param>
        /// <param name="value3">The three ALfloat values which the attribute will be set to.</param>
        public static void Source(int sid, ALSource3f param, float value1, float value2, float value3)
        {
            AL.alSource3f((uint)sid, param, value1, value2, value3);
        }

        /// <summary>This function sets a source property requiring three floating-point values.</summary>
        /// <param name="sid">Source name whose attribute is being set.</param>
        /// <param name="param">The name of the attribute to set: ALSource3f.Position, Velocity, Direction.</param>
        /// <param name="values">A Math.Vector3 which the attribute will be set to.</param>
        [CLSCompliant(false)]
        public static void Source(uint sid, ALSource3f param, ref Vector3 values)
        {
            AL.alSource3f(sid, param, values.X, values.Y, values.Z);
        }

        /// <summary>This function sets a source property requiring three floating-point values.</summary>
        /// <param name="sid">Source name whose attribute is being set.</param>
        /// <param name="param">The name of the attribute to set: ALSource3f.Position, Velocity, Direction.</param>
        /// <param name="values">A Math.Vector3 which the attribute will be set to.</param>
        public static void Source(int sid, ALSource3f param, ref Vector3 values)
        {
            AL.alSource3f((uint)sid, param, values.X, values.Y, values.Z);
        }

        /// <summary>This function sets an integer property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being set.</param>
        /// <param name="param">The name of the attribute to set: ALSourcei.SourceRelative, ConeInnerAngle, ConeOuterAngle, Looping, Buffer, SourceState.</param>
        /// <param name="value">The value to set the attribute to.</param>
        public static void Source(int sid, ALSourcei param, int value)
        {
            AL.alSourcei((uint)sid, param, value);
        }

        /// <summary>This function sets an bool property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being set.</param>
        /// <param name="param">The name of the attribute to set: ALSourceb.SourceRelative, Looping.</param>
        /// <param name="value">The value to set the attribute to.</param>
        [CLSCompliant(false)]
        public static void Source(uint sid, ALSourceb param, bool value)
        {
            AL.alSourcei(sid, (ALSourcei)param, (value) ? 1 : 0);
        }

        /// <summary>This function sets an bool property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being set.</param>
        /// <param name="param">The name of the attribute to set: ALSourceb.SourceRelative, Looping.</param>
        /// <param name="value">The value to set the attribute to.</param>
        public static void Source(int sid, ALSourceb param, bool value)
        {
            AL.alSourcei((uint)sid, (ALSourcei)param, (value) ? 1 : 0);
        }

        /// <summary>(Helper) Binds a Buffer to a Source handle.</summary>
        /// <param name="source">Source name to attach the Buffer to.</param>
        /// <param name="buffer">Buffer name which is attached to the Source.</param>
        [CLSCompliant(false)]
        public static void BindBufferToSource(uint source, uint buffer)
        {
            AL.alSourcei(source, ALSourcei.Buffer, (int)buffer);
        }

        /// <summary>(Helper) Binds a Buffer to a Source handle.</summary>
        /// <param name="source">Source name to attach the Buffer to.</param>
        /// <param name="buffer">Buffer name which is attached to the Source.</param>
        public static void BindBufferToSource(int source, int buffer)
        {
            AL.alSourcei((uint)source, ALSourcei.Buffer, buffer);
        }

        /// <summary>This function sets 3 integer properties of a source. This property is used to establish connections between Sources and Auxiliary Effect Slots.</summary>
        /// <param name="sid">Source name whose attribute is being set.</param>
        /// <param name="param">The name of the attribute to set: EfxAuxiliarySendFilter</param>
        /// <param name="value1">The value to set the attribute to. (EFX Extension) The destination Auxiliary Effect Slot ID</param>
        /// <param name="value2">The value to set the attribute to. (EFX Extension) The Auxiliary Send number.</param>
        ///<param name="value3">The value to set the attribute to. (EFX Extension) optional Filter ID.</param>
        public static void Source(int sid, ALSource3i param, int value1, int value2, int value3)
        {
            AL.alSource3i((uint)sid, param, value1, value2, value3);
        }

        // Not used by any Enum:
        // AL_API void AL_APIENTRY alSourcefv( ALuint sid, ALenum param, const ALfloat* values );
        // AL_API void AL_APIENTRY alSourceiv( ALuint sid, ALenum param, const ALint* values );

        /// <summary>This function retrieves a floating-point property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being retrieved.</param>
        /// <param name="param">The name of the attribute to set: ALSourcef.Pitch, Gain, MinGain, MaxGain, MaxDistance, RolloffFactor, ConeOuterGain, ConeInnerAngle, ConeOuterAngle, ReferenceDistance, EfxAirAbsorptionFactor, EfxRoomRolloffFactor, EfxConeOuterGainHighFrequency.</param>
        /// <param name="value">A pointer to the floating-point value being retrieved</param>
        public static void GetSource(int sid, ALSourcef param, out float value)
        {
            AL.alGetSourcef((uint)sid, param, out value);
        }

        /// <summary>This function retrieves three floating-point values representing a property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being retrieved.</param>
        /// <param name="param">the name of the attribute being retrieved: ALSource3f.Position, Velocity, Direction.</param>
        /// <param name="value1">Pointer to the value to retrieve.</param>
        /// <param name="value2">Pointer to the value to retrieve.</param>
        /// <param name="value3">Pointer to the value to retrieve.</param>
        public static void GetSource(int sid, ALSource3f param, out float value1, out float value2, out float value3)
        {
            AL.alGetSource3f((uint)sid, param, out value1, out value2, out value3);
        }

        /// <summary>This function retrieves three floating-point values representing a property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being retrieved.</param>
        /// <param name="param">the name of the attribute being retrieved: ALSource3f.Position, Velocity, Direction.</param>
        /// <param name="values">A Math.Vector3 to retrieve the values to.</param>
        [CLSCompliant(false)]
        public static void GetSource(uint sid, ALSource3f param, out Vector3 values)
        {
            AL.alGetSource3f(sid, param, out values.X, out values.Y, out values.Z);
        }

        /// <summary>This function retrieves three floating-point values representing a property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being retrieved.</param>
        /// <param name="param">the name of the attribute being retrieved: ALSource3f.Position, Velocity, Direction.</param>
        /// <param name="values">A Math.Vector3 to retrieve the values to.</param>
        public static void GetSource(int sid, ALSource3f param, out Vector3 values)
        {
            AL.alGetSource3f((uint)sid, param, out values.X, out values.Y, out values.Z);
        }

        /// <summary>This function retrieves an integer property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being retrieved.</param>
        /// <param name="param">The name of the attribute to retrieve: ALSourcei.SourceRelative, Buffer, SourceState, BuffersQueued, BuffersProcessed.</param>
        /// <param name="value">A pointer to the integer value being retrieved.</param>
        public static void GetSource(int sid, ALGetSourcei param, out int value)
        {
            AL.alGetSourcei((uint)sid, param, out value);
        }

        /// <summary>This function retrieves a bool property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being retrieved.</param>
        /// <param name="param">The name of the attribute to get: ALSourceb.SourceRelative, Looping.</param>
        /// <param name="value">A pointer to the bool value being retrieved.</param>
        [CLSCompliant(false)]
        public static void GetSource(uint sid, ALSourceb param, out bool value)
        {
            int result;
            AL.alGetSourcei(sid, (ALGetSourcei)param, out result);
            value = result != 0;
        }

        /// <summary>This function retrieves a bool property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being retrieved.</param>
        /// <param name="param">The name of the attribute to get: ALSourceb.SourceRelative, Looping.</param>
        /// <param name="value">A pointer to the bool value being retrieved.</param>
        public static void GetSource(int sid, ALSourceb param, out bool value)
        {
            int result;
            AL.alGetSourcei((uint)sid, (ALGetSourcei)param, out result);
            value = result != 0;
        }

        // Not used by any Enum:
        // AL_API void AL_APIENTRY alGetSource3i( ALuint sid, ALenum param, ALint* value1, ALint* value2, ALint* value3);
        // AL_API void AL_APIENTRY alGetSourcefv( ALuint sid, ALenum param, ALfloat* values );
        // AL_API void AL_APIENTRY alGetSourceiv( ALuint sid,  ALenum param, ALint* values );

        /// <summary>This function plays a set of sources. The playing sources will have their state changed to ALSourceState.Playing. When called on a source which is already playing, the source will restart at the beginning. When the attached buffer(s) are done playing, the source will progress to the ALSourceState.Stopped state.</summary>
        /// <param name="ns">The number of sources to be played.</param>
        /// <param name="sids">A pointer to an array of sources to be played.</param>
        [CLSCompliant(false)]
        public static void SourcePlay(int ns, uint[] sids)
        {
            unsafe
            {
                fixed (uint* ptr = sids)
                {
                    AL.alSourcePlayv(ns, ptr);
                }
            }
        }

        /// <summary>This function plays a set of sources. The playing sources will have their state changed to ALSourceState.Playing. When called on a source which is already playing, the source will restart at the beginning. When the attached buffer(s) are done playing, the source will progress to the ALSourceState.Stopped state.</summary>
        /// <param name="ns">The number of sources to be played.</param>
        /// <param name="sids">A pointer to an array of sources to be played.</param>
        public static void SourcePlay(int ns, int[] sids)
        {
            uint[] temp = new uint[ns];
            for (int i = 0; i < ns; i++)
            {
                temp[i] = (uint)sids[i];
            }
            SourcePlay(ns, temp);
        }

        /// <summary>This function plays a set of sources. The playing sources will have their state changed to ALSourceState.Playing. When called on a source which is already playing, the source will restart at the beginning. When the attached buffer(s) are done playing, the source will progress to the ALSourceState.Stopped state.</summary>
        /// <param name="ns">The number of sources to be played.</param>
        /// <param name="sids">A pointer to an array of sources to be played.</param>
        [CLSCompliant(false)]
        public static void SourcePlay(int ns, ref uint sids)
        {
            unsafe
            {
                fixed (uint* ptr = &sids)
                {
                    AL.alSourcePlayv(ns, ptr);
                }
            }
        }

        /// <summary>This function stops a set of sources. The stopped sources will have their state changed to ALSourceState.Stopped.</summary>
        /// <param name="ns">The number of sources to stop.</param>
        /// <param name="sids">A pointer to an array of sources to be stopped.</param>
        [CLSCompliant(false)]
        public static void SourceStop(int ns, uint[] sids)
        {
            unsafe
            {
                fixed (uint* ptr = sids)
                {
                    AL.alSourceStopv(ns, ptr);
                }
            }
        }

        /// <summary>This function stops a set of sources. The stopped sources will have their state changed to ALSourceState.Stopped.</summary>
        /// <param name="ns">The number of sources to stop.</param>
        /// <param name="sids">A pointer to an array of sources to be stopped.</param>
        public static void SourceStop(int ns, int[] sids)
        {
            uint[] temp = new uint[ns];
            for (int i = 0; i < ns; i++)
            {
                temp[i] = (uint)sids[i];
            }
            SourceStop(ns, temp);
        }

        /// <summary>This function stops a set of sources. The stopped sources will have their state changed to ALSourceState.Stopped.</summary>
        /// <param name="ns">The number of sources to stop.</param>
        /// <param name="sids">A pointer to an array of sources to be stopped.</param>
        [CLSCompliant(false)]
        public static void SourceStop(int ns, ref uint sids)
        {
            unsafe
            {
                fixed (uint* ptr = &sids)
                {
                    AL.alSourceStopv(ns, ptr);
                }
            }
        }

        /// <summary>This function stops a set of sources and sets all their states to ALSourceState.Initial.</summary>
        /// <param name="ns">The number of sources to be rewound.</param>
        /// <param name="sids">A pointer to an array of sources to be rewound.</param>
        [CLSCompliant(false)]
        public static void SourceRewind(int ns, uint[] sids)
        {
            unsafe
            {
                fixed (uint* ptr = sids)
                {
                    AL.alSourceRewindv(ns, ptr);
                }
            }
        }

        /// <summary>This function stops a set of sources and sets all their states to ALSourceState.Initial.</summary>
        /// <param name="ns">The number of sources to be rewound.</param>
        /// <param name="sids">A pointer to an array of sources to be rewound.</param>
        public static void SourceRewind(int ns, int[] sids)
        {
            uint[] temp = new uint[ns];
            for (int i = 0; i < ns; i++)
            {
                temp[i] = (uint)sids[i];
            }
            SourceRewind(ns, temp);
        }

        /// <summary>This function stops a set of sources and sets all their states to ALSourceState.Initial.</summary>
        /// <param name="ns">The number of sources to be rewound.</param>
        /// <param name="sids">A pointer to an array of sources to be rewound.</param>
        [CLSCompliant(false)]
        public static void SourceRewind(int ns, ref uint sids)
        {
            unsafe
            {
                fixed (uint* ptr = &sids)
                {
                    AL.alSourceRewindv(ns, ptr);
                }
            }
        }

        /// <summary>This function pauses a set of sources. The paused sources will have their state changed to ALSourceState.Paused.</summary>
        /// <param name="ns">The number of sources to be paused.</param>
        /// <param name="sids">A pointer to an array of sources to be paused.</param>
        [CLSCompliant(false)]
        public static void SourcePause(int ns, uint[] sids)
        {
            unsafe
            {
                fixed (uint* ptr = sids)
                {
                    AL.alSourcePausev(ns, ptr);
                }
            }
        }
        /// <summary>This function pauses a set of sources. The paused sources will have their state changed to ALSourceState.Paused.</summary>
        /// <param name="ns">The number of sources to be paused.</param>
        /// <param name="sids">A pointer to an array of sources to be paused.</param>
        public static void SourcePause(int ns, int[] sids)
        {
            uint[] temp = new uint[ns];
            for (int i = 0; i < ns; i++)
            {
                temp[i] = (uint)sids[i];
            }
            SourcePause(ns, temp);
        }

        /// <summary>This function pauses a set of sources. The paused sources will have their state changed to ALSourceState.Paused.</summary>
        /// <param name="ns">The number of sources to be paused.</param>
        /// <param name="sids">A pointer to an array of sources to be paused.</param>
        [CLSCompliant(false)]
        public static void SourcePause(int ns, ref uint sids)
        {
            unsafe
            {
                fixed (uint* ptr = &sids)
                {
                    AL.alSourcePausev(ns, ptr);
                }
            }
        }

        /// <summary>This function plays, replays or resumes a source. The playing source will have it's state changed to ALSourceState.Playing. When called on a source which is already playing, the source will restart at the beginning. When the attached buffer(s) are done playing, the source will progress to the ALSourceState.Stopped state.</summary>
        /// <param name="sid">The name of the source to be played.</param>
        public static void SourcePlay(int sid)
        {
            AL.alSourcePlay((uint)sid);
        }

        /// <summary>This function stops a source. The stopped source will have it's state changed to ALSourceState.Stopped.</summary>
        /// <param name="sid">The name of the source to be stopped.</param>
        public static void SourceStop(int sid)
        {
            AL.alSourceStop((uint)sid);
        }

        /// <summary>This function stops the source and sets its state to ALSourceState.Initial.</summary>
        /// <param name="sid">The name of the source to be rewound.</param>
        public static void SourceRewind(int sid)
        {
            AL.alSourceRewind((uint)sid);
        }

        /// <summary>This function pauses a source. The paused source will have its state changed to ALSourceState.Paused.</summary>
        /// <param name="sid">The name of the source to be paused.</param>
        public static void SourcePause(int sid)
        {
            AL.alSourcePause((uint)sid);
        }

        /// <summary>This function queues a set of buffers on a source. All buffers attached to a source will be played in sequence, and the number of processed buffers can be detected using AL.GetSource with parameter ALGetSourcei.BuffersProcessed. When first created, a source will be of type ALSourceType.Undetermined. A successful AL.SourceQueueBuffers call will change the source type to ALSourceType.Streaming.</summary>
        /// <param name="sid">The name of the source to queue buffers onto.</param>
        /// <param name="numEntries">The number of buffers to be queued.</param>
        /// <param name="bids">A pointer to an array of buffer names to be queued.</param>
        [CLSCompliant(false)]
        public static void SourceQueueBuffers(uint sid, int numEntries, uint[] bids)
        {
            unsafe
            {
                fixed (uint* ptr = bids)
                {
                    AL.alSourceQueueBuffers(sid, numEntries, ptr);
                }
            }
        }

        /// <summary>This function queues a set of buffers on a source. All buffers attached to a source will be played in sequence, and the number of processed buffers can be detected using AL.GetSource with parameter ALGetSourcei.BuffersProcessed. When first created, a source will be of type ALSourceType.Undetermined. A successful AL.SourceQueueBuffers call will change the source type to ALSourceType.Streaming.</summary>
        /// <param name="sid">The name of the source to queue buffers onto.</param>
        /// <param name="numEntries">The number of buffers to be queued.</param>
        /// <param name="bids">A pointer to an array of buffer names to be queued.</param>
        public static void SourceQueueBuffers(int sid, int numEntries, int[] bids)
        {
            uint[] temp = new uint[numEntries];
            for (int i = 0; i < numEntries; i++)
            {
                temp[i] = (uint)bids[i];
            }
            SourceQueueBuffers((uint)sid, numEntries, temp);
        }

        /// <summary>This function queues a set of buffers on a source. All buffers attached to a source will be played in sequence, and the number of processed buffers can be detected using AL.GetSource with parameter ALGetSourcei.BuffersProcessed. When first created, a source will be of type ALSourceType.Undetermined. A successful AL.SourceQueueBuffers call will change the source type to ALSourceType.Streaming.</summary>
        /// <param name="sid">The name of the source to queue buffers onto.</param>
        /// <param name="numEntries">The number of buffers to be queued.</param>
        /// <param name="bids">A pointer to an array of buffer names to be queued.</param>
        [CLSCompliant(false)]
        public static void SourceQueueBuffers(uint sid, int numEntries, ref uint bids)
        {
            unsafe
            {
                fixed (uint* ptr = &bids)
                {
                    AL.alSourceQueueBuffers(sid, numEntries, ptr);
                }
            }
        }

        /// <summary>This function queues a set of buffers on a source. All buffers attached to a source will be played in sequence, and the number of processed buffers can be detected using AL.GetSource with parameter ALGetSourcei.BuffersProcessed. When first created, a source will be of type ALSourceType.Undetermined. A successful AL.SourceQueueBuffers call will change the source type to ALSourceType.Streaming.</summary>
        /// <param name="source">The name of the source to queue buffers onto.</param>
        /// <param name="buffer">The name of the buffer to be queued.</param>
        public static void SourceQueueBuffer(int source, int buffer)
        {
            unsafe { AL.alSourceQueueBuffers((uint)source, 1, (uint*)&buffer); }
        }

        /// <summary>This function unqueues a set of buffers attached to a source. The number of processed buffers can be detected using AL.GetSource with parameter ALGetSourcei.BuffersProcessed, which is the maximum number of buffers that can be unqueued using this call. The unqueue operation will only take place if all n buffers can be removed from the queue.</summary>
        /// <param name="sid">The name of the source to unqueue buffers from.</param>
        public static int SourceUnqueueBuffer(int sid)
        {
            uint buf;
            unsafe { AL.alSourceUnqueueBuffers((uint)sid, 1, &buf); }
            return (int)buf;
        }

        /// <summary>This function unqueues a set of buffers attached to a source. The number of processed buffers can be detected using AL.GetSource with parameter ALGetSourcei.BuffersProcessed, which is the maximum number of buffers that can be unqueued using this call. The unqueue operation will only take place if all n buffers can be removed from the queue.</summary>
        /// <param name="sid">The name of the source to unqueue buffers from.</param>
        /// <param name="numEntries">The number of buffers to be unqueued.</param>
        public static int[] SourceUnqueueBuffers(int sid, int numEntries)
        {
            if (numEntries <= 0)
            {
                throw new ArgumentOutOfRangeException("numEntries", "Must be greater than zero.");
            }
            int[] buf = new int[numEntries];
            AL.alSourceUnqueueBuffers(sid, numEntries, buf);
            return buf;
        }

        /*
         * Buffer
         * Buffer objects are storage space for sample buffer.
         * Buffers are referred to by Sources. One Buffer can be used
         * by multiple Sources.
         *
         * Properties include: -
         *
         * Frequency (Query only)    AL_FREQUENCY      ALint
         * Size (Query only)         AL_SIZE           ALint
         * Bits (Query only)         AL_BITS           ALint
         * Channels (Query only)     AL_CHANNELS       ALint
         */

        /// <summary>This function generates one or more buffers, which contain audio buffer (see AL.BufferData). References to buffers are uint values, which are used wherever a buffer reference is needed (in calls such as AL.DeleteBuffers, AL.Source with parameter ALSourcei, AL.SourceQueueBuffers, and AL.SourceUnqueueBuffers).</summary>
        /// <param name="n">The number of buffers to be generated.</param>
        /// <param name="buffers">Pointer to an array of uint values which will store the names of the new buffers.</param>
        [CLSCompliant(false)]
        public static void GenBuffers(int n, out uint buffers)
        {
            unsafe
            {
                fixed (uint* pbuffers = &buffers)
                {
                    AL.alGenBuffers(n, pbuffers);
                }
            }
        }

        /// <summary>This function generates one or more buffers, which contain audio buffer (see AL.BufferData). References to buffers are uint values, which are used wherever a buffer reference is needed (in calls such as AL.DeleteBuffers, AL.Source with parameter ALSourcei, AL.SourceQueueBuffers, and AL.SourceUnqueueBuffers).</summary>
        /// <param name="n">The number of buffers to be generated.</param>
        /// <param name="buffers">Pointer to an array of uint values which will store the names of the new buffers.</param>
        public static void GenBuffers(int n, out int buffers)
        {
            unsafe
            {
                fixed (int* pbuffers = &buffers)
                {
                    AL.alGenBuffers(n, pbuffers);
                }
            }
        }

        /// <summary>This function generates one or more buffers, which contain audio data (see AL.BufferData). References to buffers are uint values, which are used wherever a buffer reference is needed (in calls such as AL.DeleteBuffers, AL.Source with parameter ALSourcei, AL.SourceQueueBuffers, and AL.SourceUnqueueBuffers).</summary>
        /// <param name="n">The number of buffers to be generated.</param>
        /// <returns>Pointer to an array of uint values which will store the names of the new buffers.</returns>
        public static int[] GenBuffers(int n)
        {
            int[] buffers = new int[n];
            GenBuffers(buffers.Length, out buffers[0]);
            return buffers;
        }

        /// <summary>This function generates one buffer only, which contain audio data (see AL.BufferData). References to buffers are uint values, which are used wherever a buffer reference is needed (in calls such as AL.DeleteBuffers, AL.Source with parameter ALSourcei, AL.SourceQueueBuffers, and AL.SourceUnqueueBuffers).</summary>
        /// <returns>Pointer to an uint value which will store the name of the new buffer.</returns>
        public static int GenBuffer()
        {
            int temp;
            GenBuffers(1, out temp);
            return (int)temp;
        }

        /// <summary>This function generates one buffer only, which contain audio data (see AL.BufferData). References to buffers are uint values, which are used wherever a buffer reference is needed (in calls such as AL.DeleteBuffers, AL.Source with parameter ALSourcei, AL.SourceQueueBuffers, and AL.SourceUnqueueBuffers).</summary>
        /// <param name="buffer">Pointer to an uint value which will store the names of the new buffer.</param>
        [CLSCompliant(false)]
        public static void GenBuffer(out uint buffer)
        {
            GenBuffers(1, out buffer);
        }

        /// <summary>This function deletes one or more buffers, freeing the resources used by the buffer. Buffers which are attached to a source can not be deleted. See AL.Source (ALSourcei) and AL.SourceUnqueueBuffers for information on how to detach a buffer from a source.</summary>
        /// <param name="n">The number of buffers to be deleted.</param>
        /// <param name="buffers">Pointer to an array of buffer names identifying the buffers to be deleted.</param>
        [CLSCompliant(false)]
        public static void DeleteBuffers(int n, [In] ref uint buffers)
        {
            unsafe
            {
                fixed (uint* pbuffers = &buffers)
                {
                    AL.alDeleteBuffers(n, pbuffers);
                }
            }
        }

        /// <summary>This function deletes one or more buffers, freeing the resources used by the buffer. Buffers which are attached to a source can not be deleted. See AL.Source (ALSourcei) and AL.SourceUnqueueBuffers for information on how to detach a buffer from a source.</summary>
        /// <param name="n">The number of buffers to be deleted.</param>
        /// <param name="buffers">Pointer to an array of buffer names identifying the buffers to be deleted.</param>
        public static void DeleteBuffers(int n, [In] ref int buffers)
        {
            unsafe
            {
                fixed (int* pbuffers = &buffers)
                {
                    AL.alDeleteBuffers(n, pbuffers);
                }
            }
        }

        /// <summary>This function deletes one buffer only, freeing the resources used by the buffer. Buffers which are attached to a source can not be deleted. See AL.Source (ALSourcei) and AL.SourceUnqueueBuffers for information on how to detach a buffer from a source.</summary>
        /// <param name="buffers">Pointer to a buffer name identifying the buffer to be deleted.</param>
        [CLSCompliant(false)]
        public static void DeleteBuffers(uint[] buffers)
        {
            if (buffers == null)
            {
                throw new ArgumentNullException();
            }
            if (buffers.Length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            DeleteBuffers(buffers.Length, ref buffers[0]);
        }

        /// <summary>This function deletes one or more buffers, freeing the resources used by the buffer. Buffers which are attached to a source can not be deleted. See AL.Source (ALSourcei) and AL.SourceUnqueueBuffers for information on how to detach a buffer from a source.</summary>
        /// <param name="buffers">Pointer to an array of buffer names identifying the buffers to be deleted.</param>
        public static void DeleteBuffers(int[] buffers)
        {
            if (buffers == null)
            {
                throw new ArgumentNullException();
            }
            if (buffers.Length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            DeleteBuffers(buffers.Length, ref buffers[0]);
        }

        /// <summary>This function deletes one buffer only, freeing the resources used by the buffer. Buffers which are attached to a source can not be deleted. See AL.Source (ALSourcei) and AL.SourceUnqueueBuffers for information on how to detach a buffer from a source.</summary>
        /// <param name="buffer">Pointer to a buffer name identifying the buffer to be deleted.</param>
        [CLSCompliant(false)]
        public static void DeleteBuffer(ref uint buffer)
        {
            DeleteBuffers(1, ref buffer);
        }

        /// <summary>This function deletes one buffer only, freeing the resources used by the buffer. Buffers which are attached to a source can not be deleted. See AL.Source (ALSourcei) and AL.SourceUnqueueBuffers for information on how to detach a buffer from a source.</summary>
        /// <param name="buffer">Pointer to a buffer name identifying the buffer to be deleted.</param>
                public static void DeleteBuffer(int buffer)
        {
            DeleteBuffers(1, ref buffer);
        }

        /// <summary>This function tests if a buffer name is valid, returning True if valid, False if not.</summary>
        /// <param name="bid">A buffer Handle previously allocated with <see cref="GenBuffers(int)"/>.</param>
        /// <returns>Success.</returns>
        public static bool IsBuffer(int bid)
        {
            uint temp = (uint)bid;
            return AL.alIsBuffer(temp);
        }

        /// <summary>This function fills a buffer with audio buffer. All the pre-defined formats are PCM buffer, but this function may be used by extensions to load other buffer types as well.</summary>
        /// <param name="bid">buffer Handle/Name to be filled with buffer.</param>
        /// <param name="format">Format type from among the following: ALFormat.Mono8, ALFormat.Mono16, ALFormat.Stereo8, ALFormat.Stereo16.</param>
        /// <param name="buffer">Pointer to a pinned audio buffer.</param>
        /// <param name="size">The size of the audio buffer in bytes.</param>
        /// <param name="freq">The frequency of the audio buffer.</param>
        public static void BufferData(int bid, ALFormat format, IntPtr buffer, int size, int freq)
        {
            AL.alBufferData((uint)bid, format, buffer, size, freq);
        }

        /// <summary>This function fills a buffer with audio buffer. All the pre-defined formats are PCM buffer, but this function may be used by extensions to load other buffer types as well.</summary>
        /// <param name="bid">buffer Handle/Name to be filled with buffer.</param>
        /// <param name="format">Format type from among the following: ALFormat.Mono8, ALFormat.Mono16, ALFormat.Stereo8, ALFormat.Stereo16.</param>
        /// <param name="buffer">The audio buffer.</param>
        /// <param name="size">The size of the audio buffer in bytes.</param>
        /// <param name="freq">The frequency of the audio buffer.</param>
        public static void BufferData<TBuffer>(int bid, ALFormat format, TBuffer[] buffer, int size, int freq)
            where TBuffer : struct
        {
            if (!BlittableValueType.Check(buffer))
            {
                throw new ArgumentException("buffer");
            }

            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try { BufferData(bid, format, handle.AddrOfPinnedObject(), size, freq); }
            finally { handle.Free(); }
        }

        /*
        Remarks (from Manual)
         * There are no relevant buffer properties defined in OpenAL 1.1 which can be affected by this call,
         * but this function may be used by OpenAL extensions.

        // AL_API void AL_APIENTRY alBufferf( ALuint bid, ALenum param, ALfloat value );
        // AL_API void AL_APIENTRY alBufferfv( ALuint bid, ALenum param, const ALfloat* values );
        // AL_API void AL_APIENTRY alBufferi( ALuint bid, ALenum param, ALint value );
        // AL_API void AL_APIENTRY alBuffer3i( ALuint bid, ALenum param, ALint value1, ALint value2, ALint value3 );
        // AL_API void AL_APIENTRY alBufferiv( ALuint bid, ALenum param, const ALint* values );
        // AL_API void AL_APIENTRY alBuffer3f( ALuint bid, ALenum param, ALfloat value1, ALfloat value2, ALfloat value3 );
        */

        /*
        [DllImport( Al.Lib, EntryPoint = "alBuffer3f", ExactSpelling = true, CallingConvention = Al.Style ), SuppressUnmanagedCodeSecurity( )]
        public static extern void Buffer3f( uint bid, ALenum param, ALfloat value1, ALfloat value2, ALfloat value3 );

        public static void Bufferv3( uint bid, Alenum param, ref Vector3 values )
        {
            Buffer3f( bid, param, values.X, values.Y, values.Z );
        }*/

        /// <summary>This function retrieves an integer property of a buffer.</summary>
        /// <param name="bid">Buffer name whose attribute is being retrieved</param>
        /// <param name="param">The name of the attribute to be retrieved: ALGetBufferi.Frequency, Bits, Channels, Size, and the currently hidden AL_DATA (dangerous).</param>
        /// <param name="value">A pointer to an int to hold the retrieved buffer</param>
        public static void GetBuffer(int bid, ALGetBufferi param, out int value)
        {
            AL.alGetBufferi((uint)bid, param, out value);
        }

        // AL_API void AL_APIENTRY alGetBufferf( ALuint bid, ALenum param, ALfloat* value );
        // AL_API void AL_APIENTRY alGetBuffer3f( ALuint bid, ALenum param, ALfloat* value1, ALfloat* value2, ALfloat* value3);
        // AL_API void AL_APIENTRY alGetBufferfv( ALuint bid, ALenum param, ALfloat* values );
        // AL_API void AL_APIENTRY alGetBuffer3i( ALuint bid, ALenum param, ALint* value1, ALint* value2, ALint* value3);
        // AL_API void AL_APIENTRY alGetBufferiv( ALuint bid, ALenum param, ALint* values );

        /// <summary>(Helper) Returns Source state information.</summary>
        /// <param name="sid">The source to be queried.</param>
        /// <returns>state information from OpenAL.</returns>
        [CLSCompliant(false)]
        public static ALSourceState GetSourceState(uint sid)
        {
            int temp;
            AL.alGetSourcei(sid, ALGetSourcei.SourceState, out temp);
            return (ALSourceState)temp;
        }

        /// <summary>(Helper) Returns Source state information.</summary>
        /// <param name="sid">The source to be queried.</param>
        /// <returns>state information from OpenAL.</returns>
        public static ALSourceState GetSourceState(int sid)
        {
            int temp;
            GetSource(sid, ALGetSourcei.SourceState, out temp);
            return (ALSourceState)temp;
        }

        /// <summary>(Helper) Returns Source type information.</summary>
        /// <param name="sid">The source to be queried.</param>
        /// <returns>type information from OpenAL.</returns>
        [CLSCompliant(false)]
        public static ALSourceType GetSourceType(uint sid)
        {
            int temp;
            AL.alGetSourcei(sid, ALGetSourcei.SourceType, out temp);
            return (ALSourceType)temp;
        }

        /// <summary>(Helper) Returns Source type information.</summary>
        /// <param name="sid">The source to be queried.</param>
        /// <returns>type information from OpenAL.</returns>
        public static ALSourceType GetSourceType(int sid)
        {
            int temp;
            GetSource(sid, ALGetSourcei.SourceType, out temp);
            return (ALSourceType)temp;
        }

        /// <summary>
        /// Returns the <see cref="ALDistanceModel"/> of the current context.
        /// </summary>
        /// <returns>The <see cref="ALDistanceModel"/> of the current context.</returns>
        public static ALDistanceModel GetDistanceModel()
        {
            return (ALDistanceModel)AL.alGetInteger(ALGetInteger.DistanceModel);
        }
    }
}
