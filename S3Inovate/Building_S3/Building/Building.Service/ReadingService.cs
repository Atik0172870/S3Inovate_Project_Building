using System;
using System.Collections.Generic;
using System.Text;
using Building.Domain.Entities;
using Building.Repository;

namespace Building.Service
{
   public class ReadingService : IReading
    {
        private readonly IReadRepository _readRepository;
       public ReadingService(IReadRepository readRepository)
        {
            _readRepository = readRepository;
        }
        public List<Reading> GetReadingsData(int buildingId, int objectId, int dataFieldId, string fromDate, string toDate)
        {
          return _readRepository.GetReadings(buildingId, objectId, dataFieldId,fromDate,toDate);
        }
    }
}
