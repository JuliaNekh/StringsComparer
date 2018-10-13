using System.Collections.Generic;

namespace SearchProvider.ISearch
{
	public interface ISearchStrategy
	{
		IList<string> PerformSearch(string key);
	}
}