using CGF_Comparer.Models;

namespace CgfComparerAPI.Service
{
    public interface ICfgComparerService
    {
        public string GetComparedData();
        //public string[] ReadFile(IFormFile file);
        public string ReadFile2(IFormFile file);
        public string[] GetSourceData(IFormFile file);
        public string[] GetTargetData(IFormFile file);
        public string FilterById(string id);
        public IEnumerable<DataComparisonItem>? FilterByResult(string filter);
        public IEnumerable<DataComparisonItem> FilterByResultAndId(string id, string[] filters);
    }
}