using System.Collections.Generic;

namespace ConsoleApp1.Repositories.RepositoriesNet.Inferfaces
{
    public interface IFieldNetRepository
    {
        void CreateLongTextField(ServicesMgr helper, List<string> fieldNames);
    }
}
