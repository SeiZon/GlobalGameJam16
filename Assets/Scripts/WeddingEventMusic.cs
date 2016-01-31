using UnityEngine;

namespace Assets.Scripts
{
    public class WeddingEventMusic : WeddingEvent
    {
        private AudioSource audioSource;
        [SerializeField] private float maxPlayTime = 25;
        [SerializeField] private float minPlayTime = 5;
        [SerializeField] private float silenceTime = 20;
        private float playTimer = 0;
        private float silenceTimer = 0;

        [SerializeField] private ParticleSystem particles;
        [SerializeField] private Animator animator;


        protected override void Start() {
            base.Start();
            eventType = EventData.WeddingEventType.Music;
            eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
            eventManager.SubscribeEvent(this);
            sideObjective = true;
            audioSource = GetComponent<AudioSource>();
            
        }

        protected override void Update() {
            base.Update();
            if (isRunning)
            {
                SetActive(true);
                playTimer -= Time.deltaTime;
                if (playTimer <= 0)
                {
                    audioSource.Stop();
                    SetActive(false);
                    silenceTimer = silenceTime;
                }
            }
            else
            {
                SetActive(false);
                silenceTimer -= Time.deltaTime;
                if (silenceTimer <= 0) {
                    isRunning = false;
                    eventManager.PlayEvent(eventType);
                }
            }
        }

        public override void Activate()
        {
            base.Activate();
            Debug.Log("ACTIVATED Music!");
            playTimer = Random.Range(minPlayTime, maxPlayTime);
            audioSource.Play();
        }

        public override void Interrupt()
        {
            base.Interrupt();
        }

        void OnCollisionEnter(Collision col) {
            if (col.other.gameObject.tag == "Throwable") {
                Activate();
            }

        }

        void SetActive(bool isActive)
        {
            animator.enabled = isActive;
            particles.gameObject.SetActive(isActive);

        }
    }
}
