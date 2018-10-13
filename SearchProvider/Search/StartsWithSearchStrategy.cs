using System;
using System.Collections.Generic;
using SearchProvider.ISearch;

namespace SearchProvider.Search
{
	public class StartsWithSearchStrategy: ASearchStrategy
	{
		private static CurrentComparerDelegate CurrentComparer => StartsWithComparer;
		
		public IList<string> PerformSearch(string key)
		{
			IList<string> searchResult = PerformCommonSearch(CurrentComparer, key);
			return searchResult;
		}

		private static bool StartsWithComparer(string currentString, string key)
		{
			return currentString.StartsWith(key, StringComparison.CurrentCultureIgnoreCase);
		}
	}
}