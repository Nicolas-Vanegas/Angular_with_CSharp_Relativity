using ConsoleApp1.Common.Constants;
using ConsoleApp1.Connections;
using ConsoleApp1.Domain.DomainNet.Interfaces;
using ConsoleApp1.Domain.DomainRest.Interfaces;
using ConsoleApp1.RepositoryRest;
using ConsoleApp1.Utils;
using System.Collections.Generic;

namespace ConsoleApp1.Domain.DomainRest
{
    public class StartRestService : IStartRestService
    {
        private readonly IInstanceSettingRestService _instanceSettingRestService;
        private readonly IDocumentRestService _documentRestService;
        private readonly IObjectTypeRestService _objectTypeRestService;
        private readonly IFieldNetService _fieldNetService;
        private readonly IFieldRestService _fieldRestService;
        private readonly IWordFoundNetService _wordFoundNetService;
        private readonly IWords _words;

        static int _savedSearchId = 1047249;
        private static InstanceSettingObject _instanceSettingObject = new InstanceSettingObject()
        {
            Name = "Example 35",
            Value = 10,
            InitialValue = 10,
            Description = "Example 30",
            Section = "Example 30",
        };
        private static List<string> _longTextFieldName = new List<string>() { "LongText ingore x7" };
        private static List<string> _multiObjectFieldName = new List<string>() { "multiobject ignore X7" };

        public StartRestService(
            IInstanceSettingRestService instanceSettingRestService,
            IDocumentRestService documentRestService,
            IObjectTypeRestService objectTypeRestService,
            IFieldNetService fieldNetService,
            IFieldRestService fieldRestService,
            IWordFoundNetService wordFoundNetService,
            IWords words)
        {
            _instanceSettingRestService = instanceSettingRestService;
            _documentRestService = documentRestService;
            _objectTypeRestService = objectTypeRestService;
            _fieldNetService = fieldNetService;
            _fieldRestService = fieldRestService;
            _wordFoundNetService = wordFoundNetService;
            _words = words;
        }
        public void startApplication()
        {
            //connection
            //var stringsConnection = new StringsConnection();
            //var connection = new HttpClientConnection();
            //var netConnection = ServicesMgr.GetInstance(stringsConnection.GetStringsConnection());
            //var created = true;

            ////Create Instance Setting
            //if (!created)
            //{
            //    var instanceSettingIdRest = _instanceSettingRestService.CreateInstanceSetting(_instanceSettingObject);
            //}

            //var pdfDocumentIds = _documentRestService.Documents(_savedSearchId);
            //var documentTextsRest = _documentRestService.DocumentTexts(pdfDocumentIds);
            //var wordLengthRest = _instanceSettingRestService.GetInstanceSettingValue(Constants.INSTANCE_SETTING_ID);

            ////Filter the words
            //var filteredWordsRest = _words.filteredWords(documentTextsRest, wordLengthRest);
            //var duplicateWordFilter = _words.duplicateWordFilter(filteredWordsRest);

            ////Create ObjectType and theirs fields
            //if (created)
            //{
            //    _objectTypeRestService.CreateObjectType(connection);
            //    _fieldNetService.CreateLongTextField(netConnection, _longTextFieldName);
            //    _fieldRestService.CreateMultiObjectField(connection, _multiObjectFieldName);
            //}
            ////Create Word Found objects
            //_wordFoundNetService.CreateWordFoundObject(netConnection, duplicateWordFilter, wordLengthRest);
        }
    }
}
