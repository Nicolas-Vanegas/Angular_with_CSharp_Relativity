using System.Collections.Generic;

namespace ConsoleApp1.Object
{
    public class DictionaryObject
    {
        public string word { get; set; }
        public string phonetic { get; set; }
        public List<PhoneticObject> phonetics { get; set; }
        public string origin { get; set; }
        public List<MeaningObject> meanings { get; set; }
    }
}
