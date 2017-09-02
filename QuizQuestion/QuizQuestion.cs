using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizQuestion
{
    public static class QuizQuestion
    {
        public static int BiggestProduct(IList<int> arr, int k)
        {
            if (arr == null) throw new ArgumentNullException(nameof(arr));

            if (k < 0) throw new ArgumentException(nameof(k));

            if (k > arr.Count) throw new ArgumentOutOfRangeException(nameof(k));

            if (k == 0) return 0;

            var hasZero = arr.Contains(0);
            arr.Remove(0);

            var descendingList = arr.OrderByDescending(x => Math.Abs(x));
            var biggestList = descendingList.Take(k);
            var descendingProduct = biggestList.Aggregate(1, (x, y) => x * y);

            var ascendingList = arr.OrderBy(x => Math.Abs(x));
            var smallestList = ascendingList.Take(k);
            var ascendingProduct = smallestList.Aggregate(1, (x, y) => x * y);

            return hasZero ? Math.Max(Math.Max(descendingProduct, ascendingProduct), 0) : Math.Max(descendingProduct, ascendingProduct);
        }
    }
}
