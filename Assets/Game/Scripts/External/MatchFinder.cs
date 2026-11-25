
using System;
using System.Collections;
using System.Collections.Generic;

namespace Utils 
{
    public static class MatchFinder
    {
        private static int[] _cachedMatchIndexArray = new int[1000];
        private static int _cachedMatchIndexCount = 0;
        public static ReadOnlySpan<int> FindMatchIndexes(ReadOnlySpan<int> grid)
        {
            _cachedMatchIndexCount = 0;
            //
            return _cachedMatchIndexArray;
        }

    }
}