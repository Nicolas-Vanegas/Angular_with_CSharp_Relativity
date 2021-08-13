using ConsoleApp1.RepositoryRest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1.RepositoryRest
{
    public class WordsRepository : IWordsRepository
    {
        public IList<string> filteredWords(List<string> documentTexts, int wordLength, bool net)
        {
            var filteredWords = new List<string>();

            Regex regexToRemoveSpecialCharacters = new Regex(@"^[!#$%&'()*+,-./:;?@[\]^_]*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);

            var replacedText = documentTexts.Select(x => Regex.Replace(x, @"\r\n?|\n|\\n", " ")).ToList();

            foreach (var item in documentTexts)
            {
                var trim = item;
                if (!net)
                {
                    trim = item.Substring(0 + 6);
                }
                var withoutLineBreak = Regex.Replace(trim, @"\r\n?|\n|\\n", " ");
                string[] words = withoutLineBreak.Split(' ');
                var wordsList = words.ToList();
                wordsList.RemoveAll(word => word == "");
                if (!net)
                {
                    wordsList.RemoveRange(wordsList.Count - 2, 2);
                }
                foreach (var word in wordsList)
                {
                    var wordWithoutSpecialCharacters = regexToRemoveSpecialCharacters.Replace(word, String.Empty);
                    var theWord = Regex.Replace(word, @"[^0-9a-zA-Z]+", "");
                    if (theWord.Length == wordLength)
                    {
                        filteredWords.Add(theWord);
                    }
                }
            }


            return filteredWords;
        }
    }
}
