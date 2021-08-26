using Relativity.Services.Interfaces.Field;
using System.Collections.Generic;

namespace ConsoleApp1.DataProvider.DataProviderNet.Interfaces
{
    public interface IFieldNetDataProvider
    {
        void CreateLongTextField(IFieldManager helper, List<string> fieldNames);
    }
}
