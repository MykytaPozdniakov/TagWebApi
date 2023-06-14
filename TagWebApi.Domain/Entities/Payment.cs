using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagWebApi.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string PaymentMethod { get; set; } = "PayPal";
        public int TaskId { get; set; }
        public MainTask Task { get; set; }
        // Other properties...
    }
}
