using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgoProjectk3.Models
{
    public class Category
    {
        public Category()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Status = CategoryStatus.Active;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
    public enum CategoryStatus
    {
        Active = 1,
        DeActive = 0,
        Deleted = -1
    }
}