using UnityEngine;

namespace Assets.Scripts
{
    public class WeddingEventBrudgom : WeddingEvent
    {
        void Start()
        {
            eventType = EventData.WeddingEventType.Brudgom;
            eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
            eventManager.SubscribeEvent(this);
            eventManager.OnEventBrudgomStart += Activate;
            eventManager.OnEventBrudgomInterrupt += Interrupt;
        }

        void OnDisable()
        {
            eventManager.OnEventBrudgomStart -= Activate;
            eventManager.OnEventBrudgomInterrupt -= Interrupt;
        }

        public override void Activate()
        {
            base.Activate();
            Debug.Log("ACTIVATED BRUDGOM!");
            //DO STUFF
        }

        public override void Interrupt()
        {
            base.Interrupt();
        }
    }
}
