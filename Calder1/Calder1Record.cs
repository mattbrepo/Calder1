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
		/// <param name="fields">if it starts with a minor/major char is treated as a year, if it starts with a minus remove the records containing the following word</param>
        /// <param name="absents">fields that needs to be absent</param>
		/// <returns></returns>
        internal bool Contains(string[] fields, bool alsoDate, bool alsoNegative, bool matchCase, bool alsoURL, bool alsoTitle, bool alsoLabels, bool alsoKeywords)
		{
            if (fields == null || fields.Length == 0) return true;
			int tmp;

			for (int i = 0; i < fields.Length; i++)
			{
				string f = fields[i];

                if (alsoDate)
                {
                    // manages syntax >yyyy <yyyy to filter by year
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
                    else
                    {
                        if (Date.Contains(f))
                            continue;
                    }
                }

                if (alsoNegative)
                {
                    if (f.StartsWith("-"))
                    {
                        f = f.Substring(1);
                        if (ContainsRaw(f, matchCase, alsoURL, alsoTitle, alsoLabels, alsoKeywords))
                            return false;

                        continue;
                    }
                }

                if (ContainsRaw(f, matchCase, alsoURL, alsoTitle, alsoLabels, alsoKeywords))
					continue;

				return false;
			}

			return true;
		}

        private bool ContainsRaw(string field, bool matchCase, bool alsoURL, bool alsoTitle, bool alsoLabels, bool alsoKeywords)
        {
            if (!matchCase)
            {
                if (alsoURL)
                    if (URL.ToLower().Contains(field))
                        return true;

                if (alsoTitle)
                    if (Title.ToLower().Contains(field))
                        return true;

                if (alsoLabels)
                    if (Labels.ToLower().Contains(field))
                        return true;

                if (alsoKeywords)
                    if (Keywords.ToLower().Contains(field))
                        return true;

                return false;
            }

            if (alsoURL)
                if (URL.Contains(field))
                    return true;

            if (alsoTitle)
                if (Title.Contains(field))
                    return true;

            if (alsoLabels)
                if (Labels.Contains(field))
                    return true;

            if (alsoKeywords)
                if (Keywords.Contains(field))
                    return true;

            return false;
        }

		internal bool IsFavorite()
		{
			return Favorite == Calder1Repository.FAVORITE;
		}

        internal void InvertFavorite()
        {
            if (IsFavorite())
                Favorite = "";
            else
                Favorite = Calder1Repository.FAVORITE;
        }

	}
}
