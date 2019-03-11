using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NgoProjectk3.Models
{
    public class Category
    {
        public Category (){
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Status = CategoryStatus.Active;

        }
        [Key]
        public int Id { get; set; }
        [DisplayName("Name Event")]
        [Required(ErrorMessage = "This item cannot be left blank")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [DisplayName("Description")]
        [DataType(DataType.Text)]
        public CategoryStatus Status { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
    public enum CategoryStatus
    {
        Active = 1,
        Deactive = 0
    }
}