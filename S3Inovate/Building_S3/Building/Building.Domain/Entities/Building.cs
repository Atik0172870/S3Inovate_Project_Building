using System;
using System.Collections.Generic;
using System.Text;

namespace Building.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Building
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
