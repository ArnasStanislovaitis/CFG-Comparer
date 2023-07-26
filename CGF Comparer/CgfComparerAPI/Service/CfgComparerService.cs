using CGF_Comparer;
using CgfComparerAPI.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System.Text.Json;
namespace CgfComparerAPI.Service
{
    public class CfgComparerService : ICfgComparerService
    {
        private static CfgModel allData = new ();
        private static Dictionary<string, string> sourceCfgDataDictionary = new();        
        
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

        public string[] GetTargetData(IFormFile file)
        {
            DataComparison comp = new DataComparison();
            ReadCFG readCFG = new ReadCFG();
            var path = ReadFile2(file);

            if (string.IsNullOrEmpty(path))
            {
                return default;
            }
            var stringData = readCFG.ReadCFGFile(path);
            allData.TargetInformation = readCFG.GetFileInformation(stringData);            
            allData.ComparisonResults = comp.GetComparedData(stringData, sourceCfgDataDictionary);

            return allData.TargetInformation;
        }
        public string[] GetSourceData(IFormFile file)
        {
            ReadCFG readCFG = new ReadCFG();
            var path = ReadFile2(file);

            if(string.IsNullOrEmpty(path))
            {
                return default;
            }
            var stringData = readCFG.ReadCFGFile(path);
            allData.SourceInformation = readCFG.GetFileInformation(stringData);            
            sourceCfgDataDictionary = readCFG.GetSourceFileValues(stringData);

            return allData.SourceInformation;           
        }
        public string ReadFile2(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return string.Empty;
            }
            var tempPath = Path.GetTempFileName();

            using (var stream = new FileStream(tempPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return tempPath;
        }

        public string FilterById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return default;
            } 
            ResultsFilter resultsFilter = new ();
            var results = resultsFilter.FilterByID(allData.ComparisonResults, id);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(results, options);

            return jsonString;
        }
        public IEnumerable<ModelCFG>? FilterByResult(string filter)
        {     
            ResultsFilter resultsFilter = new ();
            var results = resultsFilter.ComparisonResultFilter(allData.ComparisonResults,filter);            

            if (results == null || !results.Any())
            {
                return default;
            }                      

            return results;
        }
        public IEnumerable<ModelCFG> FilterByResultAndId(string id, string[] filters)
        {
            ResultsFilter resultsFilter = new();
            var results = allData.ComparisonResults?.Where(x => filters.Contains(x.Type)).ToList();

            if(string.IsNullOrEmpty(id) && results.Any())
            {
                return results;
            }
            var filteredResults = resultsFilter.FilterByID(results, id);
            
            if (filteredResults == null || !filteredResults.Any())
            {
                return default;
            }

            return filteredResults;
        }
    }
}