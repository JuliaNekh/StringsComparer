using System;
using System.Collections.Generic;
using DataProvider.IDataProviders;
using SearchProvider.ISearch;

namespace SearchProvider.Search
{
	public class StartsWithSearchStrategy: ASearchStrategy
	{
		public StartsWithSearchStrategy(IDataProvider dataProvider) : base(dataProvider)
		{
		}
		
		public IList<string> PerformSearch(string key)
		{
			IList<string> searchResult = PerformCommonSearch(StartsWithComparer, key);
			return searchResult;
		}

		private static bool StartsWithComparer(string currentString, string key)
		{
			return currentString.StartsWith(key, StringComparison.CurrentCultureIgnoreCase);
		}
	}
}