using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NgoProjectk3.Models
{
    public class DonateProgram
    {
        public DonateProgram()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Status = ProgramStatus.Active;
            this.DonatedMoney = 0;
        }
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        [DisplayName("FundRaising Money")]
        public long Amount { get; set; }
        public long? DonatedMoney { get; set; }

        public string ThumbnailUrl { get; set; }
        public ProgramStatus Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartedAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Category Category { get; set; }
    }
    public enum ProgramStatus
    {
        Active = 1,
        DeActive = 0,
        Deleted = -1
    }
}