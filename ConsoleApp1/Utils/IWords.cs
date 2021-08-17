using System.Collections.Generic;

namespace ConsoleApp1.Utils
{
    public interface IWords
    {
        IList<string> filteredWords(List<string> documentTexts, int wordLength, bool net);
    }
}
