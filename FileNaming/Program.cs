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

            Console.WriteLine("Menu:\n1) Movies\n2) Television");
            string type = Console.ReadLine();
            var t = Convert.ToInt32(type);

            var files = Directory.GetFiles(path);

            if(t == 1)
                Movies(files, path, util,ext);

            if (t == 2)
                Television(files, path, util, ext);

            
        }

        public static void Television(string[] files, string path, FileNameUtility util, string ext)
        {
            foreach (var file in files)
            {
                string temp = file.Substring(path.Length + 1);

                if (temp.Contains("File"))
                {
                    continue;
                }

                temp = temp.Replace('.', ' ');

                int episode = util.FindEpisode(temp);

                //Episode Location
                if (episode != 0)
                {
                    //Presumably the show.
                    string upToEpisode = temp.Substring(0, episode);

                    //Capitalize the show.
                    upToEpisode = util.CaptializeTitle(upToEpisode);

                    //Find the episode number.
                    string episodeString = temp.Substring(episode, 6);
                    episodeString = episodeString.ToUpper();

                    //Put it all together.
                    string concat = upToEpisode + episodeString;

                    //Pass it along.
                    temp = concat;
                }

                Console.WriteLine(temp);
                var newPath = path + "\\..\\output\\" + temp + ext;
                Directory.Move(file, newPath);
            }

            Console.ReadLine();
        }

        private static void Movies(string [] files, string path, FileNameUtility util, string ext)
        {
            foreach (var file in files)
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
                    if (util.FindDateWithParentheses(temp) != 0)
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
                var newPath = path + "\\..\\output\\" + temp + ext;
                Directory.Move(file, newPath);
            }

            Console.ReadLine();
        }

    }
}
