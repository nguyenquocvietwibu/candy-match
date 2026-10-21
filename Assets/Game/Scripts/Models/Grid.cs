
using System;

namespace Model
{
    public class Grid
    {
        //private readonly int _rowCount;
        private readonly int _collumnCount;
        private readonly int[] _elementArray;
        private int _elementCount = 0;
        public int ElementCount => _elementCount;
        public Grid(int intitialRowCount = 10, int initialCollumnCount = 10)
        {
            _elementArray = new int[intitialRowCount * initialCollumnCount];
            //_rowCount = intitialRowCount;
            _collumnCount = initialCollumnCount;
        }

        public bool TryGetElement(int rowPosition, int collumnPosition, out int result)
        {
            result = _elementArray[GetElementIndex(rowPosition, collumnPosition)];
            return result != default;
        }
        public void AddElement(int rowPosition, int columnPosition, int element)
        {
            if (element == default) 
                throw new ArgumentNullException("The <element> value cannot be the default (0).");
            _elementArray[GetElementIndex(rowPosition, columnPosition)] = element;
            _elementCount++;
        }
        public void RemoveElement(int rowPosition, int columnPosition)
        {
            _elementArray[GetElementIndex(rowPosition, columnPosition)] = default;
            _elementCount--;
        }
        private int GetElementIndex(int rowPosition, int collumnPosition)
        {
            return rowPosition * _collumnCount + collumnPosition;
        }
        public void Clear()
        {
            for (int i = 0; i < _elementCount; i++)
            {
                _elementArray[i] = default;
            }
            _elementCount = 0;
        }
    }
}

