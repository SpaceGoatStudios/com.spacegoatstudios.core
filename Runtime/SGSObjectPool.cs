using System;
using System.Collections.Generic;

namespace SpacegoatStudios.Core
{
    public class SGSObjectPool<T>
    {
        #region Private Variables

        private readonly List<T> _currentStock;
        private readonly Func<T> _factoryMethod;
        private readonly bool _isDynamic;
        private readonly Action<T> _turnOnCallback;
        private readonly Action<T> _turnOffCallback;

        #endregion

        #region Constructor

        public SGSObjectPool(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback,
            int initialStock = 0, bool isDynamic = true)
        {
            _factoryMethod = factoryMethod;
            _isDynamic = isDynamic;

            _turnOnCallback = turnOnCallback;
            _turnOffCallback = turnOffCallback;

            _currentStock = new List<T>();

            for (int i = 0; i < initialStock; i++)
            {
                T o = _factoryMethod();
                _turnOffCallback(o);
                _currentStock.Add(o);
            }
        }

        #endregion

        #region Public Methods

        public T GetObject()
        {
            T result = default(T);

            if (_currentStock.Count > 0)
            {
                result = _currentStock[0];
                _currentStock.RemoveAt(0);
            }
            
            else if (_isDynamic)
            {
                result = _factoryMethod();
            }
            
            _turnOnCallback(result);

            return result;
        }

        public void ReturnObject(T o)
        {
            _turnOffCallback(o);
            _currentStock.Add(o);
        }

        #endregion
    }
}