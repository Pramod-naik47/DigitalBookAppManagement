using System;
using System.Collections.Generic;

namespace Author.Models
{
    public partial class Book
    {
        public Book()
        {
            Payments = new HashSet<Payment>();
        }

        public long BookId { get; set; }
        public byte[]? Logo { get; set; }
        public string? BookTitle { get; set; }
        public string? Category { get; set; }
        public decimal? Price { get; set; }
        public long? UserId { get; set; }
        public string? Publisher { get; set; }
        public DateTime? PublishDate { get; set; } = DateTime.Now;
        public string? Content { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;

        public virtual User? User { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
