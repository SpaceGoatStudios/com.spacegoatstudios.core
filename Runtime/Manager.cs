using UnityEngine;

namespace SpacegoatStudios.Core
{
    public class Manager<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region Private Variables

        private static T _instance;

        #endregion

        #region Properties

        public bool Persistent { get; set; }

        public static T Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                _instance = FindObjectOfType<T>();

                if (_instance == null)
                {
                    GameObject obj = new()
                    {
                        name = typeof(T).Name
                    };

                    _instance = obj.AddComponent<T>();
                }

                if (_instance.GetComponent<Manager<T>>().Persistent)
                {
                    DontDestroyOnLoad(_instance.gameObject);
                }

                return _instance;
            }
        }

        #endregion

        #region MonoBehaviour Methods

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;

                if (_instance != null && _instance.GetComponent<Manager<T>>().Persistent)
                {
                    DontDestroyOnLoad(_instance.gameObject);
                }
            }

            else
            {
                Destroy(gameObject);
            }
        }

        #endregion
    }
}