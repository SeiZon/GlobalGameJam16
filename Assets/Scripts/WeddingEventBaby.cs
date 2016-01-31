using UnityEngine;

namespace Assets.Scripts
{
    public class WeddingEventBaby : WeddingEvent
    {
        private float cryTimer = 0;
        [SerializeField] private float maxCryTime = 25;
        [SerializeField] private float minCryTime = 5;
        [SerializeField] private float silenceTime = 20;
        private AudioSource audioSource;
        private float currentVolume = 100;
        private float silenceTimer = 0;


        protected override void Start()
        {
            base.Start();
            eventType = EventData.WeddingEventType.Baby;
            eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
            eventManager.SubscribeEvent(this);
            sideObjective = true;
            audioSource = GetComponent<AudioSource>();
        }

        protected override void Update() {
            base.Update();
            if (isRunning)
            {
                cryTimer -= Time.deltaTime;
                if (cryTimer < 5)
                {
                    audioSource.volume = cryTimer/5;
                }
                else
                {
                    audioSource.volume = 100;
                }

                if (cryTimer <= 0)
                {
                    audioSource.Stop();
                    silenceTimer = silenceTime;
                }
            }
            else
            {
                silenceTimer -= Time.deltaTime;
                if (silenceTimer <= 0)
                {
                    isRunning = false;
                    //eventManager.PlayEvent(eventType);
                }
            }
        }

        public override void Activate()
        {
            base.Activate();
            Debug.Log("ACTIVATED Baby!");
            audioSource.Play();
            audioSource.loop = true;
            cryTimer = Random.Range(minCryTime, maxCryTime);
        }

        public override void Interrupt()
        {
            base.Interrupt();
        }
    }
}
