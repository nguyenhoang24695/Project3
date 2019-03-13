using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgoProjectk3.Models
{
    public class Donation
    {
        public Donation()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Status = DonationStatus.Active;
        }
        public int Id { get; set; }
        public int DonorId { get; set; }
        public int ProgramId { get; set; }
        public float Amount { get; set; }
        public DonationStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Account Account { get; set; }
        public DonateProgram DonateProgram { get; set; }

    }
    public enum DonationStatus
    {
        Active = 1,
        DeActive = 0,
        Deleted = -1
    }
}