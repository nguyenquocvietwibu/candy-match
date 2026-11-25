
using System;

namespace Models
{
    public class Grid
    {
        private readonly int _collumnCount;
        private readonly int[] _elementIdArray;
        private int _elementIdCount = 0;
        public int ElementCount => _elementIdCount;

        public Grid(int intitialRowCount = 10, int initialCollumnCount = 10)
        {
            _elementIdArray = new int[intitialRowCount * initialCollumnCount];
            _collumnCount = initialCollumnCount;
        }
        public ReadOnlySpan<int> AsReadOnlySpan()
        {
            return _elementIdArray.AsSpan(0, _collumnCount);
        }
        public bool TryGetElementId(int rowPosition, int collumnPosition, out int result)
        {
            result = _elementIdArray[GetElementIdIndex(rowPosition, collumnPosition)];
            return result != 0;
        }
        public void SetElementId(int rowPosition, int columnPosition, int newElementId)
        {
            int elementIdIndex = GetElementIdIndex(rowPosition, columnPosition);
            int oldElementId = _elementIdArray[elementIdIndex];

            if (oldElementId == newElementId) return;

            _elementIdArray[elementIdIndex] = newElementId;

            bool isOldIdEmpty = oldElementId == 0;
            bool isNewIdEmpty = newElementId == 0;

            if (isOldIdEmpty && !isNewIdEmpty)
            {
                _elementIdCount++;
                return;
            }
            if (!isOldIdEmpty && isNewIdEmpty)
            {
                _elementIdCount--;
                return;
            }
        }
        private int GetElementIdIndex(int rowPosition, int collumnPosition)
        {
            return rowPosition * _collumnCount + collumnPosition;
        }
        public void Clear()
        {
            for (int i = _elementIdCount - 1; i >= 0; i--)
            {
                _elementIdArray[i] = 0;
                _elementIdCount--;
            }
            Utils.Debugger.Log("Grid element id count: " + _elementIdCount);
        }
    }
}

