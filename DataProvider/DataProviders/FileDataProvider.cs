using System;
using System.Configuration;
using System.IO;
using DataProvider.IDataProviders;

namespace DataProvider.DataProviders
{
	public class FileDataProvider: IDataProvider
	{
		private string _filePath;
		private StreamReader _reader;

		public FileDataProvider()
		{
			_filePath = GetDefaultFilePath();
		}

		public FileDataProvider(string filePath)
		{
			ValidatePath(filePath);
			_filePath = filePath;
		}

		public StreamReader Reader
		{
			get
			{
				if (_reader == null)
				{
					try
					{
						_reader = new StreamReader(FilePath);
					}
					catch (Exception ex)
					{
						throw ex;
					}
				}

				return _reader;
			}
		}
		
		public string FilePath
		{
			get
			{
				if (string.IsNullOrEmpty(_filePath))
				{
					_filePath = GetDefaultFilePath();
				}
				return _filePath;
			}
		}

		public string GetCurrentItem()
		{
			return Reader.ReadLine();	
		}
		
		private string GetDefaultFilePath()
		{
			var path = ConfigurationManager.AppSettings["DefaultFilePath"];
			ValidatePath(path);

			return path;
		}

		private void ValidatePath(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				throw new ArgumentNullException(path, "File Path is null");
			}
		}

		public void Dispose()
		{
			if (_reader != null)
			{
				_reader.Close();
				_reader = null;
			}
		}

		~FileDataProvider()
		{
			Dispose();
		}
	}
}