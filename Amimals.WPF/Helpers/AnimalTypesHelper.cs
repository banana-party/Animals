using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Animals.Core.Business.Bases;
using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using Animals.WPF.Services;

namespace Animals.WPF.Helpers
{
    internal class AnimalTypesHelper
    {
        public static IEnumerable<Type> GetAnimalTypes()
        {
            return Assembly.GetAssembly(typeof(AnimalBase))
                .GetTypes()
                .Where(x => x.IsClass && x.GetInterface(nameof(IAnimal)) != null && !x.IsAbstract);
        }

        //TODO: Переписать, с добавлением звука
        public static IAnimal GetAnimal(Type type)
        {
            string soundPath = "";
            switch (type.Name)
            {
       
            }

            return (IAnimal)Activator.CreateInstance(type);
        }
    }
}
