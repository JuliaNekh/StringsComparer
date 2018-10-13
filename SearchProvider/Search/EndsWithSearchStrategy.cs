using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SearchProvider.ISearch;

namespace SearchProvider.Search
{
	public class EndsWithSearchStrategy: ASearchStrategy, ISearchStrategy
	{
		private static CurrentComparerDelegate comparer => EndsWithComparer;
		
		public IList<string> PerformSearch(string key)
		{
			IList<string> searchResult = PerformCommonSearch(comparer, key);
			return searchResult;
		}

		private static bool EndsWithComparer(string currentString, string key)
		{
			return currentString.EndsWith(key, StringComparison.CurrentCultureIgnoreCase);
		}
	}
}