using CGF_Comparer;
using CgfComparerAPI.Models;
using System.Collections.Concurrent;
using System.Text.Json;
namespace CgfComparerAPI.Service
{
    public class CfgComparerService : ICfgComparerService
    {
        
        public string GetComparedData()
        {
            ReadCFG readCFG = new ReadCFG();
            DataComparison comp = new DataComparison();
            List<ModelCFG> comparedData = new();

            string path1 = @"C:\Users\iot3\Documents\GitHub\CFG-Comparer\CGF Comparer\CGF Comparer\Data\FMB001-default";
            string path2 = @"C:\Users\iot3\Documents\GitHub\CFG-Comparer\CGF Comparer\CGF Comparer\Data\FMB920-default";
            var sourceFileCfgData = readCFG.ReadCFGFile(path1);
            var targetFileCfgData = readCFG.ReadCFGFile(path2);
            var sourceCfgDataDictionary = readCFG.GetSourceFileValues(sourceFileCfgData);
            comparedData = comp.GetComparedData(targetFileCfgData, sourceCfgDataDictionary);            
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(comparedData, options);
            

            return jsonString;
        }
        public string GetSourceData(IFormFile file)
        {
            ReadCFG readCFG = new ReadCFG();
            DataComparison comp = new DataComparison();
            List<ModelCFG> comparedData = new();

            string path1 = @"C:\Users\iot3\Documents\GitHub\CFG-Comparer\CGF Comparer\CGF Comparer\Data\FMB001-default";
            string path2 = @"C:\Users\iot3\Documents\GitHub\CFG-Comparer\CGF Comparer\CGF Comparer\Data\FMB920-default";
            var sourceCfgStringData = ReadFile(file);
            var sourceCfgDataDictionary = readCFG.GetSourceFileValues(sourceCfgStringData);
            
                readCFG.GetFileInformation(sourceCfgStringData);
            
           
            
            //comparedData = comp.GetComparedData(targetFileCfgData, sourceCfgDataDictionary);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(comparedData, options);


            return jsonString;
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
