using System;
using System.Collections.Generic;

namespace Author.Models
{
    public partial class User
    {
        public User()
        {
            Books = new HashSet<Book>();
        }

        public long UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? UserType { get; set; }
        public string? Email { get; set; }
        public decimal? PhoneNumber { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
