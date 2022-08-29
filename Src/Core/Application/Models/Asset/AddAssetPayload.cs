using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Asset
{
    public class AddAssetPayload
    {
        public string? Name { get; set; }
        public string MacAddress { get; set; } = null!;
        public int? CategoryId { get; set; }
    }
}
