using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SearchProvider.ISearch;

namespace SearchProvider.Search
{
	public class EqualsSearchStrategy: ASearchStrategy
	{
		private CurrentComparerDelegate comparer => EqualsComparer;
		
		public IList<string> PerformSearch(string key)
		{
			
			IList<string> searchResult = base.PerformCommonSearch(comparer, key);
			return searchResult;
		}

		private static bool EqualsComparer(string currentString, string key)
		{
			return currentString.Equals(key, StringComparison.CurrentCultureIgnoreCase);
		}
	}
}