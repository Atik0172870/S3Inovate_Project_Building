using Building.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Building.Repository
{
   public interface IReadRepository
    {
        List<Reading> GetReadings(int? buildingId, int? objectId, int? datafieldId, string fromDate, string toDate);
    }
}
