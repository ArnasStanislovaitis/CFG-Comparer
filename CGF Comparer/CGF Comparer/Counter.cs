using System;
using System.Collections.Generic;
using System.Linq;
using CGF_Comparer.Models;

namespace CGF_Comparer
{
    public class Counter
    {
        public void DisplayResultsCount(List<DataComparisonItem> data)
        {
            var unchangedCount = data.Where(x => x.Type == ResultsType.Unchanged).Count();
            var addedCount = data.Where(x => x.Type == ResultsType.Added).Count();
            var modifiedCount = data.Where(x => x.Type == ResultsType.Modified).Count();
            var removedCount = data.Where(x => x.Type == ResultsType.Removed).Count();          

            Console.WriteLine($"Unchanged: {unchangedCount} Added: {addedCount} Modified: {modifiedCount} Removed:{removedCount}");
        }
    }
}