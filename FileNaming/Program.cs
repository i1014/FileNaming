using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileNaming
{
    class Program
    {
        static void Main(string[] args)
        {
            FileNameUtility util = new FileNameUtility();

            string path = Directory.GetCurrentDirectory();

            Console.WriteLine("Enter the extension type");
            string ext = Console.ReadLine();
            
            var files = Directory.GetFiles(path);
                
            foreach(var file in files)
            {
                string temp = file.Substring(path.Length + 1);

                if (temp.Contains("File"))
                {
                    continue;
                }

                temp = temp.Replace('.', ' ');

                int date = util.FindDate(temp);
                    
                //Date Found
                if (date != 0)
                {
                    if ( util.FindDateWithParentheses(temp) != 0 )
                    {
                        var paren = util.FindDateWithParentheses(temp);
                        temp = temp.Substring(0, (paren + 6));
                    }
                    else
                    {
                        string upToDate = temp.Substring(0, date);
                        string dateString = temp.Substring(date, 4);
                        string concat = upToDate + "(" + dateString + ")";
                        temp = concat;
                    }
                        
                }

                Console.WriteLine(temp);
                var newPath = path + "\\output\\" + temp + ext;
                Directory.Move(file, newPath);
            }

            Console.ReadLine();
        }

        

    }
}
