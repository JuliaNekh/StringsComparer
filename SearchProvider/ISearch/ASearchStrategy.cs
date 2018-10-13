using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using DataProvider.DataProviders;
using DataProvider.IDataProviders;

namespace SearchProvider.ISearch
{
	public abstract class ASearchStrategy
	{
		public delegate bool CurrentComparerDelegate(string currentString, string key);

		private static IDataProvider DataProvider => new FileDataProvider();

		protected IList<string> PerformCommonSearch(CurrentComparerDelegate compareItems, string key)
		{
			IList<string> searchResult = new List<string>();

			using (DataProvider) {
				
				string currentString;
				while ((currentString = DataProvider.GetCurrentItem()) != null)
				{
					if (compareItems(currentString, key))
					{
						searchResult.Add(currentString);
					}
				}
			}

			if (searchResult.Any()) return searchResult;
			
			//if tthere are no matches
			string noMatchesSign = ConfigurationManager.AppSettings["NoMathchesSign"] ?? "-";
			searchResult.Add(noMatchesSign);

			return searchResult;
		}
	}
}