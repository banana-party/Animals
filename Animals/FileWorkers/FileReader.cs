using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Animals.Console.FileWorkers
{
    public class FileReader : IFileReader
    {
        private readonly IAnimalParser _animalParser;
        public FileReader(IAnimalParser animalParser)
        {
            _animalParser = animalParser;
        }

        public IEnumerable<IAnimal> Read(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new NullReferenceException("String was null or empty.");

            using var stream = new StreamReader(path);
            List<IAnimal> animals = new List<IAnimal>();

            while (!stream.EndOfStream)
                animals.Add(_animalParser.Parse(stream.ReadLine()?.Split(',')));
            
            return animals;
        }
    }
}
