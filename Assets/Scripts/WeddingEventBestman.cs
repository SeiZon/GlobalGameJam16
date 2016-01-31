using UnityEngine;

namespace Assets.Scripts
{
    public class WeddingEventBestman : WeddingEvent
    {
        private AudioSource audioSource;
        private Vector3 orgRotation;

        protected override void Start()
        {
            eventType = EventData.WeddingEventType.Bestman;
            eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
            eventManager.SubscribeEvent(this);
            eventManager.OnEventBestmanStart += Activate;
            eventManager.OnEventBestmanInterrupt += Interrupt;
            audioSource = GetComponent<AudioSource>();
            orgRotation = transform.rotation.eulerAngles;
        }

        protected override void Update() {
            base.Update();
            if (audioSource.isPlaying) {

                transform.rotation = Quaternion.Euler(new Vector3(orgRotation.x, orgRotation.y - 75, orgRotation.z));
            }
            else {
                transform.rotation = Quaternion.Euler(orgRotation);
            }
        }

        void OnDisable()
        {
            eventManager.OnEventBestmanStart -= Activate;
            eventManager.OnEventBestmanInterrupt -= Interrupt;
        }

        public override void Activate()
        {
            base.Activate();
            Debug.Log("ACTIVATED Bestman!");
            audioSource.Play();
            //DO STUFF
        }

        public override void Interrupt()
        {
            base.Interrupt();
        }
    }
}
