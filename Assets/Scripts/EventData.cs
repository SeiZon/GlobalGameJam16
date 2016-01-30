using System.Collections.Generic;

namespace Assets.Scripts
{
    public class EventData
    {
        public static Dictionary<WeddingEventType, bool> eventsRunning = new Dictionary<WeddingEventType, bool>()
        {
            { WeddingEventType.Toastmaster, false },
            { WeddingEventType.Brudgom, false },
            { WeddingEventType.Svigerfar, false },
            { WeddingEventType.Bestman, false },
            { WeddingEventType.Far, false },
            { WeddingEventType.Baby, false },
            { WeddingEventType.Music, false }

        };

        public static Dictionary<InterruptAction, WeddingEventType> interruptActions = new Dictionary<InterruptAction, WeddingEventType>()
        {
            {InterruptAction.Uninterruptable, WeddingEventType.Toastmaster},
            {InterruptAction.Waiter, WeddingEventType.Brudgom},
            {InterruptAction.Cake, WeddingEventType.Svigerfar},
            {InterruptAction.Røgalarm, WeddingEventType.Bestman},
            {InterruptAction.PourDrink, WeddingEventType.Far},
            {InterruptAction.Baby, WeddingEventType.Baby},
            {InterruptAction.Music, WeddingEventType.Music}

        };

        public static Dictionary<int, WeddingEventType> eventTiming = new Dictionary<int, WeddingEventType>()
        {
            {eventTimers[0], WeddingEventType.Toastmaster },
            {eventTimers[1], WeddingEventType.Brudgom },
            {eventTimers[2], WeddingEventType.Svigerfar },
            {eventTimers[3], WeddingEventType.Bestman }

        };

        public enum WeddingEventType
        {
            Toastmaster = 0,
            Brudgom = 1,
            Svigerfar = 2,
            Bestman = 3,
            Far = 4,
            Baby = 5,
            Music = 6
        }

        public enum InterruptAction
        {
            Uninterruptable,
            Baby,
            Cake,
            Music,
            PourDrink,
            Waiter,
            Røgalarm
        }

        public static int[] eventTimers =
        {
            0, 60, 120, 180
        };

        public static int GetEventTimer(WeddingEventType type)
        {
            return eventTimers[(int)type];
        }

        public static void InterruptEvent(InterruptAction interruptActionDone)
        {

            if (eventsRunning[interruptActions[interruptActionDone]])
            {
                eventsRunning[interruptActions[interruptActionDone]] = false;
            }
            
        }

    }
}
