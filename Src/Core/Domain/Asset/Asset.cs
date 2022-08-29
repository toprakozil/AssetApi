using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Asset
{
    public class Asset : AuditableSoftDeletableEntity
    {
        public string? Name { get; set; }
        public string MacAddress { get; set; } = null!;
        public int? CategoryId { get; set; }
        public int StatusId { get; set; }
    }
}
