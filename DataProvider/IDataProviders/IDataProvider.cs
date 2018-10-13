using System;

namespace DataProvider.IDataProviders
{
	public interface IDataProvider: IDisposable
	{
		string GetCurrentItem();
	}
}