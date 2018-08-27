using System;
using AdvancedDLSupport;

namespace OpenTK.Platform.SDL2.Interfaces
{
    [NativeSymbols(Prefix = "SDL_")]
    internal interface ISDL2Events
    {
        /// <summary>
        /// Use this function to add a callback to be triggered when an event is added to the event queue. 
        /// </summary>
        /// <param name="filter">the function to call when an event happens.</param>
        /// <param name="userdata">a pointer that is passed to filter.</param>
        void AddEventWatch(EventFilter filter, IntPtr userdata);
 
        /// <summary>
        /// Use this function to add a callback to be triggered when an event is added to the event queue. 
        /// </summary>
        /// <param name="filter">the function to call when an event happens.</param>
        /// <param name="userdata">a pointer that is passed to filter.</param>
        void AddEventWatch(IntPtr filter, IntPtr userdata);

        /// <summary>
        /// Use this function to remove an event watch callback added with <see cref="AddEventWatch()"/>. 
        /// </summary>
        /// <param name="filter">the function originally passed to <see cref="AddEventWatch()"/></param>
        /// <param name="userdata">the pointer originally passed to <see cref="AddEventWatch()"/></param>
        void DelEventWatch(EventFilter filter, IntPtr userdata);
 
        /// <summary>
        /// Use this function to remove an event watch callback added with <see cref="AddEventWatch()"/>. 
        /// </summary>
        /// <param name="filter">the function originally passed to <see cref="AddEventWatch()"/></param>
        /// <param name="userdata">the pointer originally passed to <see cref="AddEventWatch()"/></param>
        void DelEventWatch(IntPtr filter, IntPtr userdata);

        /// <summary>
        /// Use this function to poll for currently pending events. 
        /// </summary>
        /// <param name="e">the <see cref="Event"/>structure to be filled with the next event from the queue, or <see cref="IntPtr.Zero"/></param>
        /// <returns>Returns 1 if there is a pending event or 0 if there are none available. </returns>
        int PollEvent(out Event e);

        /// <summary>
        /// Use this function to pump the event loop, gathering events from the input devices. 
        /// </summary>
        void PumpEvents();
 
        /// <summary>
        /// Use this function to add an event to the event queue. 
        /// </summary>
        /// <returns>Returns 1 on success, 0 if the event was filtered, or a negative error code on failure; 
        /// call <see cref="GetError()"/> for more information. A common reason for error is the event queue being full. </returns>
        int PushEvent(ref Event @event);
 
        
    }
}