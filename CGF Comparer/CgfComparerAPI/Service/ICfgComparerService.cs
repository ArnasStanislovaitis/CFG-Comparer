using CGF_Comparer;

namespace CgfComparerAPI.Service
{
    public interface ICfgComparerService
    {
        public string GetComparedData();
        //public string[] ReadFile(IFormFile file);
        public string ReadFile2(IFormFile file);
        public Dictionary<string, string> GetSourceData(IFormFile file);
        public void GetTargetData(IFormFile file);
        public IEnumerable<ModelCFG> FilterById(string id);
        public IEnumerable<ModelCFG> FilterByResult(string filter);
    }
}