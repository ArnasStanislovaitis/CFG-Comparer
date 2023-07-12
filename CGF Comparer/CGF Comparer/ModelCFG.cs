
namespace CGF_Comparer
{
    public class ModelCFG
    {
        public ModelCFG() { }
        public string ID { get; set; }
        public string SourceValue { get; set; } = string.Empty;
        public string TargetValue { get; set; } = string.Empty;
        public string Type { get; set; }
    }
}