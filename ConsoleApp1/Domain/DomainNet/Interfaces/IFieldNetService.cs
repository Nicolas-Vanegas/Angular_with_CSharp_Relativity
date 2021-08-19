using System.Collections.Generic;

namespace ConsoleApp1.Domain.DomainNet.Interfaces
{
    public interface IFieldNetService
    {
        void CreateLongTextField(ServicesMgr helper, List<string> fieldNames);
    }
}
