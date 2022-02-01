using FindMyReport.Models;
using System.Collections.Generic;

namespace FindMyReport.Repositories
{
    public interface IPatientRepository
    {
        void Add(Patient patient);
        List<Patient> GetAll();
    }
}