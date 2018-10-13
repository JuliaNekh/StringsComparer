using System;
using System.Configuration;
using System.IO;
using DataProvider.IDataProviders;

namespace DataProvider.DataProviders
{
	public class FileDataProvider: IDataProvider
	{
		private static string _filePath;
		private static StreamReader _reader;

		public FileDataProvider()
		{
			_filePath = GetDefaultFilePath();
		}

		public FileDataProvider(string filePath)
		{
			ValidatePath(filePath);
			_filePath = filePath;
		}

		public static StreamReader Reader
		{
			get
			{
				if (_reader == null)
				{
					_reader = new StreamReader(FilePath);
				}

				return _reader;
			}
		}
		
		public static string FilePath
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
		
		private static string GetDefaultFilePath()
		{
			var path = ConfigurationManager.AppSettings["DefaultFilePath"];
			ValidatePath(path);

			return path;
		}

		private static void ValidatePath(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				throw new ArgumentNullException(path, "Default File Path is null");
			}
		}

		public void Dispose()
		{
			_reader.Close();
			_reader = null;
		}
	}
}