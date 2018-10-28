using System;
using AdvancedDLSupport;
using AdvancedDLSupport.AOT;

namespace OpenTK.Platform.SDL2.Interfaces
{
    [NativeSymbols(Prefix = "SDL_"), AOTType]
    internal interface IEvents
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
        /// Use this function to check the event queue for messages and optionally return them. 
        /// </summary>
        /// <param name="events"> destination buffer for the retrieved events </param>
        /// <param name="count"> if action is <c>EventAction.ADDEVENT</c>, the number of events to add back to the event queue; 
        /// if action is <c>EventAction.PeekEvent</c> or <c>EventAction.GETEVENT</c>, the maximum number of events to retrieve </param>
        /// <param name="action"> action to take; see Remarks for details </param>
        /// <param name="min"> minimum value of the event type to be considered; <c>EventType.FirstEvent</c> is a safe choice </param>
        /// <param name="max"> maximum value of the event type to be considered; <c>EventType.LastEvent</c> is a safe choice </param>
        /// <returns>Returns the number of events actually stored or a negative error code on failure; 
        /// call <see cref="GetError()"/> for more information. </returns>
        unsafe int PeepEvents(Event * events, int count, EventAction action, EventType min, EventType max);

        /// <summary>
        /// Use this function to check for the existence of a range of event types in the event queue. 
        /// </summary>
        /// <param name="minType">the minimum type of event to be queried</param>
        /// <param name="maxType">the maximum type of event to be queried</param>
        /// <returns>Returns <c>true</c> if events with types in the range between minType and maxType are present, or <c>false</c> if not. </returns>
        bool HasEvents(int minType, int maxType);

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
