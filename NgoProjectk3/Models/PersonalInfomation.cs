using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NgoProjectk3.Models
{
    public class PersonalInfomation
    {
        [Key]
        public int AccountId { get; set; }
        public string FullName { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}