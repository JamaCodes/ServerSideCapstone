using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FindMyReport.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(28, MinimumLength = 28)]
        public string FirebaseUserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
       
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(255)]
        public string Phone { get; set; }

        
        [MaxLength(30)]
        public string State { get; set; }

        public bool IsProvider { get; set; }

        public string Email { get; set; }

   

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}