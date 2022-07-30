using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
            ProductStoreMove = new HashSet<ProductStoreMove>();
        }

        public long Id { get; set; }
        public DateTime InsertDate { get; set; }
        public string? InsertUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? UpdateUser { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string City { get; set; } = null!;
        public string? Cap { get; set; }
        public string Address { get; set; } = null!;
        public int? AddressNumber { get; set; }
        public string? District { get; set; }
        public string? Country { get; set; }
        public string? Sex { get; set; }
        public string? Type { get; set; }
        public string? Phone { get; set; }
        public string? MobilePhone { get; set; }
        public string? Mail { get; set; }
        public string? TaxCode { get; set; }
        public string? VatCode { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? IdentificationDocType { get; set; }
        public string? IdentificationDocNumber { get; set; }
        public string? IdentificationDocCountry { get; set; }
        public DateTime? IdentificationDocReleaseDate { get; set; }
        public DateTime? IdentificationDocExpirationDate { get; set; }
        public DateTime? ContactDate { get; set; }
        public DateTime? RecallDate { get; set; }
        public string? Notes { get; set; }
        public DateTime? Disabled { get; set; }

        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<ProductStoreMove> ProductStoreMove { get; set; }
    }
}
