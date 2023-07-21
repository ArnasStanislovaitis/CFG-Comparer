using System.Collections.Generic;
using System.Linq;

namespace CGF_Comparer
{
    public class ResultsFilter
    {
        public IEnumerable<ModelCFG> FilterByID(List<ModelCFG> data, string id)
        {
            var filteredById = data.Where(x => x.ID.StartsWith(id)).Select(x => x);

            return filteredById;
        }
        public IEnumerable<ModelCFG> ComparisonResultFilter(List<ModelCFG> data, string filter)
        {
            var comparedResults = data.Where(x => x.Type == filter);

            return comparedResults;
        }
    }
}