using ConsoleApp1.Object;
using ConsoleApp1.RepositoryRest;
using System.Collections.Generic;
using Xunit;
using Xunit.Categories;

namespace Test
{
    [UnitTest]
    public class Word
    {
        private readonly Words _wordsMock = new Words();
        [Fact]
        public void GetFilteredWords_PassDocument_ReturnFilteredWordsList()
        {
            //ARRANGE
            var sisas = new List<DocumentWithExtractedTextObject>()
            {
                new DocumentWithExtractedTextObject()
                {
                    ArtifactID = 1038450,
                    ExtractedText = "Exhibit 10(q) MODIFICATION AND EXTENSION AGREEMENT This MODIFICATION AND EXTENSION AGREEMENT (this Agreement) is made effective " +
                    "as of December 16, 2013, between SONO-TEK INDUSTRIAL PARK, LLC, a New York limited liability company, having offices at 2012 Route 9W, Building 3, " +
                    "Milton, New York 12547 (the Borrower) and M&T BANK, a/k/a Manufacturers and Traders Trust Company, a New York banking corporation having offices at " +
                    "One Fountain Plaza, Buffalo, New York 14203, Attn: M & T Real Estate Trust(the Lender). RECITALS A.Borrower is indebted to Lender in the principal " +
                    "sum of One Million Six Hundred Thousand and 00 / 100 Dollars($1, 600, 000.00) and Borrower and Lender desire to secure(1) the repayment of that " +
                    "indebtedness, with interest, and all renewals, extensions and modifications of such indebtedness, and(2) the performance of all of Borrowers " +
                    "obligations, covenants and agreements stated in and consolidated by this Agreement. B.Borrower has a fee estate in the real property, wi..."
                }
            };
            var wordLength = 10;

            //ACT
            var ex = _wordsMock.filteredWords(sisas, wordLength);

            //ASSERT
            Assert.NotEmpty(ex);
        }

        [Fact]
        public void GetFilteredWords_PassFilteredWords_ReturnDuplicateWordFilterList()
        {
            //ARRANGE
            var sisas = new List<WordWithDocumentArtifactIdObject>()
            {
                new WordWithDocumentArtifactIdObject()
                {
                    ArtifactID = 1038450,
                    Word = "Duplicated"
                },
                new WordWithDocumentArtifactIdObject()
                {
                    ArtifactID = 1038450,
                    Word = "Duplicated"
                },
                new WordWithDocumentArtifactIdObject()
                {
                    ArtifactID = 1038450,
                    Word = "NotDuplicate"
                },
                new WordWithDocumentArtifactIdObject()
                {
                    ArtifactID = 1038450,
                    Word = "EsteTampoco"
                },
            };

            //ACT
            var ex = _wordsMock.duplicateWordFilter(sisas);

            //ASSERT
            Assert.NotEmpty(ex);
        }

        [Fact]
        public void GetDictionary_PassFilteredWordsAndWordLength_ReturnWordsDictionary()
        {
            //ARRANGE
            var sisas = new List<WordWithDocumentArtifactIdObject>()
            {
                new WordWithDocumentArtifactIdObject()
                {
                    ArtifactID = 1038450,
                    Word = "Duplicated"
                },
                new WordWithDocumentArtifactIdObject()
                {
                    ArtifactID = 1038450,
                    Word = "Habitation"
                },
                new WordWithDocumentArtifactIdObject()
                {
                    ArtifactID = 1038450,
                    Word = "habilitate"
                },
            };
            var wordLength = 10;

            //ACT
            var ex = _wordsMock.GetDictionary(sisas, wordLength);

            //ASSERT
            Assert.NotEmpty(ex);
        }
    }
}
