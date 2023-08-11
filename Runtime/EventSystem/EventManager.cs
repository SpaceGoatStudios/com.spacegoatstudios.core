using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpacegoatStudios.Core
{
    [DefaultExecutionOrder(-1001)]
    public class EventManager : MonoBehaviour
    {
        #region Public Variables

        public static EventManager Instance;

        #endregion

        #region Private Variables

        private Dictionary<string, List<Event>> _events = new();

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }

            else
            {
                Destroy(gameObject);
            }
        }

        #endregion

        #region Public Methods

        public void Push(string eventName, params object[] arguments)
        {
            if (!_events.ContainsKey(eventName))
            {
                return;
            }

            List<KeyValuePair<string, List<Event>>> events = _events.Where(x => x.Key == eventName).ToList();

            foreach (Event eventValue in events.Select(myEvent => myEvent.Value.ToList())
                         .SelectMany(eventValues => eventValues))
            {
                eventValue?.Invoke(arguments);
            }
        }

        public void Register(string eventName, Event eventValue)
        {
            List<Event> events;

            if (!_events.ContainsKey(eventName))
            {
                events = new List<Event> { eventValue };
                
                _events.Add(eventName, events);
            }

            else
            {
                events = _events[eventName];
                events.Add(eventValue);
            }
        }
        
        public void Unregister(string eventName, Event eventValue)
        {
            List<Event> events = _events[eventName];

            if (events.Count > 0)
            {
                events.Remove(eventValue);
            }

            if (events.Count == 0)
            {
                _events.Remove(eventName);
            }
        }

        #endregion
    }
}