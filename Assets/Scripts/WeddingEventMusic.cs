using UnityEngine;

namespace Assets.Scripts
{
    public class WeddingEventMusic : WeddingEvent
    {
        void Start()
        {
            eventType = EventData.WeddingEventType.Music;
            eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
            eventManager.SubscribeEvent(this);
            sideObjective = true;
        }


        public override void Activate()
        {
            base.Activate();
            Debug.Log("ACTIVATED Music!");
            //DO STUFF
        }

        public override void Interrupt()
        {
            base.Interrupt();
        }
    }
}
