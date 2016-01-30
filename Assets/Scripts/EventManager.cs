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

        private Dictionary<EventData.WeddingEventType, WeddingEvent> events = new Dictionary<EventData.WeddingEventType, WeddingEvent>();


        [HideInInspector]
        public float timeCounter;

        public bool eventCurrentlyPlaying = false;

        EventData eventData = EventData.Instance;

        void Update() {
            timeCounter += Time.deltaTime;

            foreach (KeyValuePair<EventData.WeddingEventType, bool> pair in eventData.eventsRunning)
            {
                eventCurrentlyPlaying = pair.Value;
            }

            foreach (int i in eventData.eventTimers)
            {
                if (i < timeCounter)
                {
                    EventData.WeddingEventType currentWeddingEventType = eventData.eventTiming[i];

                    if (events[currentWeddingEventType].hasBeenActivated)
                    {
                        continue;
                    }
                    else
                    {
                        if (events[currentWeddingEventType].eventType == EventData.WeddingEventType.Brudgom)
                        {
                            OnEventBrudgomStart();
                        }
                        //events[currentWeddingEventType].Activate();
                    }
                }
            }
            /*
            if (Input.GetKeyUp(KeyCode.A))
            {
                OnEventBestmanInterrupt();
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                OnEventBrudgomInterrupt();
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                OnEventSvigerfarInterrupt();
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                OnEventToastmasterInterrupt();
            }
            */
        }

        public void InterruptEvent(EventData.InterruptAction interruptAction)
        {
            if (eventData.eventsRunning[eventData.interruptActions[interruptAction]])
            {
                events[eventData.interruptActions[interruptAction]].Interrupt();
                eventData.InterruptEvent(interruptAction);
            }
        }

        public void PlayEvent(EventData.WeddingEventType eventType)
        {
            //Hook op til ting her
        }

        public void SubscribeEvent(WeddingEvent weddingEvent)
        {
            events.Add(weddingEvent.eventType, weddingEvent);
        }

        
    }
}
