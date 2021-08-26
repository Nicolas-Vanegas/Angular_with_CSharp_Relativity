using Relativity.Services.Interfaces.Field;
using Relativity.Services.Interfaces.ObjectType;
using System.Collections.Generic;

namespace ConsoleApp1.Repositories.RepositoriesNet.Inferfaces
{
    public interface IFieldNetRepository
    {
        void CreateLongTextField(IFieldManager helper, List<string> fieldNames);
    }
}
