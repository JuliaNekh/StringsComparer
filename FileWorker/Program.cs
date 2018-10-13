using System;
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
					ISearchStrategy	searchStrategy = new EndsWithSearchStrategy();
//					ISearchStrategy	searchStrategy = new StartsWithSearchStrategy();
//					ISearchStrategy	searchStrategy = new WholeWordSearchStrategy();

					var result = searchStrategy.PerformSearch(key);
					Console.WriteLine("Search results: ");
					foreach (var match in result)
					{
						Console.WriteLine(match);
					}
				}
				Console.WriteLine("Enter new key: ");
				key = Console.ReadLine();
			}
		}
	}
}
