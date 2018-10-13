using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SearchProvider.ISearch;

namespace SearchProvider.Search
{
	public class StartsWithSearchStrategy: ASearchStrategy
	{
		private static CurrentComparerDelegate comparer => StartsWithComparer;
		
		public IList<string> PerformSearch(string key)
		{
			IList<string> searchResult = base.PerformCommonSearch(comparer, key);
			return searchResult;
		}

		private static bool StartsWithComparer(string currentString, string key)
		{
			return currentString.StartsWith(key, StringComparison.CurrentCultureIgnoreCase);
		}
	}
}