using System;
using System.Collections.Generic;
using System.Linq;

namespace CGF_Comparer
{
    public class Counter
    {
        public void DisplayResultsCount(List<ModelCFG> data)
        {
            var unchangedCount = data.Where(x => x.Type == "unchanged").Count();
            var addedCount = data.Where(x => x.Type == "added").Count();
            var modifiedCount = data.Where(x => x.Type == "modified").Count();
            var removedCount = data.Where(x => x.Type == "removed").Count();          

            Console.WriteLine($"Unchanged: {unchangedCount} Added: {addedCount} Modified: {modifiedCount} Removed:{removedCount}");
        }
    }
}