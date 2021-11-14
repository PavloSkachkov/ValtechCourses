using System;
using System.Collections.Generic;

namespace BaseCourseExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Word> wordsList = new List<Word>();
            List<string> textList = new List<string>();
            Dictionary<string, int> wordsDictionary = new Dictionary<string, int>();
            char[] separators = { ' ', ',', '.', ':', '–', '\t', '\n' };
            int lineCounter = 0;
            int positionCounter = 0;

            try
            {
                textList = WordHandler.fileRead(args[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            foreach (var sentence in textList)
            {
                lineCounter++;
                string[] words = sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
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

            WordHandler.printDublicats(wordsDictionary);

            while (true)
            {
                WordHandler.printWordPositions(wordsList);
            }


        }
    }
}
