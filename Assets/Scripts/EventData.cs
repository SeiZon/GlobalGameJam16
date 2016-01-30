﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class EventData
    {

        public static EventData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventData();
                    return instance;
                }
                else return instance;
            } 
            
        }

        private static EventData instance;

        public Dictionary<WeddingEventType, bool> eventsRunning = new Dictionary<WeddingEventType, bool>()
        {
            { WeddingEventType.Toastmaster, false },
            { WeddingEventType.Brudgom, false },
            { WeddingEventType.Svigerfar, false },
            { WeddingEventType.Bestman, false },
            { WeddingEventType.Far, false },
            { WeddingEventType.Baby, false },
            { WeddingEventType.Music, false }

        };

        public Dictionary<InterruptAction, WeddingEventType> interruptActions = new Dictionary<InterruptAction, WeddingEventType>()
        {
            {InterruptAction.Uninterruptable, WeddingEventType.Toastmaster},
            {InterruptAction.Waiter, WeddingEventType.Brudgom},
            {InterruptAction.Cake, WeddingEventType.Svigerfar},
            {InterruptAction.Røgalarm, WeddingEventType.Bestman},
            {InterruptAction.PourDrink, WeddingEventType.Far},
            {InterruptAction.Baby, WeddingEventType.Baby},
            {InterruptAction.Music, WeddingEventType.Music}

        };

        public Dictionary<int, WeddingEventType> eventTiming;

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

        public EventData() {
            eventTiming = new Dictionary<int, WeddingEventType>()
            {
                {eventTimers[0], WeddingEventType.Toastmaster },
                {eventTimers[1], WeddingEventType.Brudgom },
                {eventTimers[2], WeddingEventType.Svigerfar },
                {eventTimers[3], WeddingEventType.Bestman }
            };
        }


        public int[] eventTimers =
        {
            0, 10, 120, 180
        };

        public int GetEventTimer(WeddingEventType type)
        {
            return eventTimers[(int)type];
        }

        public void InterruptEvent(InterruptAction interruptActionDone)
        {

            if (eventsRunning[interruptActions[interruptActionDone]])
            {
                eventsRunning[interruptActions[interruptActionDone]] = false;
            }
            
        }

    }
}