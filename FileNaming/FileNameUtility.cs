using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNaming
{
    public class FileNameUtility
    {


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
