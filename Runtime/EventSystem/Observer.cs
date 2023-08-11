using UnityEngine;

namespace SpacegoatStudios.Core
{
    public class Observer : MonoBehaviour
    {
        #region Properties

        public EventManager Manager => EventManager.Instance;

        #endregion

        #region MonoBehaviour Methods

        protected virtual void OnEnable()
        {
            
        }

        protected virtual void OnDisable()
        {
            
        }

        #endregion

        #region Inherit Methods

        protected virtual void Observe(bool status)
        {
            
        }

        protected virtual void Push(string eventName, params object[] arguments)
        {
            Manager.Push(eventName, arguments);
        }

        protected virtual void Register(string eventName, Event @event)
        {
            Manager.Register(eventName, @event);
        }

        protected virtual void Unregister(string eventName, Event @event)
        {
            Manager.Unregister(eventName, @event);
        }

        #endregion
    }
}