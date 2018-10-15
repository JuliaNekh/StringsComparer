using System;
using System.Collections.Generic;
using DataProvider.IDataProviders;
using SearchProvider.ISearch;

namespace SearchProvider.Search
{
	public class EqualsSearchStrategy: ASearchStrategy
	{
		public EqualsSearchStrategy(IDataProvider dataProvider) : base(dataProvider)
		{
		}
		
		public IList<string> PerformSearch(string key)
		{
			IList<string> searchResult = PerformCommonSearch(EqualsComparer, key);
			return searchResult;
		}

		private static bool EqualsComparer(string currentString, string key)
		{
			return currentString.Equals(key, StringComparison.CurrentCultureIgnoreCase);
		}
	}
}