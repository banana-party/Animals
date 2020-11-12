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
			zoo = new Zoo();
			menuService = new ConsoleMenuService(zoo);
			menuService.PerformAction();
		}

	}
}
