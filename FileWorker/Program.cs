using System;
using System.Configuration;
using System.Linq;
using DataProvider.DataProviders;
using DataProvider.IDataProviders;
using SearchProvider.IStrategy;
using SearchProvider.Search;

namespace FileWorker
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("enter 'q' to exit");
			Console.WriteLine("Enter search key: ");
			var key = Console.ReadLine();
			while ( key != "q")
			{
				if (!string.IsNullOrEmpty(key))
				{
					ProcessKey(key);
				}
				Console.WriteLine("Enter new key: ");
				key = Console.ReadLine();
			}
		}

		private static void ProcessKey(string key)
		{
			IDataProvider dataProvider = new FileDataProvider();
			ISearchStrategy searchStrategy = new EndsWithSearchStrategy(dataProvider);
//			ISearchStrategy	searchStrategy = new StartsWithSearchStrategy(dataProvider);
//			ISearchStrategy	searchStrategy = new WholeWordSearchStrategy(dataProvider);

			var result = searchStrategy.PerformSearch(key);
			Console.WriteLine("Search results: ");

			if (!result.Any() || result.Count == 0)
			{
				string noMatchesSign = ConfigurationManager.AppSettings["NoMathchesSign"] ?? "-";
				Console.WriteLine(noMatchesSign);
			}
			else
			{
				Console.WriteLine($"Count of matches: {result.Count}");
				foreach (var match in result)
				{
					Console.WriteLine(match);
				}
			}
		}
	}
}
