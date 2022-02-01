using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyReport.Models
{
    public class Test
    {
        public int Id { get; set; }
        public int SampleId { get; set; }
        public Sample Sample { get; set; }
        public Patient Patient { get; set; }
        public UserProfile UserProfile { get; set; }
        public int PatientId { get; set; }
        public bool Results { get; set; }
        public DateTime CollectionDate { get; set; }
        public int ProviderId { get; set; }
        public DateTime CompletedDate { get; set; }
    }
}
