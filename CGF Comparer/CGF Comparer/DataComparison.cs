using System.Collections.Generic;
using System.Linq;
using CGF_Comparer.Models;

namespace CGF_Comparer
{
    public class DataComparison
    {
        private readonly List<ModelCFG> allData = new();
        private readonly Dictionary<string, string> sourceKeyValuePairs = new();
        private readonly Dictionary<string, string> targetKeyValuePairs = new();
        public List<ModelCFG> GetComparedData(string[] sourceIdValuePair, string[] targetIdValuePair )
        {
            GetSourceFileValues(sourceIdValuePair);
            CompareFiles(IdValuePair, sourceKeyValues);
            AddValuesNotInTarget(sourceKeyValues);

            return allData;
        }
        //IdValuePairs - 40100: 1
        private void CompareFiles(string[] IdValuePairs, Dictionary<string,string> sourceKeyValues) {            

            for (int i = 6; i < IdValuePairs.Length - 1; i++)
            {   
                var IdValuePair = IdValuePairs[i].Split(":");             
                targetKeyValuePairs.Add(IdValuePair[0], IdValuePair[1]);
                
                if (sourceKeyValues.ContainsKey(IdValuePair[0]) && sourceKeyValues[IdValuePair[0]] == IdValuePair[1])
                {
                    allData.Add(new ModelCFG
                    {
                        ID = IdValuePair[0],
                        SourceValue = IdValuePair[1],
                        TargetValue = IdValuePair[1],
                        Type = ResultsType.Unchanged
                    });                    
                }
                else if (sourceKeyValues.ContainsKey(IdValuePair[0]) && sourceKeyValues[IdValuePair[0]] != IdValuePair[1])
                {
                    allData.Add(new ModelCFG
                    {
                        ID = IdValuePair[0],
                        SourceValue = sourceKeyValues[IdValuePair[0]],
                        TargetValue = IdValuePair[1],
                        Type = ResultsType.Modified

                    });                    
                }
                else if (!sourceKeyValues.ContainsKey(IdValuePair[0]))
                {
                    allData.Add(new ModelCFG
                    {
                        ID = IdValuePair[0],
                        TargetValue = IdValuePair[1],
                        Type = ResultsType.Added
                    });                    
                }
            }
        }
        private void AddValuesNotInTarget(Dictionary<string, string> sourceKeyValues)
        {
            var keysNotInTarget = sourceKeyValues.Where(sourceKeys => !targetKeyValuePairs.ContainsKey(sourceKeys.Key));

            foreach (var keyValue in keysNotInTarget)
            {
                allData.Add(new ModelCFG
                {
                    ID = keyValue.Key,
                    TargetValue = keyValue.Value,
                    Type = ResultsType.Removed
                });
            }                     
        }
        public void GetSourceFileValues(string[] cfgData)
        {
            //Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            for (int i = 6; i < cfgData.Length - 1; i++)
            {

                var a = cfgData[i].Split(":");
                sourceKeyValuePairs.Add(a[0], a[1]);
            }            
        }
    }
}