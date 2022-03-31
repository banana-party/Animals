using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;

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
    }
}
