using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseBookApp.Models
{
    public partial class Payment
    {
        public long PaymentId { get; set; }
        public string? Email { get; set; }
        public long? BookId { get; set; }
        public DateTime? PaymentDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
    }
}
