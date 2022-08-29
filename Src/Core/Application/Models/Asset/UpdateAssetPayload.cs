using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Asset
{
    public class UpdateAssetPayload
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public int? StatusId { get; set; }
        public string? MacAddress { get; set; }
    }
}
