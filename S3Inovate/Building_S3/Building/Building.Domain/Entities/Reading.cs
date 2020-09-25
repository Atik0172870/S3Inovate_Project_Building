using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Building.Domain.Entities
{
    [Table("Reading")]
    public class Reading
    {
        public long Id { get; set; }
        public short BuildingId { get; set; }
        public byte ObjectId { get; set; }
        public byte DataFieldId { get; set; }
        public decimal Value { get; set; }
        public Nullable<System.DateTime> TimeStamp { get; set; }
    }
}
