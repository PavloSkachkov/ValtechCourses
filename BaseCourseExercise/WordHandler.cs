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

        public static void fillListAndDictionary(List<string> textList, Dictionary<string, int> wordsDictionary, List<Word> wordsList)
        {
            char[] separators = { ' ', ',', '.', ':', '–', '\t', '\n' };
            int lineCounter = 0;
            int positionCounter = 0;
            foreach (string sentence in textList)
            {
                lineCounter++;
                string[] words = sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    if (!wordsDictionary.ContainsKey(word))
                    {
                        wordsDictionary.Add(word, 1);
                    }
                    else
                    {
                        wordsDictionary[word] += 1;
                    }

                    positionCounter++;
                    Word currentWord = new Word(word, lineCounter, positionCounter);
                    wordsList.Add(currentWord);
                }
            }
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
