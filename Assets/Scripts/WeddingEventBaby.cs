using UnityEngine;

namespace Assets.Scripts
{
    public class WeddingEventBaby : WeddingEvent
    {
        private EventManager eventManager;

        void Start()
        {
            eventType = EventData.WeddingEventType.Baby;
            eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
            eventManager.SubscribeEvent(this);
        }

        void OnDisable()
        {
        }

        public override void Activate()
        {
            base.Activate();
            Debug.Log("ACTIVATED Baby!");
            //DO STUFF
        }

        public override void Interrupt()
        {
            base.Interrupt();
        }
    }
}
