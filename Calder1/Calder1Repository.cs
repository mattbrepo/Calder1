using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace Calder1
{
	/// <summary>
	/// Repository manager
	/// </summary>
	class Calder1Repository
	{
		#region const
		//--- repository file constant
        public const string KW_NEW_LINE = "+NL+";
		public const char CSV_SEP = ';';
		private const string HEADER = "kind;url;title;date_start;author;lang;labels;keywords;favorite";
		public const string FAVORITE = "*";
		public const string KIND_DOC = "doc";
		public const string KIND_BOOKMARK = "url";
        public const string DATETIME_FORMAT = "dd/MM/yyyy";

		private const int COL_KIND = 0;
		private const int COL_URL = 1;
		private const int COL_TITLE = 2;
		private const int COL_DATE = 3;
		private const int COL_AUTHOR = 4;
		private const int COL_LANGUAGE = 5;
		private const int COL_LABELS = 6;
		private const int COL_KEYWORDS = 7;
		private const int COL_FAVORITE = 8;
		#endregion

		#region private
		private string _csvFilePath;
		private string _dirPath;
		private Encoding _itaEncoding = Encoding.GetEncoding(1252);
		#endregion

		#region prop
		public List<Calder1Record> Content { get; set; }
		public string CSVFilePath { get { return _csvFilePath; } }
		public string DirPath { get { return _dirPath; } }
		#endregion

		#region ctor
		public Calder1Repository(string repoFilePath)
		{
			string[] lines = File.ReadAllLines(repoFilePath);
			_csvFilePath = lines[0];
			_dirPath = lines[1];
		}
		
		#endregion

		#region public
		/// <summary>
		/// Open repository csv file
		/// </summary>
		/// <returns></returns>
		public bool Open()
		{
			try
			{
				string[] lines = File.ReadAllLines(_csvFilePath, _itaEncoding);
				Content = lines.Skip(1).Select(item => CreateRecord(item.Split(CSV_SEP))).ToList<Calder1Record>();
				return true;
			}
			catch (Exception ex)
			{
				ex.ToString();
				return false;
			}
		}

		/// <summary>
		/// Save repository file
		/// </summary>
		public bool Save()
		{
			try
			{
				List<string> lines = this.Content.Select(item => CreateCSVLine(item)).ToList<string>();
				lines.Insert(0, HEADER);
				File.WriteAllLines(_csvFilePath, lines, _itaEncoding);
				return true;
			}
			catch (Exception ex)
			{
				ex.ToString();
				return false;
			}
		}

		/// <summary>
		/// Gets a Record filepath
		/// </summary>
		/// <param name="r"></param>
		/// <returns></returns>
		internal string GetRecordPath(Calder1Record r)
		{
			if (r.Kind == KIND_BOOKMARK) return null;
			return Path.Combine(_dirPath, Path.GetFileName(r.URL));
		}

		/// <summary>
		/// Is the filename present in the repository
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		internal bool HasFile(string fileName)
		{
			fileName = fileName.ToLower();
			return (Content.FindIndex(x => Path.GetFileName(x.URL).ToLower() == fileName) >= 0);
		}
		#endregion

		#region private
		/// <summary>
		/// Create a record from fields
		/// </summary>
		/// <param name="fields"></param>
		/// <returns></returns>
		private Calder1Record CreateRecord(string[] fields)
		{
			Calder1Record res = new Calder1Record();
			try
			{
				res.Kind = fields[COL_KIND];
				res.URL = fields[COL_URL].Replace("\"", "");
				res.Title = fields[COL_TITLE];
				res.Date = fields[COL_DATE];
				res.Author = fields[COL_AUTHOR];
				res.Language = fields[COL_LANGUAGE];
				res.Labels = fields[COL_LABELS];
				res.Keywords = fields[COL_KEYWORDS];
				res.Favorite = fields[COL_FAVORITE];
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return res;
		}

		/// <summary>
		/// Create a CSV line
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		private string CreateCSVLine(Calder1Record item)
		{
			return item.Kind + CSV_SEP + item.URL + CSV_SEP + item.Title + CSV_SEP + item.Date + CSV_SEP + item.Author + CSV_SEP + item.Language + CSV_SEP + item.Labels + CSV_SEP + item.Keywords + CSV_SEP + item.Favorite;
		}

		#endregion



	}
}
