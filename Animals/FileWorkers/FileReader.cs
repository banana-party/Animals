using Animals.Core.FileParsers;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Animals.Console.FileWorkers
{
    class FileReader : IFileReader
    {
        private StreamReader _stream;
        private readonly IAnimalParser _animalParser; // TODO: IAnimalParser или IFromFileParser? Парсеры одинаковые, есть ли смысл разделять интерфейсы?
        public FileReader(IAnimalParser animalParser)
        {
            _animalParser = animalParser;
        }


        public IEnumerable<IAnimal> Read(string path)
        {
            /*Лучше всего использовать конструкцию using и тогда не хранить приватное поле потока, либо открывать поток
             в конструкторе или каком-то методе типо Open и закрывать его в соответствующем методе и реализовывать
			IDisposable параллельно, а сейчас это смсешивание двух возможных подходов*/
            if (string.IsNullOrEmpty(path))
                throw new NullReferenceException("String was null or empty.");
            using (_stream = new StreamReader(path))
            {
                List<IAnimal> animals = new List<IAnimal>();
                while (!_stream.EndOfStream)
                {
                    var txt = _stream.ReadLine();
                    List<string> lst = txt.Split(',').ToList();
                    animals.Add(_animalParser.Parse(lst));
                }
                return animals;
            }

        }
    }
}
