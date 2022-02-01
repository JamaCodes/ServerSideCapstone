using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindMyReport.Utils;
using FindMyReport.Models;
using Microsoft.Data.SqlClient;

namespace FindMyReport.Repositories
{
    public class PatientRepository : BaseRepository, IPatientRepository
    {
        public PatientRepository(IConfiguration config) : base(config) { }
        public List<Patient> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                       SELECT p.Id, p.FirstName, p.LastName, 
                              p.Address,
                              p.City, p.State, p.ZipCode,
                              p.Phone, p.DOB, p.RaceId,
                              r.[Name] AS Name, r.Id as Id
                         FROM Patient p
                              LEFT JOIN Race r ON p.RaceId = R.id
                             ";

                    var patients = new List<Patient>();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        patients.Add(NewPatientFromReader(reader));
                    }
                    reader.Close();
                    return patients;
                }
            }
        }
        public void Add(Patient patient)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Patient (
                            FirstName, LastName, Address, City, State, ZipCode, Phone, DOB, RaceId)
                        OUTPUT INSERTED.ID
                        VALUES (
                           @FirstName, @LastName, @Address, @City, @State, @ZipCode, @Phone, @DOB, @RaceId)";
                    cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", patient.LastName);
                    cmd.Parameters.AddWithValue("@Address", patient.Address);
                    cmd.Parameters.AddWithValue("@City", patient.City);
                    cmd.Parameters.AddWithValue("@State", patient.State);
                    cmd.Parameters.AddWithValue("@ZipCode", patient.ZipCode);
                    cmd.Parameters.AddWithValue("@Phone", patient.Phone);
                    cmd.Parameters.AddWithValue("@DOB", patient.DOB);
                    cmd.Parameters.AddWithValue("@RaceId", patient.RaceId);
                    patient.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
        private Patient NewPatientFromReader(SqlDataReader reader)
        {
            return new Patient()
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                Address = DbUtils.GetString(reader, "Address"),
                City = DbUtils.GetString(reader, "City"),
                State = reader.GetString(reader.GetOrdinal("State")),
                ZipCode = reader.GetString(reader.GetOrdinal("ZipCode")),
                Phone = DbUtils.GetString(reader, "Phone"),
                DOB = reader.GetDateTime(reader.GetOrdinal("DOB")),
                RaceId = reader.GetInt32(reader.GetOrdinal("RaceId")),
                Race = new Race()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name"))
                },
            };
        }
    }
}
