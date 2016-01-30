using UnityEngine;

namespace Assets.Scripts
{
    public class WeddingEvent : MonoBehaviour
    {
        public bool hasBeenActivated;
        public bool isRunning;
        [SerializeField] private AudioClip[] speechAudio;
        [SerializeField] private AudioClip[] interruptAudio;
        public EventData.WeddingEventType eventType;

        public virtual void Activate()
        {
            if (hasBeenActivated || isRunning) return;
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
