using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FindMyReport.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime DOB { get; set; }

        public Race Race { get; set; }
        [Required]
        public int RaceId { get; set; }






        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}