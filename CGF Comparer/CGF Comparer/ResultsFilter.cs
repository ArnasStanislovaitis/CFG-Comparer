using System.Collections.Generic;
using System.Linq;
using CGF_Comparer.Models;

namespace CGF_Comparer
{
    public class ResultsFilter
    {
        public IEnumerable<ModelCFG> FilterByID(List<ModelCFG> data, string id)
        {
            var filteredById = data.Where(x => x.ID.StartsWith(id)).Select(x => x);

            return filteredById;
        }
        public IEnumerable<ModelCFG> ComparisonResultFilter(List<ModelCFG> data, ResultsType filter)
        {
            var comparedResults = data.Where(x => x.Type == filter);

            return comparedResults;
        }
    }
}