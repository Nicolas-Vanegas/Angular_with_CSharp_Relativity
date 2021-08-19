using ConsoleApp1.Object;
using System.Collections.Generic;

namespace ConsoleApp1.Utils
{
    public interface IWords
    {
        List<WordWithDocumentArtifactIdObject> filteredWords(List<DocumentWithExtractedTextObject> documentTexts, int wordLength);
        List<WordWithDocumentArtifactIdObject> duplicateWordFilter(List<WordWithDocumentArtifactIdObject> filteredWords);
        List<DictionaryAndDocId> GetDictionary(List<WordWithDocumentArtifactIdObject> filteredWords, int wordLengthNet);
    }
}
