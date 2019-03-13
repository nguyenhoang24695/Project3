using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgoProjectk3.Models
{
    public class Interested
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int CategoryId { get; set; }
        public Account Account { get; set; }
        public Category Category { get; set; }
    }
}