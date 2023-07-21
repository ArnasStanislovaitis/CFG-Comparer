﻿using CGF_Comparer;

namespace CgfComparerAPI.Service
{
    public interface ICfgComparerService
    {
        public string GetComparedData();
        //public string[] ReadFile(IFormFile file);
        public string ReadFile2(IFormFile file);
        public Dictionary<string, string> GetSourceData(IFormFile file);
        public void GetTargetData(IFormFile file);
        public string FilterById(string id);
        public IEnumerable<ModelCFG>? FilterByResult(string filter);
        public IEnumerable<ModelCFG> FilterByResultAndId(string id, string[] filters);
    }
}