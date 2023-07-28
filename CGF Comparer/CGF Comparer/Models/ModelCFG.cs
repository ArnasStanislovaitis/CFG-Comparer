using System.Collections.Generic;

namespace CGF_Comparer.Models
{
    public class ModelCFG
    {
        public ModelCFG() { }
        public string ID { get; set; }
        public string SourceValue { get; set; } = string.Empty;
        public string TargetValue { get; set; } = string.Empty;
        public ResultsType Type { get; set; }
    }
    public class FileMetaInfo
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }
    public class CfgModel
    {
        public List<FileMetaInfo> SourceMetaInfo { get; set; }
        public List<FileMetaInfo> TargetMetaInfo { get; set; }
        public List<ModelCFG> ComparedData { get; set; } = new();

    }
}