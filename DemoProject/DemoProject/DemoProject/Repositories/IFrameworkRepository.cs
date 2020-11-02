using DemoProject.Models;
using System.Collections.Generic;

namespace DemoProject.Repositories
{
    public interface IFrameworkRepository
    {
        void Add(FrameworkModel newFramework);
        FrameworkModel Get(int id);
        IEnumerable<FrameworkModel> Query();
    }
}