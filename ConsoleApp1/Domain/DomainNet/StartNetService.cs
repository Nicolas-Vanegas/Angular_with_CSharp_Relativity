﻿using ConsoleApp1.Common.Constants;
using ConsoleApp1.Connections;
using ConsoleApp1.Domain.DomainNet.Interfaces;
using ConsoleApp1.Domain.DomainRest.Interfaces;
using ConsoleApp1.RepositoryRest;
using ConsoleApp1.Utils;
using System.Collections.Generic;

namespace ConsoleApp1.Domain.DomainNet
{
    public class StartNetService : IStartNetService
    {
        private readonly IInstanceSettingNetService _instanceSettingNetService;
        private readonly IDocumentNetService _documentNetService;
        private readonly IObjectTypeNetService _objectTypeNetService;
        private readonly IFieldNetService _fieldNetService;
        private readonly IFieldRestService _fieldRestService;
        private readonly IWordFoundNetService _wordFoundNetService;
        private readonly IWords _words;

        static int _savedSearchId = 1047249;
        private static InstanceSettingObject _instanceSettingsObject = new InstanceSettingObject()
        {
            Name = "Example 34",
            Value = 10,
            InitialValue = 10,
            Description = "Example 30",
            Section = "Example 30",
        };
        private static List<string> _longTextFieldName = new List<string>() { "LongText ingore x6" };
        private static List<string> _multiObjectFieldName = new List<string>() { "multiobject ignore X7" };

        public StartNetService(
            IInstanceSettingNetService instanceSettingNetService,
            IDocumentNetService documentNetService,
            IObjectTypeNetService objectTypeNetService,
            IFieldNetService fieldNetService,
            IFieldRestService fieldRestService,
            IWordFoundNetService wordFoundNetService,
            IWords words
        )
        {
            _instanceSettingNetService = instanceSettingNetService;
            _documentNetService = documentNetService;
            _objectTypeNetService = objectTypeNetService;
            _fieldNetService = fieldNetService;
            _fieldRestService = fieldRestService;
            _wordFoundNetService = wordFoundNetService;
            _words = words;
        }
        void IStartNetService.startApplication()
        {
            //connections
            var stringsConnection = new StringsConnection();
            var connection = ServicesMgr.GetInstance(stringsConnection.GetStringsConnection());
            var restConnection = new HttpClientConnection();

            //Create Instance Setting
            _instanceSettingNetService.CreateInstanceSetting(_instanceSettingsObject, connection);

            var documentTextsNet = _documentNetService.GetDocumentsBySavedSearchId(_savedSearchId, connection);
            var wordLengthNet = _instanceSettingNetService.GetInstanceSettingValue(Constants.INSTANCE_SETTING_ID, connection);

            //Filter the words
            var filteredWordsNet = _words.filteredWords(documentTextsNet, wordLengthNet);
            var duplicateWordFilter = _words.duplicateWordFilter(filteredWordsNet);

            //Create ObjectType and theirs fields
            _objectTypeNetService.CreateObjectType(connection);
            _fieldNetService.CreateLongTextField(connection, _longTextFieldName);
            _fieldRestService.CreateMultiObjectField(restConnection, _multiObjectFieldName);

            //Create Word Found objects
            _wordFoundNetService.CreateWordFoundObject(connection, duplicateWordFilter, wordLengthNet);
        }
    }
}
