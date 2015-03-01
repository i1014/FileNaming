using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileNaming
{
    public class FileNameUtility
    {
        public string CaptializeTitle(string input)
        {
            var result = Regex.Replace(input, @"\b(\w)", m => m.Value.ToUpper());
            result = Regex.Replace(result, @"\s(of|in|by|and)\s", m => m.Value.ToLower(), RegexOptions.IgnoreCase);
        
            return result;
        }

        public int FindEpisode(string input)
        {
            var temp = System.Text.RegularExpressions.Regex.Match(input, @"(?i)s\d{2}e\d{2}");

            if (System.Text.RegularExpressions.Regex.IsMatch(input, @"(?i)s\d{2}e\d{2}"))
            {
                if (!temp.ToString().Equals("1080"))
                    return temp.Index;
            }

            return 0;
        }

        public int FindDate(string input)
        {
            var temp = System.Text.RegularExpressions.Regex.Match(input, @"\d{4}");
            
            if (System.Text.RegularExpressions.Regex.IsMatch(input, @"\d{4}"))
            {
                if (!temp.ToString().Equals("1080"))
                    return temp.Index;
            }

            return 0;
        }

        public int FindDateWithParentheses(string input)
        {
            var temp = System.Text.RegularExpressions.Regex.Match(input, @"\(\d{4}\)");

            if (System.Text.RegularExpressions.Regex.IsMatch(input, @"\(\d{4}\)"))
            {
                if (!temp.ToString().Equals("(1080)"))
                    return temp.Index;
            }

            return 0;
        }


    }
}
