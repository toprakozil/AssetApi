using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class AuditableSoftDeletableEntity
    {
        [Key]
        public long Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdatedUser { get; set; }
        public DateTime? DeletedDate { get; set; }
        public long? DeletedUser { get; set; }

        //TODO constructor
        //public AuditableSoftDeletableEntity()
        //{
        //    UpdatedDate = DateTime.Now; //and private set for others
        //}
    }
}
