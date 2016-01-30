using UnityEngine;

namespace Assets.Scripts
{
    public class WeddingEventSvigerfar : WeddingEvent
    {
        private EventManager eventManager;

        void Start()
        {
            eventType = EventData.WeddingEventType.Svigerfar;
            eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
            eventManager.SubscribeEvent(this);
            eventManager.OnEventSvigerfarStart += Activate;
            eventManager.OnEventSvigerfarInterrupt += Interrupt;
        }

        void OnDisable()
        {
            eventManager.OnEventSvigerfarStart -= Activate;
            eventManager.OnEventSvigerfarInterrupt -= Interrupt;
        }

        public override void Activate()
        {
            base.Activate();
            Debug.Log("ACTIVATED Svigerfar!");
            //DO STUFF
        }

        public override void Interrupt()
        {
            base.Interrupt();
        }
    }
}
