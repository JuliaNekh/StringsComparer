using System;
using System.Collections.Generic;
using DataProvider.IDataProviders;
using SearchProvider.ISearch;
using SearchProvider.IStrategy;

namespace SearchProvider.Search
{
	public class EndsWithSearchStrategy: ASearchStrategy, ISearchStrategy
	{
		public EndsWithSearchStrategy(IDataProvider dataProvider) : base(dataProvider)
		{
		}
		
		public IList<string> PerformSearch(string key)
		{
			IList<string> searchResult = PerformCommonSearch(EndsWithComparer, key);
			return searchResult;
		}

		private static bool EndsWithComparer(string currentString, string key)
		{
			return currentString.EndsWith(key, StringComparison.CurrentCultureIgnoreCase);
		}
	}
}