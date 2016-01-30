using UnityEngine;

namespace Assets.Scripts
{
    public class WeddingEventFar : WeddingEvent
    {
        private float noDrinkTime = 10;
        private float noDrinkTimer = 0;
        private float maxSipTime = 25;
        private float minSipTime = 5;
        private float sipTimer = 0;

        protected override void Start()
        {
            eventType = EventData.WeddingEventType.Far;
            eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
            eventManager.SubscribeEvent(this);
            sideObjective = true;
            sipTimer = Random.Range(minSipTime, maxSipTime);
        }

        void Update()
        {
            if (isRunning)
            {

                //is drink not empty?
                sipTimer -= Time.deltaTime;
                if (sipTimer <= 0)
                {
                    SipDrink();
                }

                //else if drink is empty
                //Count down timer
                //If timer reaches zero, run event
            }
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

        private void SipDrink()
        {
            //Take a drink
        }
    }
}
