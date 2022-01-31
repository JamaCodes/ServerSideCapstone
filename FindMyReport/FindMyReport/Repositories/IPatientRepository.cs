using FindMyReport.Models;
using System.Collections.Generic;

namespace FindMyReport.Repositories
{
    public interface IPatientRepository
    {
        List<Patient> GetAll();
    }
}