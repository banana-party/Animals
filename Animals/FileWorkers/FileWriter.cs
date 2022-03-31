using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Console.FileWorkers
{
    public class FileWriter : IFileWriter
    {
        private StreamWriter _streamWriter;

        public void WriteToFile(IEnumerable<IAnimal> animals)
        {
            if (animals is null || !animals.Any())
                throw new ArgumentException("Argument is null or empty.");
            using (_streamWriter = new StreamWriter("Output.txt"))
            {
                foreach (var el in animals)
                    _streamWriter.WriteLine(el.ToString());
            }
        }
        public async Task WriteToFileAsync(IEnumerable<IAnimal> animals)
        {
            if (animals is null || !animals.Any())
                throw new ArgumentException("Argument is null or empty.");
            await using (_streamWriter = new StreamWriter("Output.txt"))
            {
                foreach (var el in animals)
                    await _streamWriter.WriteLineAsync(el.ToString());
            }
        }
    }
}
