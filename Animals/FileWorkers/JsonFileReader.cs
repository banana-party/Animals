using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Animals.Console.Services;
using Animals.Console.Services.Creators;
using Animals.Core.Business.Bases;
using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Animals.Console.FileWorkers
{
    internal class JsonFileReader : IFileReader
    {

        public IEnumerable<IAnimal> Read(string path)
        {

            string json = File.ReadAllText(path);

            var lst = JsonConvert.DeserializeObject<List<IAnimal>>(json, new AnimalConverter());



            return null;

        }
    }

    public class AnimalConverter : Converter<IAnimal>
    {
        IFactory f = ConsoleFactory.Factory ?? ConsoleFactory.CreateFactory(new ConsoleReaderService(), new ConsoleDialogService());
        protected override IAnimal Create(Type objectType, JObject jObject)
        {
            if (FieldExists("Cat", jObject))
            {
                //var cat = f.CreateAnimal("Cat");

                var cat = jObject["Cat"].ToObject<Cat>();
                return cat;
            }

            return null;
        }

        private bool FieldExists(string fieldName, JObject jObject)
        {
            return jObject[fieldName] != null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public abstract class Converter<T> : JsonConverter
    {
        protected abstract T Create(Type objectType, JObject jObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override bool CanWrite => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject
            T target = Create(objectType, jObject);

            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }
    }
}
