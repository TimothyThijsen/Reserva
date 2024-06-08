using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class ActivitySchedule : ISchedule
    {
        public void AddReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public int GetAvailability(DateRange dateRange, Room room)
        {
            throw new NotImplementedException();
        }

        public void RemoveReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
