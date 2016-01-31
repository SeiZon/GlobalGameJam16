using UnityEngine;

namespace Assets.Scripts
{
    public class WeddingEventSvigerfar : WeddingEvent
    {
        private AudioSource audioSource;
        private Vector3 orgRotation;

        protected override void Start()
        {
            eventType = EventData.WeddingEventType.Svigerfar;
            eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
            eventManager.SubscribeEvent(this);
            eventManager.OnEventSvigerfarStart += Activate;
            eventManager.OnEventSvigerfarInterrupt += Interrupt;
            audioSource = GetComponent<AudioSource>();
            orgRotation = transform.rotation.eulerAngles;
        }

        void OnDisable()
        {
            eventManager.OnEventSvigerfarStart -= Activate;
            eventManager.OnEventSvigerfarInterrupt -= Interrupt;
        }

        protected override void Update() {
            base.Update();
            if (audioSource.isPlaying) {

                transform.rotation = Quaternion.Euler(new Vector3(orgRotation.x, orgRotation.y +45, orgRotation.z));
            }
            else {
                transform.rotation = Quaternion.Euler(orgRotation);
            }
        }
        public override void Activate()
        {
            base.Activate();
            Debug.Log("ACTIVATED Svigerfar!");
            audioSource.Play();
            //DO STUFF
        }

        public override void Interrupt()
        {
            base.Interrupt();
        }
    }
}
