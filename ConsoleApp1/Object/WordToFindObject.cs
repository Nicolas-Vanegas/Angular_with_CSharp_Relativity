using Relativity.Services.Objects.DataContracts;

namespace ConsoleApp1.Object
{
    public class WordToFindObject
    {
        public string Name { get; set; }
        public string Meaning { get; set; }
        public ObjectTypeRef Document { get; set; }

        public string Origin { get; set; }
        public string UrlAudio { get; set; }
    }
}
