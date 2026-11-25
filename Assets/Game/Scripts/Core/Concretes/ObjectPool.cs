using System;
using System.Collections.Generic;
namespace Core
{
    public sealed class ObjectPool<T> : IObjectPool<T>
    {
        private Stack<T> _elementStack = new();
        private Func<T> _createFunc;
        private Action<T> _onRent;
        private Action<T> _onReturn;
        public ObjectPool(Func<T> createFunc, Action<T> onRent, Action<T> onReturn, int prewarmQuantity = 100)
        {
            _onRent = onRent;
            _createFunc = createFunc;
            _onReturn = onReturn;
            Prewarm(prewarmQuantity);
        }
        public void Prewarm(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                T element = CreateElement();
                _elementStack.Push(element);
            }
        }

        public T Rent()
        {
            T element;
            if (_elementStack.Count == 0) element = _createFunc.Invoke();
            element =  _elementStack.Pop();
            _onRent?.Invoke(element);
            return element;
        }

        public void Return(T obj)
        {
            _onReturn?.Invoke(obj);
        }

        private T CreateElement()
        {
            return _createFunc.Invoke();
        }

    }
}

//_pool = new ObjectPool<CandyView>(
//            createFunc: () => Instantiate(_candyPrefab),
//            actionOnGet: (candy) => candy.gameObject.SetActive(true),
//            actionOnRelease: (candy) => candy.gameObject.SetActive(false),
//            actionOnDestroy: (candy) => Destroy(candy.gameObject),
//            defaultCapacity: _defaultCapacity,
//            maxSize: _maxSize
//        );