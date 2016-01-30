using UnityEngine;

namespace Assets.Scripts
{
    public class WeddingEventToastmaster : WeddingEvent
    {

        void Start()
        {
            eventType = EventData.WeddingEventType.Toastmaster;
            eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
            eventManager.SubscribeEvent(this);
            eventManager.OnEventToastmasterStart += Activate;
            eventManager.OnEventToastmasterInterrupt += Interrupt;
        }

        void OnDisable()
        {
            eventManager.OnEventToastmasterStart -= Activate;
            eventManager.OnEventToastmasterInterrupt -= Interrupt;
        }

        public override void Activate()
        {
            base.Activate();
            Debug.Log("ACTIVATED Toastmaster!");
            //DO STUFF
        }

        public override void Interrupt()
        {
            base.Interrupt();
        }
    }
}
