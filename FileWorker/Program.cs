using System;
using System.IO;
using System.Linq;
using SearchProvider.ISearch;
using SearchProvider.Search;

namespace FileWorker
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("enter 'q' to exit");
			while (Console.ReadLine() != "q")
			{
				Console.WriteLine("Enter search key: ");
				var key = Console.ReadLine();
				if (!string.IsNullOrEmpty(key))
				{
					ISearchStrategy	searchStrategy = new EndsWithSearchStrategy();
//					ISearchStrategy	searchStrategy = new StartsWithSearchStrategy();
//					ISearchStrategy	searchStrategy = new WholeWordSearchStrategy();

					var result = searchStrategy.PerformSearch(key);
					foreach (var match in result)
					{
						Console.WriteLine(match);
					}
				}
			}
		}
	}
}
