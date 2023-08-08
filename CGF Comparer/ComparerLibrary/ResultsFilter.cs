using System.Collections.Generic;
using System.Linq;
using ComparerLibrary;

namespace CFG_Comparer
{
    public class ResultsFilter
    {
        public IEnumerable<DataComparisonItem> FilterByID(List<DataComparisonItem> data, string id)
        {
            var filteredById = data.Where(x => x.ID.StartsWith(id)).Select(x => x);

            return filteredById;
        }
        public IEnumerable<DataComparisonItem> ComparisonResultFilter(List<DataComparisonItem> data, ResultsType filter)
        {
            var comparedResults = data.Where(x => x.Type == filter);

            return comparedResults;
        }
    }
}