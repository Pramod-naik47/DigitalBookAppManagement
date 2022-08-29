using System;
using System.Collections.Generic;

namespace Author.Models
{
    public partial class VBook2User
    {
        public long BookId { get; set; }
        public string? BookTitle { get; set; }
        public string? Category { get; set; }
        public decimal? Price { get; set; }
        public string? Content { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public string? Publisher { get; set; }
        public string UserName { get; set; } = null!;
        public string? UserType { get; set; }
        public string? Email { get; set; }
        public long UserId { get; set; }
        public decimal? PhoneNumber { get; set; }
    }
}
