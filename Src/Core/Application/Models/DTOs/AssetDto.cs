using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs
{
    public class AssetDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? MacAddress { get; set; }
        public int? CategoryId { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdatedUser { get; set; }
    }
    public enum AssetStatus
    {
        Caution = 1,
        Usable = 2,
        Down = 3,
        Passive = 4,
    }
}
