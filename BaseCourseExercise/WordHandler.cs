using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCourseExercise
{
    public static class WordHandler
    {
        public static List<string> fileRead(string path)
        {
            List<string> textList = new List<string>();
            using (StreamReader myStreamReader = File.OpenText(path))
            {
                while (!myStreamReader.EndOfStream)
                {
                    textList.Add(myStreamReader.ReadLine().ToLower());
                }
            }

            return textList;
        }

        public static void printDublicats(Dictionary<string, int> wordsDictionary)
        {
            foreach (var word in wordsDictionary.OrderByDescending(word => word.Value))
            {
                Console.WriteLine(word.Key + " " + word.Value);
            }
        }

        public static void printWordPositions(List<Word> wordsList)
        {
            Console.WriteLine("Please enter a word from the list");
            string name = Console.ReadLine();
            foreach (var word in wordsList.Where(word => word.Name == name))
            {
                Console.WriteLine(word.ToString());
            }
        }
    }
}
