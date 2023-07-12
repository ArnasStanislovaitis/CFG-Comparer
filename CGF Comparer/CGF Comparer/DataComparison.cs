using System.Collections.Generic;
using System.Linq;

namespace CGF_Comparer
{
    public class DataComparison
    {
        List<ModelCFG> allData = new List<ModelCFG>();
        readonly Dictionary<string, string> targetKeyValuePairs = new Dictionary<string, string>();
        public List<ModelCFG> GetComparedData(string[] IdValuePair, Dictionary<string, string> sourceKeyValues)
        {
            CompareFiles(IdValuePair, sourceKeyValues);
            AddValuesNotInTarget(sourceKeyValues);

            return allData;
        }
        public void CompareFiles(string[] IdValuePair, Dictionary<string,string> sourceKeyValues) {            

            for (int i = 6; i < IdValuePair.Length - 1; i++)
            {                
                targetKeyValuePairs.Add(IdValuePair[0], IdValuePair[1]);

                if (sourceKeyValues.ContainsKey(IdValuePair[0]) && sourceKeyValues[IdValuePair[0]] == IdValuePair[1])
                {
                    allData.Add(new ModelCFG
                    {
                        ID = IdValuePair[0],
                        SourceValue = IdValuePair[1],
                        TargetValue = IdValuePair[1],
                        Type = "unchanged"
                    });                    
                }
                else if (sourceKeyValues.ContainsKey(IdValuePair[0]) && sourceKeyValues[IdValuePair[0]] != IdValuePair[1])
                {
                    allData.Add(new ModelCFG
                    {
                        ID = IdValuePair[0],
                        SourceValue = sourceKeyValues[IdValuePair[0]],
                        TargetValue = IdValuePair[1],
                        Type = "modified"

                    });                    
                }
                else if (!sourceKeyValues.ContainsKey(IdValuePair[0]))
                {
                    allData.Add(new ModelCFG
                    {
                        ID = IdValuePair[0],
                        TargetValue = IdValuePair[1],
                        Type = "added"
                    });                    
                }
            }
        }
        public void AddValuesNotInTarget(Dictionary<string, string> sourceKeyValues)
        {
            var keysNotInTarget = sourceKeyValues.Except(targetKeyValuePairs);

            foreach (var keyValuePair in keysNotInTarget)
            {
                allData.Add(new ModelCFG
                {
                    ID = keyValuePair.Key,
                    TargetValue = keyValuePair.Value,
                    Type = "removed"
                });
            }
        }
    }
}