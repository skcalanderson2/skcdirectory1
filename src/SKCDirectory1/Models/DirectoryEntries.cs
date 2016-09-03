using System;
using System.Collections.Generic;

namespace SKCDirectory1.Models
{
    public partial class DirectoryEntries
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Building { get; set; }
        public string OfficeNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Department { get; set; }
    }
}
