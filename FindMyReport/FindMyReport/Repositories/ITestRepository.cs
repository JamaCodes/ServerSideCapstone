using FindMyReport.Models;
using System.Collections.Generic;

namespace FindMyReport.Repositories
{
    public interface ITestRepository
    {
        void Add(Test test);
        List<Test> GetAll();
    }
}