using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BolForce.Domain.Entities
{
    public class BaseEntity<TKeyType>
    {
        public TKeyType Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        [MaxLength(100)]
        public string CreatedBy { get; set; }
        [MaxLength(100)]
        public string LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string UpdatedIp { get; set; }
    }
}
