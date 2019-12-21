using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calder1
{
	/// <summary>
	/// Record of Calder1 repository
	/// </summary>
	class Calder1Record
	{
		internal string Kind { get; set; }
		internal string URL { get; set; }
		internal string Title { get; set; }
		internal string Date { get; set; }
		internal string Author { get; set; }
		internal string Language { get; set; }
		internal string Labels { get; set; }
		internal string Keywords { get; set; }
		internal string Favorite { get; set; }

		internal void CopyData(Calder1Record r)
		{
			Kind = r.Kind;
			URL = r.URL;
			Title = r.Title;
			Date = r.Date;
			Author = r.Author;
			Language = r.Language;
			Labels = r.Labels;
			Keywords = r.Keywords;
			Favorite = r.Favorite;
		}

		/// <summary>
		/// Case insensitive contains
		/// </summary>
		/// <param name="fields"></param>
		/// <returns></returns>
		internal bool Contains(string[] fields)
		{
			if (fields == null) return true;
			int tmp;

			for (int i = 0; i < fields.Length; i++)
			{
				string f = fields[i];

				//manages syntax >yyyy <yyyy to filter by year
				bool greater = f.StartsWith(">");
				if ((greater || f.StartsWith("<")) && int.TryParse(f.Substring(1), out tmp))
				{
					if (f.Length == 5) //>yyyy
					{
						DateTime d2 = DateTime.Parse(Date);
						if (greater)
						{
							DateTime d = DateTime.Parse("31/12/" + f.Substring(1));
							if (d < d2) continue;
						}
						else
						{
							DateTime d = DateTime.Parse("01/01/" + f.Substring(1));
							if (d > d2) continue;
						}
					}

				}

				if (URL.ToLower().Contains(f) || Title.ToLower().Contains(f) || Labels.ToLower().Contains(f))
					continue;

				return false;
			}

			return true;
		}

		internal bool IsFavorite()
		{
			return Favorite == Calder1Repository.FAVORITE;
		}

	}
}
