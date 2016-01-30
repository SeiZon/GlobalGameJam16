using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class EventManager : MonoBehaviour
    {
        public delegate void EventToastmasterStart();
        public event EventToastmasterStart OnEventToastmasterStart;
        public delegate void EventToastmasterInterrupt();
        public event EventToastmasterInterrupt OnEventToastmasterInterrupt;

        public delegate void EventSvigerfarStart();
        public event EventSvigerfarStart OnEventSvigerfarStart;
        public delegate void EventSvigerfarInterrupt();
        public event EventSvigerfarInterrupt OnEventSvigerfarInterrupt;

        public delegate void EventBestmanStart();
        public event EventBestmanStart OnEventBestmanStart;
        public delegate void EventBestmanInterrupt();
        public event EventBestmanInterrupt OnEventBestmanInterrupt;

        public delegate void EventBrudgomStart();
        public event EventBrudgomStart OnEventBrudgomStart;
        public delegate void EventBrudgomInterrupt();
        public event EventBrudgomInterrupt OnEventBrudgomInterrupt;

        private Dictionary<EventData.WeddingEventType, WeddingEvent> events;


        [HideInInspector]
        public float timeCounter;
    
        void Start()
        {
            timeCounter = 0;
            events = new Dictionary<EventData.WeddingEventType, WeddingEvent>();
        }

        void Update()
        {
            timeCounter += Time.deltaTime;

            foreach (int i in EventData.eventTimers)
            {
                if (i < timeCounter)
                {
                    EventData.WeddingEventType currentWeddingEventType = EventData.eventTiming[i];
                    if (events[currentWeddingEventType].hasBeenActivated)
                    {
                        continue;

                    }
                    else
                    {
                        events[currentWeddingEventType].Activate();
                    }
                }
            }
        }

        public void InterruptEvent(EventData.InterruptAction interruptAction)
        {
            if (EventData.eventsRunning[EventData.interruptActions[interruptAction]])
            {
                events[EventData.interruptActions[interruptAction]].Interrupt();
                EventData.InterruptEvent(interruptAction);
            }
        }

        public void PlayEvent(EventData.WeddingEventType eventType)
        {
            //Hook op til ting her
        }

    }
}
