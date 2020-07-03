using FeeCalculator.CrossCutting.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using FeeCalculator.Data.Interfaces;
using FeeCalculator.Model;
using System.Reflection;
using System.IO;

namespace FeeCalculator.Data.Implementations
{
    public class SpecialJsonRepository : ISpecialRepository
    {
        public async Task<IEnumerable<Special>> SelectAllAsync()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = "\\JsonData\\special.json";
            var data = FileHelper.Read(assemblyPath + filePath);

            //var data = FileHelper.Read("C:\\GV_Personal\\Projects\\feecalculator\\src\\FeeCalculator.Data\\JsonData\\" + path);
            var result = JsonHelper.Deserialise<IEnumerable<Special>>(data);

            return result;
        }
    }
}

