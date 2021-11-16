using System;
using System.Collections.Generic;
using System.IO;

namespace BaseCourseExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Word> wordsList = new List<Word>();
            List<string> textList = new List<string>();
            Dictionary<string, int> wordsDictionary = new Dictionary<string, int>();

            try
            {
                Console.WriteLine("Please enter a path to file");
                string filePath = Console.ReadLine();
                bool inputCorrect = File.Exists(filePath) && Path.GetExtension(filePath) == ".txt";
                if (inputCorrect)
                    textList = WordHandler.fileRead(filePath);

                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Incorrect file input");
            }

            WordHandler.fillListAndDictionary(textList, ref wordsDictionary, ref wordsList);

            WordHandler.printDublicats(wordsDictionary);

            while (true)
            {
                WordHandler.printWordPositions(wordsList);
            }


        }
    }
}
