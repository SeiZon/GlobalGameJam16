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
        [SerializeField] private float minDrinkAmount = 5;
        [SerializeField] private float maxDrinkAmount = 70;
        private FillableGlass fillableGlass;

        protected override void Start()
        {
            eventType = EventData.WeddingEventType.Far;
            eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
            eventManager.SubscribeEvent(this);
            sideObjective = true;
            sipTimer = Random.Range(minSipTime, maxSipTime);
            fillableGlass = GameObject.FindGameObjectWithTag("Fillable").GetComponent<FillableGlass>();
            noDrinkTimer = noDrinkTime;
        }

        void Update()
        {
            if (true)
            {
                Debug.Log(sipTimer);
                if (!fillableGlass.isEmpty)
                {
                    sipTimer -= Time.deltaTime;
                    if (sipTimer <= 0)
                    {
                        SipDrink();
                        sipTimer = Random.Range(minSipTime, maxSipTime);
                    }
                }
                else
                {
                    noDrinkTimer -= Time.deltaTime;
                    if (noDrinkTimer <= 0)
                    {
                        eventManager.PlayEvent(eventType);
                        noDrinkTimer = noDrinkTime;
                        isRunning = false;
                    }
                }
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
            fillableGlass.Empty((Random.Range(minDrinkAmount, maxDrinkAmount)/100) * 1.2f);
        }
    }
}
