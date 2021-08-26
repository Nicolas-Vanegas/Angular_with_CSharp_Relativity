using Relativity.Services.Interfaces.Field;
using System.Collections.Generic;

namespace ConsoleApp1.Domain.DomainNet.Interfaces
{
    public interface IFieldNetService
    {
        void CreateLongTextField(IFieldManager helper, List<string> fieldNames);
    }
}
