using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class EventManager : MonoBehaviour
    {
        [SerializeField] private float speechInterval = 90;
        [SerializeField] private OurClock.Clock clock;

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
        private EventData.WeddingEventType currentlyRunningEvent;

        [HideInInspector]
        public float timeCounter;

        public bool eventCurrentlyPlaying = false;

        EventData eventData = EventData.Instance;

        void Start()
        {
            timeCounter = speechInterval;
            
        }

        void Update() {
            timeCounter -= Time.deltaTime;

            foreach (KeyValuePair<EventData.WeddingEventType, bool> pair in eventData.eventsRunning)
            {
                eventCurrentlyPlaying = pair.Value;
            }

            
            if (timeCounter <= 0)
            {
                if (eventData.availableMainEvents.Count == 0) return;
                currentlyRunningEvent = eventData.availableMainEvents[Random.Range(0, eventData.availableMainEvents.Count-1)];
                
                if (events[currentlyRunningEvent].eventType == EventData.WeddingEventType.Brudgom) {
                    OnEventBrudgomStart();
                }
                if (events[currentlyRunningEvent].eventType == EventData.WeddingEventType.Bestman) {
                    OnEventBestmanStart();
                }
                if (events[currentlyRunningEvent].eventType == EventData.WeddingEventType.Svigerfar) {
                    OnEventSvigerfarStart();
                }
                timeCounter = speechInterval;
            }

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
            clock.clockSpeed = 0;
        }

        public void SubscribeEvent(WeddingEvent weddingEvent)
        {
            events.Add(weddingEvent.eventType, weddingEvent);
        }

        public void RemoveEvent(EventData.WeddingEventType eventToRemove)
        {
            eventData.availableMainEvents.Remove(eventToRemove);
        }
        
    }
}
