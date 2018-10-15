using System.Collections.Generic;
using DataProvider.IDataProviders;

namespace SearchProvider.ISearch
{
	public abstract class ASearchStrategy
	{
		public delegate bool CurrentComparerDelegate(string currentString, string key);

		private IDataProvider _dataProvider;

		public ASearchStrategy(IDataProvider dataProvider)
		{
			_dataProvider = dataProvider;
		}
		
		protected IList<string> PerformCommonSearch(CurrentComparerDelegate compareItems, string key)
		{
			IList<string> searchResult = new List<string>();

			using (_dataProvider) {
				
				string currentString;
				while ((currentString = _dataProvider.GetCurrentItem()) != null)
				{
					if (compareItems(currentString, key))
					{
						searchResult.Add(currentString);
					}
				}
			}

			return searchResult;
		}
	}
}