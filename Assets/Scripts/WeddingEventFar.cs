using UnityEngine;

namespace Assets.Scripts
{
    public class WeddingEventFar : WeddingEvent
    {
        void Start()
        {
            eventType = EventData.WeddingEventType.Far;
            eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
            eventManager.SubscribeEvent(this);
            sideObjective = true;
        }

        public override void Activate()
        {
            base.Activate();
            Debug.Log("ACTIVATED Far!");
            //DO STUFF
        }

        public override void Interrupt()
        {
            base.Interrupt();
        }
    }
}
