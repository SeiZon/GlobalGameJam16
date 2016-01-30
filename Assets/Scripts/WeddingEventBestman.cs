using UnityEngine;

namespace Assets.Scripts
{
    public class WeddingEventBestman : WeddingEvent
    {

        void Start()
        {
            eventType = EventData.WeddingEventType.Bestman;
            eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
            eventManager.SubscribeEvent(this);
            eventManager.OnEventBestmanStart += Activate;
            eventManager.OnEventBestmanInterrupt += Interrupt;
        }

        void OnDisable()
        {
            eventManager.OnEventBestmanStart -= Activate;
            eventManager.OnEventBestmanInterrupt -= Interrupt;
        }

        public override void Activate()
        {
            base.Activate();
            Debug.Log("ACTIVATED Bestman!");
            //DO STUFF
        }

        public override void Interrupt()
        {
            base.Interrupt();
        }
    }
}
