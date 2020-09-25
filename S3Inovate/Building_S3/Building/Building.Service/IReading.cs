using System;
using System.Collections.Generic;
using System.Text;
using Building.Domain.Entities;

namespace Building.Service
{
    public interface IReading
    {
        List<Reading> GetReadingsData(int buildingId, int objectId, int dataFieldId, string fromDate, string toDate);
    }
}
