namespace CgfComparerAPI.Service
{
    public interface ICfgComparerService
    {
        string GetComparedData();
        public string[]? ReadFile(IFormFile file);
        public Dictionary<string, string> GetSourceData(IFormFile file);
        public void GetTargetData(IFormFile file);
    }
}