using CGF_Comparer;
using CgfComparerAPI.Models;
using System.Collections.Concurrent;
using System.Text.Json;
namespace CgfComparerAPI.Service
{
    public class CfgComparerService : ICfgComparerService
    {
        private static List<ModelCFG> allData = new();
        private static Dictionary<string, string> sourceCfgDataDictionary = new();
        public string GetComparedData()
        {            
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(allData, options);            

            return jsonString;
        }
        public void GetTargetData(IFormFile file)
        {
            DataComparison comp = new DataComparison();
            var targetCfgStringData = ReadFile(file);            
            allData = comp.GetComparedData(targetCfgStringData, sourceCfgDataDictionary);
        }
        public Dictionary<string,string> GetSourceData(IFormFile file)
        {
            ReadCFG readCFG = new ReadCFG();    
            var sourceCfgStringData = ReadFile(file);
            var sourceCfgDataDictionary = readCFG.GetSourceFileValues(sourceCfgStringData);  

            return sourceCfgDataDictionary;
        }

        public string[]? ReadFile(IFormFile file)
        {
            if(file.Length <= 0)
            {
                return default;
            }
            using(StreamReader sr = new(file.OpenReadStream()))
            {
                var fileString = sr.ReadToEnd().Split(";");

                return fileString;
            }            
        }
    }
}
