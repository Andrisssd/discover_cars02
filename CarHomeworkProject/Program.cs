using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarHomeworkProject
{
    internal class Program
    {
        private static string _path = @"C:\Users\Andri\source\repos\CarHomeworkProgram\CarHomeworkProject\Text.txt";
        static void Main(string[] args)
        {
            string[] wordsWithLengthMoreThan3 = TextManager.getWordsWithLengthMoreThan3(_path);
            
            Dictionary<string, CountAndPercent> combinationsAndCounts = TextManager.GetCombinationsFrom(wordsWithLengthMoreThan3);

            Dictionary<string, CountAndPercent> dictionaryToCompare = TextManager.GetDictionaryToCompareFrom(combinationsAndCounts);

            string table = TextManager.GetTable(dictionaryToCompare);

            Console.WriteLine();
            Console.WriteLine(table);
        }
    }
}
