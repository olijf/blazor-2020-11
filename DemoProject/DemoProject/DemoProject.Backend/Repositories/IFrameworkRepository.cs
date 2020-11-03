using DemoProject.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoProject.Backend.Repositories
{
    public interface IFrameworkRepository
    {
        Task<FrameworkModel> Add(FrameworkModel newFramework);
        Task<FrameworkModel> Get(int id);
        Task<IEnumerable<FrameworkModel>> Query();
    }
}