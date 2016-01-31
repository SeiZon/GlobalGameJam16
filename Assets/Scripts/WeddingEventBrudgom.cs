using UnityEngine;

namespace Assets.Scripts
{
    public class WeddingEventBrudgom : WeddingEvent
    {
        private AudioSource audioSource;
        private Vector3 orgRotation;
        protected override void Start()
        {
            base.Start();
            eventType = EventData.WeddingEventType.Brudgom;
            eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
            eventManager.SubscribeEvent(this);
            eventManager.OnEventBrudgomStart += Activate;
            eventManager.OnEventBrudgomInterrupt += Interrupt;
            audioSource = GetComponent<AudioSource>();
            orgRotation = transform.rotation.eulerAngles;
        }

        protected override void Update()
        {
            base.Update();
            if (audioSource.isPlaying) {
                 
                transform.rotation = Quaternion.Euler(new Vector3(orgRotation.x , orgRotation.y + 90, orgRotation.z));
            }
            else {
                transform.rotation = Quaternion.Euler(orgRotation);
            }
        }

        void OnDisable()
        {
            eventManager.OnEventBrudgomStart -= Activate;
            eventManager.OnEventBrudgomInterrupt -= Interrupt;
            
        }

        public override void Activate()
        {
            base.Activate();
            Debug.Log("ACTIVATED BRUDGOM!");
            audioSource.Play();
            //DO STUFF
        }

        public override void Interrupt()
        {
            base.Interrupt();
        }
    }
}
