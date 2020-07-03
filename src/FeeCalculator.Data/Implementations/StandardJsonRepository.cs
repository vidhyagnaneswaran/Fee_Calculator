using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using FeeCalculator.CrossCutting.Helpers;
using FeeCalculator.Data.Interfaces;
using FeeCalculator.Model;


namespace FeeCalculator.Data.Implementations
{
    public class StandardJsonRepository : IStandardRepository
    {
        public async Task<IEnumerable<Standard>> SelectAllAsync()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = "\\JsonData\\standard.json";
            var data = FileHelper.Read(assemblyPath + filePath);

            //var data = FileHelper.Read("C:\\GV_Personal\\Projects\\feecalculator\\src\\FeeCalculator.Data\\JsonData\\" + path);
            var result = JsonHelper.Deserialise<IEnumerable<Standard>>(data);

            return result;
        }
    }
}
