using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NgoProjectk3.Models
{
    
    public class Account
    {
        public Account()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Status = AccountStatus.Active;
        }
        [Key]
        public int Id { get; set; }
        [DisplayName("UserName")]
        public string UserName { get; set; }
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Salt { get; set; }
        public int Role { get; set; }
        public AccountStatus Status { get; set; }
        [DisplayName("FullName ")]
        public string FullName { get; set; }
        [DisplayName("Gender")]
        public int Gender { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("PhoneNumber")]
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
    public enum AccountStatus
    {
        Active = 1,
        Deactive = 0
    }
}