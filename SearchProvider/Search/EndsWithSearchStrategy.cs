using System;
using System.Collections.Generic;
using SearchProvider.ISearch;
using SearchProvider.IStrategy;

namespace SearchProvider.Search
{
	public class EndsWithSearchStrategy: ASearchStrategy, ISearchStrategy
	{
		private static CurrentComparerDelegate CurrentComparer => EndsWithComparer;
		
		public IList<string> PerformSearch(string key)
		{
			IList<string> searchResult = PerformCommonSearch(CurrentComparer, key);
			return searchResult;
		}

		private static bool EndsWithComparer(string currentString, string key)
		{
			return currentString.EndsWith(key, StringComparison.CurrentCultureIgnoreCase);
		}
	}
}