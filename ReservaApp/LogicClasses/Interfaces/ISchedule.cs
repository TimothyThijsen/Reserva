using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface ISchedule

    {
        void AddReservation(Reservation reservation);
        void RemoveReservation(Reservation reservation);
        int GetAvailability(DateRange dateRange, Room room);

    }
}
