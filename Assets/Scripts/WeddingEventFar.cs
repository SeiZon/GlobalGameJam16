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
        private Quaternion orgRotation;
        private bool isTalking = false;
        private AudioSource audioSource;

        protected override void Start()
        {
            eventType = EventData.WeddingEventType.Far;
            eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
            eventManager.SubscribeEvent(this);
            sideObjective = true;
            sipTimer = Random.Range(minSipTime, maxSipTime);
            fillableGlass = GameObject.FindGameObjectWithTag("Fillable").GetComponent<FillableGlass>();
            noDrinkTimer = noDrinkTime;
            orgRotation = transform.rotation;
            audioSource = GetComponent<AudioSource>();
            fillableGlass.isFilled += Interrupt;
        }

        protected override void Update()
        {
            base.Update();
            if (isRunning)
            {
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
                        audioSource.Play();
                        isTalking = true;
                        noDrinkTimer = noDrinkTime;
                        isRunning = false;
                    }
                }
            }
            if (isTalking)
            {
                transform.rotation = Quaternion.Euler(new Vector3(orgRotation.x - 90, orgRotation.y, orgRotation.z));

                if (!audioSource.isPlaying) Interrupt();
            }
            else transform.rotation = orgRotation;

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
            audioSource.Pause();
            isTalking = false;
        }

        private void SipDrink()
        {
            float asd = (Random.Range(minDrinkAmount, maxDrinkAmount)/100)*fillableGlass.maxContents;
            fillableGlass.Empty(fillableGlass.maxContents * 2);
        }
    }
}
