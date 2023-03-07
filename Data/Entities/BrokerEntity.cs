using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class BrokerEntity
    {
        public Guid BrokerId { get; set; }
        public string BrokerName { get; set; } = default!;
    }
}
