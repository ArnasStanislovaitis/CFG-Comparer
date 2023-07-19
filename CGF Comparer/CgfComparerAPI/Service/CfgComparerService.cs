using CGF_Comparer;
using CgfComparerAPI.Models;
using System.Text.Json;
namespace CgfComparerAPI.Service
{
    public class CfgComparerService : ICfgComparerService
    {
        private static CfgModel allData = new();
        private static Dictionary<string, string> sourceCfgDataDictionary = new();
        private static IEnumerable<ModelCFG> filteredData;
        
        public string GetComparedData()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(allData, options);

            return jsonString;
        }
        

        //                 VERSION 1
        /*
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
            sourceCfgDataDictionary = readCFG.GetSourceFileValues(sourceCfgStringData);  

            return sourceCfgDataDictionary;
        }
        public string[]? ReadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return default;
            }
            
            using (StreamReader sr = new(file.OpenReadStream()))
            {
                var fileString = sr.ReadToEnd().Split(";");

                 return fileString;
            }  
           
        }    
        */
        //            VERSION2

        public void GetTargetData(IFormFile file)
        {
            DataComparison comp = new DataComparison();
            ReadCFG readCFG = new ReadCFG();
            var path = ReadFile2(file);
            var stringData = readCFG.ReadCFGFile(path);
            allData.TargetInformation = readCFG.GetFileInformation(stringData);
            allData.TargetInformation[5] = file.FileName;
            allData.ComparisonResults = comp.GetComparedData(stringData, sourceCfgDataDictionary);
        }
        public Dictionary<string, string> GetSourceData(IFormFile file)
        {
            ReadCFG readCFG = new ReadCFG();
            var path = ReadFile2(file);
            var stringData = readCFG.ReadCFGFile(path);
            allData.SourceInformation = readCFG.GetFileInformation(stringData);
            allData.SourceInformation[5] = file.FileName;
            sourceCfgDataDictionary = readCFG.GetSourceFileValues(stringData);

            return sourceCfgDataDictionary;
        }
        public string ReadFile2(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return default;
            }
            var tempPath = Path.GetTempFileName();

            using (var stream = new FileStream(tempPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return tempPath;
        }

        public IEnumerable<ModelCFG> FilterById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return default;
            } 
            ResultsFilter resultsFilter = new ();
            var results = resultsFilter.FilterByID(allData.ComparisonResults, id);

            return results;
        }
        public IEnumerable<ModelCFG> FilterByResult(string filter)
        {            
            ResultsFilter resultsFilter = new ();
            var results = resultsFilter.ComparisonResultFilter(allData.ComparisonResults, filter);
            filteredData = results;            

            return filteredData;
        }
    }
}
