using ConsoleApp1.Common.Constants;
using ConsoleApp1.Object;
using ConsoleApp1.Repositories.RepositoriesNet.Inferfaces;
using ConsoleApp1.Utils;
using Relativity.Services.Objects;
using Relativity.Services.Objects.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Repositories.RepositoriesNet
{
    public class WordFoundNetRepository : IWordFoundNetRepository
    {
        private readonly IWords _words;
        public WordFoundNetRepository(IWords words)
        {
            _words = words;
        }
        public void CreateWordFoundObject(ServicesMgr helper, List<WordWithDocumentArtifactIdObject> filteredWords, int wordLengthNet)
        {
            var definitionsFound = _words.GetDictionary(filteredWords, wordLengthNet);
            var extractedTextAndDocumentArtifactId = new List<DocumentWithExtractedTextObject>();
            var documentTextExtractedList = new List<string>();
            var values = new List<List<object>>();
            foreach (var definitionFound in definitionsFound)
            {
                foreach (var definition in definitionFound.dictionaryObjects)
                {
                    if (definition.word.Length == wordLengthNet)
                    {
                        //var si = (object)null;
                        //if (nocas.Count >= 1)
                        //{
                        //    si = nocas.FirstOrDefault().Find(x => x == definition.word);
                        //}
                        //if (si == null)
                        //{
                        var urlAudio = definition.phonetics.Count() >= 1 ? definition.phonetics.FirstOrDefault().audio : "";
                        var ee = new List<object>
                        {
                            definition.word,
                            new RelativityObjectRef { ArtifactID = definitionFound.artifactId},
                            String.Join(".", definition.meanings.Select(x => x.definitions).FirstOrDefault().Select(f => f.definition).ToList()),
                            definition.origin,
                            urlAudio
                        };
                        values.Add(ee);
                        //};
                    }
                }
            }
            var massCreateRequest = new MassCreateRequest
            {
                ObjectType = new ObjectTypeRef
                {
                    Name = Constants.WORD_FOUND_NAME
                },
                Fields = new List<FieldRef>()
                {
                    new FieldRef { Name = Constants.WORD_FOUND_FIELD_NAME},
                    new FieldRef { Name = Constants.WORD_FOUND_FIELD_DOCUMENT},
                    new FieldRef { Name = Constants.WORD_FOUND_FIELD_MEANING},
                    new FieldRef { Name = Constants.WORD_FOUND_FIELD_ORIGIN},
                    new FieldRef { Name = Constants.WORD_FOUND_FIELD_AUDIO},

                },
                ValueLists = values
            };
            try
            {
                using (var objectManager = helper.CreateProxy<IObjectManager>())
                {
                    var result = objectManager.CreateAsync(Constants.WORKSPACE_ID, massCreateRequest).ConfigureAwait(false).GetAwaiter().GetResult();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
    }
}
