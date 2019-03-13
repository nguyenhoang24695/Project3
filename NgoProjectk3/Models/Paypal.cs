using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NgoProjectk3.Models
{
    public class Paypal
    {
        [Key]
        public string OrderID { get; set; }
    }

    public class PaypalAccess
    {
        public string grant_type { get; set; }
    }
}