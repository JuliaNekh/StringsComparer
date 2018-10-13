using System;
using System.Collections.Generic;
using SearchProvider.ISearch;

namespace SearchProvider.Search
{
	public class EqualsSearchStrategy: ASearchStrategy
	{
		private CurrentComparerDelegate CurrentComparer => EqualsComparer;
		
		public IList<string> PerformSearch(string key)
		{
			IList<string> searchResult = PerformCommonSearch(CurrentComparer, key);
			return searchResult;
		}

		private static bool EqualsComparer(string currentString, string key)
		{
			return currentString.Equals(key, StringComparison.CurrentCultureIgnoreCase);
		}
	}
}