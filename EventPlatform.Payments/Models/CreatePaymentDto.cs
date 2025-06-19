using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlatform.Payments.Models
{
    public class CreatePaymentDto
    {
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
    }
}
