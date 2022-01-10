using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary
{
    public static class TextManager
    {
        public static string[] getWordsWithLengthMoreThan3(string path)
        {
            string fullPath = Path.GetFullPath(path);
            string fullText = File.ReadAllText(fullPath);
            char[] onlyLettersArray = fullText.ToCharArray().Where(el => Char.IsLetter(el) || el == ' ').ToArray();
            string onlyLetterText = string.Join("", onlyLettersArray).ToLower();
            string[] wordsWithLengthMoreThan3 = onlyLetterText.Split(' ').Where(el => el.Length >= 3).ToArray();
            return wordsWithLengthMoreThan3;
        }

        public static Dictionary<string,CountAndPercent> GetCombinationsFrom(string[] wordsWithLengthMoreThan3)
        {
            Dictionary<string, CountAndPercent> combinationsAndCounts = new Dictionary<string, CountAndPercent>();
            int totalCombinations = 0;

            foreach (var word in wordsWithLengthMoreThan3)
            {
                for (int i = 0; i <= word.Length - 3; i++)
                {
                    for (int j = 3; j <= word.Length - i; j++)
                    {
                        string combination = word.Substring(i, j);
                        if (combinationsAndCounts.ContainsKey(combination))
                        {
                            totalCombinations++;
                            combinationsAndCounts[combination].Count++;
                        }
                        else
                        {
                            totalCombinations++;
                            combinationsAndCounts.Add(combination, new CountAndPercent());
                        }
                    }
                }
            }

            foreach (var keyValue in combinationsAndCounts)
            {
                keyValue.Value.Percent = Math.Round(((double)keyValue.Value.Count / totalCombinations) * 100, 2);
            }

            return combinationsAndCounts;
        }

        public static Dictionary<string,CountAndPercent> GetDictionaryToCompareFrom(Dictionary<string, CountAndPercent> dictionary)
        {
            Dictionary<string, CountAndPercent> sortedDictionary = dictionary.OrderByDescending(keyValue => keyValue.Value.Count).ToDictionary(x => x.Key, x => x.Value);
            Dictionary<string, CountAndPercent> dictionaryToCompare = new Dictionary<string, CountAndPercent>();
            int limit = 10;
            if(sortedDictionary.Count < limit)
            {
                limit = sortedDictionary.Count;
            }

            for (int i = 1; i <= limit; i++)
            {
                sortedDictionary.First().Value.Place = i;
                dictionaryToCompare.Add(sortedDictionary.First().Key, sortedDictionary.First().Value);
                sortedDictionary.Remove(sortedDictionary.First().Key);
            }

            return dictionaryToCompare;
        }

        public static string GetTable(Dictionary<string, CountAndPercent> dictionaryToCompare)
        {
            string table = "";
            for (int i = dictionaryToCompare.First().Value.Count; i >= 0; i--)
            {

                for (int j = 1; j <= dictionaryToCompare.Count(); j++)
                {

                    if (dictionaryToCompare.Where(x => x.Value.Place == j).First().Value.Count > i)
                    {
                        Console.Write("* *\t");
                        table += "* *\t";
                    }
                    else if (dictionaryToCompare.Where(x => x.Value.Place == j).First().Value.Count < i)
                    {
                        Console.Write("   \t");
                        table += "   \t";
                    }
                    else
                    {
                        Console.Write("***\t");
                        table += "***\t";
                    }
                    if (j == dictionaryToCompare.Count())
                    {
                        Console.Write(i);
                        table += i;
                    }
                }
                Console.WriteLine();
                table += "\n";
            }

            foreach (var keyValue in dictionaryToCompare)
            {
                Console.Write(keyValue.Key + " " + "\t");
                table += keyValue.Key + " " + "\t";
            }

            Console.WriteLine();
            table += "\n";

            foreach(var keyValue in dictionaryToCompare)
            {
                Console.Write(keyValue.Value.Percent + "%" + "\t");
                table += keyValue.Value.Percent + "%" + "\t";
            }

            return table;
        }
    }
}
