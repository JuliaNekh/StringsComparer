using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SearchProvider.Search;

namespace SearchProvider.ISearch
{
	public abstract class ASearchStrategy
	{
		public delegate bool CurrentComparerDelegate(string currentString, string key);

		protected virtual IList<string> PerformCommonSearch(CurrentComparerDelegate comparison, string key)
		{
			IList<string> searchResult = new List<string>();
			string noMatchesSign = "-";
			using (StreamReader reader = new StreamReader("../../../Test.txt"))
			{
				string currentString;
				while ((currentString = reader.ReadLine()) != null)
				{
					if (comparison(currentString, key))
					{
						searchResult.Add(currentString);
					}
				}
			}

			if (!searchResult.Any())
			{
				searchResult.Add(noMatchesSign);
			}
			
			return searchResult;
		}
	}
}