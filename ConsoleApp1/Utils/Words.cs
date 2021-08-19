using ConsoleApp1.Connections;
using ConsoleApp1.Object;
using ConsoleApp1.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1.RepositoryRest
{
    public class Words : IWords
    {
        public List<WordWithDocumentArtifactIdObject> filteredWords(List<DocumentWithExtractedTextObject> documentWithExtractedText, int wordLength)
        {
            var filteredWords = new List<WordWithDocumentArtifactIdObject>();

            Regex regexToRemoveSpecialCharacters = new Regex(@"^[!#$%&'()*+,-./:;?@[\]^_]*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);

            var replacedText = documentWithExtractedText.Select(x => Regex.Replace(x.ExtractedText, @"\r\n?|\n|\\n", " ")).ToList();

            foreach (var document in documentWithExtractedText)
            {
                var trim = document.ExtractedText.Substring(0 + 6);

                var withoutLineBreak = Regex.Replace(trim, @"\r\n?|\n|\\n", " ");
                string[] words = withoutLineBreak.Split(' ');
                var wordsList = words.ToList();
                wordsList.RemoveAll(word => word == "");
                wordsList.RemoveRange(wordsList.Count - 2, 2);
                foreach (var word in wordsList)
                {
                    var wordWithoutSpecialCharacters = regexToRemoveSpecialCharacters.Replace(word, String.Empty);
                    var theWord = Regex.Replace(word, @"[^a-zA-Z]+", "");
                    if (theWord.Length == wordLength)
                    {
                        var wordWithDocID = new WordWithDocumentArtifactIdObject() { ArtifactID = document.ArtifactID, Word = theWord.ToLower() };
                        filteredWords.Add(wordWithDocID);
                    }
                }
            }
            return filteredWords;
        }
        public List<WordWithDocumentArtifactIdObject> duplicateWordFilter(List<WordWithDocumentArtifactIdObject> filteredWords)
        {
            var filteredList = new List<WordWithDocumentArtifactIdObject>(filteredWords);
            var words = filteredWords.Select(x => x.Word).ToList();
            foreach (var grouping in words.GroupBy(t => t).Where(t => t.Count() != 1))
            {
                var groupingKey = grouping.Key;
                var groupingCount = grouping.Count();
                var i = 1;

                foreach (var filtered in filteredWords)
                {
                    if (i < groupingCount)
                    {
                        if (filtered.Word.ToLower() == groupingKey.ToLower() && i < groupingCount)
                        {
                            filteredList.Remove(filtered);
                            i++;
                        }
                    }
                }

            }
            return filteredList;
        }
        public List<DictionaryAndDocId> GetDictionary(List<WordWithDocumentArtifactIdObject> filteredWords, int wordLengthNet)
        {
            var definitionsFound = new List<DictionaryAndDocId>();
            var connection = new WebClientConnection();
            foreach (var word in filteredWords)
            {
                var dictionaryJson = connection.GetJsonDictionary(word.Word);
                if (!String.IsNullOrEmpty(dictionaryJson))
                {
                    var dictionary = JsonConvert.DeserializeObject<List<DictionaryObject>>(dictionaryJson);
                    var dictionaryAndDocumentId = new DictionaryAndDocId() { dictionaryObjects = dictionary, artifactId = word.ArtifactID };
                    if (dictionaryAndDocumentId.dictionaryObjects.FirstOrDefault().word.Length == wordLengthNet)
                    {
                        definitionsFound.Add(dictionaryAndDocumentId);
                    }
                }
            }
            return definitionsFound;
        }
    }
}
