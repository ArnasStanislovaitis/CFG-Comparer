using System.Collections.Generic;
using System.Linq;

namespace ComparerLibrary
{
    public class DataComparison
    {
        private readonly CfgModel _allCfgData = new();
        private readonly Dictionary<string, string> _sourceKeyValuePairs = new();
        private readonly Dictionary<string, string> _targetKeyValuePairs = new();     
        
        public CfgModel GetComparedData(string[] sourceCfgFile, string[] targetCfgFile)
        {
            GetSourceFileValues(sourceCfgFile);
            CompareFiles(_sourceKeyValuePairs, targetCfgFile);
            AddValuesNotInTarget(_sourceKeyValuePairs);
            
            return _allCfgData;
        }
        //IdValuePairs - 40100: 1
        private void CompareFiles(Dictionary<string,string> sourceKeyValues, string[] targetCfgFile) {            

            for (int i = 0; i < targetCfgFile.Length - 1; i++)
            {   
                var targetKeyValue = targetCfgFile[i].Split(":");             
                _targetKeyValuePairs.Add(targetKeyValue[0], targetKeyValue[1]);

                if (IsFileMetaInfo(targetKeyValue))
                {
                    _allCfgData.TargetMetaInfo.Add(new FileMetaInfo
                    {
                        ID = targetKeyValue[0],
                        Value = targetKeyValue[1]
                    });
                }
                else if (sourceKeyValues.ContainsKey(targetKeyValue[0]) && sourceKeyValues[targetKeyValue[0]] == targetKeyValue[1])
                {
                    _allCfgData.ComparedData.Add(new DataComparisonItem
                    {
                        ID = targetKeyValue[0],
                        SourceValue = targetKeyValue[1],
                        TargetValue = targetKeyValue[1],
                        Type = ResultsType.Unchanged
                    });                    
                }
                else if (sourceKeyValues.ContainsKey(targetKeyValue[0]) && sourceKeyValues[targetKeyValue[0]] != targetKeyValue[1])
                {
                    _allCfgData.ComparedData.Add(new DataComparisonItem
                    {
                        ID = targetKeyValue[0],
                        SourceValue = sourceKeyValues[targetKeyValue[0]],
                        TargetValue = targetKeyValue[1],
                        Type = ResultsType.Modified

                    });                    
                }
                else if (!sourceKeyValues.ContainsKey(targetKeyValue[0]))
                {
                    _allCfgData.ComparedData.Add(new DataComparisonItem
                    {
                        ID = targetKeyValue[0],
                        TargetValue = targetKeyValue[1],
                        Type = ResultsType.Added
                    });                    
                }
            }
        }
        private void AddValuesNotInTarget(Dictionary<string, string> sourceKeyValues)
        {
            var keysNotInTarget = sourceKeyValues.Where(sourceKeys => !_targetKeyValuePairs.ContainsKey(sourceKeys.Key));
            
            foreach (var keyValue in keysNotInTarget)
            {                
                _allCfgData.ComparedData.Add(new DataComparisonItem
                {
                    ID = keyValue.Key,
                    TargetValue = keyValue.Value,
                    Type = ResultsType.Removed
                });
            }                     
        }
        private void GetSourceFileValues(string[] sourceCfgFile)
        {            
            for (int i = 0; i < sourceCfgFile.Length - 1; i++)
            {                
                var keyValue = sourceCfgFile[i].Split(":");

                if (IsFileMetaInfo(keyValue))
                {
                    _allCfgData.SourceMetaInfo.Add(new FileMetaInfo
                    {
                        ID = keyValue[0],
                        Value = keyValue[1]
                    });
                }
                else
                {
                    _sourceKeyValuePairs.Add(keyValue[0], keyValue[1]);
                }
                
            }            
        }
        private bool IsFileMetaInfo(string[] cfgKeyValue)
        {
            if (!int.TryParse(cfgKeyValue[0], out int o))
            {      
                return true;
            }

            return false;
        }        
    }
}