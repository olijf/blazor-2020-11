using DemoProject.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoProject.Repositories
{
    public interface IFrameworkRepository
    {
        Task Add(FrameworkModel newFramework);
        Task<FrameworkModel> Get(int id);
        Task<IEnumerable<FrameworkModel>> Query();
    }
}