using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Building.DataContext;
using Building.Domain.Entities;

namespace Building.Repository
{
    public class ReadRepository : IReadRepository
    {
        private readonly SqlServerContext _sqlServerContext;
        public ReadRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentNullException(nameof(sqlServerContext));

        }
        public List<Reading> GetReadings(int? buildingId, int? objectId, int? datafieldId, string fromDate, string toDate)
        {
            //var response = _sqlServerContext.Readings.ToList();

            var reading = _sqlServerContext.Readings.Where(x => (buildingId != null ? x.BuildingId == buildingId : buildingId == 0)
             && (objectId != null ? x.ObjectId == objectId : objectId == 0) && (datafieldId != null ? x.DataFieldId == datafieldId : datafieldId == 0)
             && (x.TimeStamp >= Convert.ToDateTime(fromDate) && x.TimeStamp <= Convert.ToDateTime(toDate))).Select(x => new Reading()
             {
                 Id = x.Id,
                 BuildingId = x.BuildingId,
                 ObjectId = x.ObjectId,
                 DataFieldId = x.DataFieldId,
                 Value = x.Value,
                 TimeStamp = x.TimeStamp
             }
             ).ToList();

            return reading;
        }
    }
}
