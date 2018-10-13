using System.Collections.Generic;

namespace SearchProvider.IStrategy
{
	public interface ISearchStrategy
	{
		IList<string> PerformSearch(string key);
	}
}