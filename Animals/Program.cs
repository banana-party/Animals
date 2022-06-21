using Animals.Console.FileWorkers;
using Animals.Console.Services;
using Animals.Core.Business;

namespace Animals.Console
{
    class Program
    {
        static ConsoleMenuService menuService;
        static Zoo zoo;
        static void Main(string[] args)
        {
            JsonFileReader jsonFileReader = new JsonFileReader();
            jsonFileReader.Read("input.json");


            //zoo = new Zoo();
            //menuService = new ConsoleMenuService(zoo);
            //menuService.PerformAction();
        }

    }
}
