using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class Principal
    {
        public long Id { get; set; }
        public string? InsertUser { get; set; }
        public DateTime InsertDate { get; set; }
        public string? UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Username { get; set; } = null!;
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }
        public string? Role { get; set; }
        public bool Disabled { get; set; }
        public string? TaxCode { get; set; }
        public string? Language { get; set; }
        public string? City { get; set; }
        public string? MobilePhone { get; set; }
        public string? District { get; set; }
        public string? Cap { get; set; }
        public string? Notes { get; set; }
        public bool AgendaLocked { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
    }
}
