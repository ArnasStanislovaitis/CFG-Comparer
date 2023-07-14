using System.Collections.Generic;
using System.Linq;

namespace CGF_Comparer
{
    public class ResultsFilter
    {
        IEnumerable<ModelCFG> FilterByID(List<ModelCFG> data, string id)
        {
            var filteredById = data.Where(x => x.ID.StartsWith(id)).Select(x => x);

            return filteredById;
        }
    }
}
