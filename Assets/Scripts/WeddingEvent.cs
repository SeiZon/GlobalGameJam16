using UnityEngine;

namespace Assets.Scripts
{
    public class WeddingEvent : MonoBehaviour
    {
        public bool hasBeenActivated;
        public bool isRunning;
        public bool sideObjective;
        protected EventManager eventManager;
        [SerializeField] private AudioClip[] speechAudio;
        [SerializeField] private AudioClip[] interruptAudio;
        public EventData.WeddingEventType eventType;

        protected virtual void Start()
        {
            eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
        }

        public virtual void Activate()
        {
            if ((hasBeenActivated || isRunning) && !sideObjective) return;
            if (eventManager.eventCurrentlyPlaying) return;
            else hasBeenActivated = true;
            isRunning = true;

            //Freeze controls 
            //Begin playing speech sound
        }

        public virtual void Interrupt()
        {
            isRunning = false;
            //Stop talking and play interrupt sound ("Øhh... Skål!")
        }
        
    }
}
