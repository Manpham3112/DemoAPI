using SaleManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Users;

namespace SaleManagement.Users
{
    public class AppUser : FullAuditedAggregateRoot<Guid>, IUser
    {
        #region Base properties

        public virtual Guid? TenantId { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual string Email { get; set; }

        public virtual bool EmailConfirmed { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual bool PhoneNumberConfirmed { get; set; }

        #endregion

        [DataType(DataType.DateTime)]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public bool Locked { get; set; }

        public int FailedLoginsNumber { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? LastLockedDate { get; set; }

        public ICollection<SaleReceipt> SaleReceipts { get; set; }

        public ICollection<ImportReceipt> ImportReceipts { get; set; }

        private AppUser()
        {

        }

        public AppUser(Guid id) : base(id)
        {

        }
    }
}
