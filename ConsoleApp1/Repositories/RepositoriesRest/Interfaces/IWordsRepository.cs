using System.Collections.Generic;

namespace ConsoleApp1.RepositoryRest.Interfaces
{
    public interface IWordsRepository
    {
        IList<string> filteredWords(List<string> documentTexts, int wordLength, bool net);
    }
}
