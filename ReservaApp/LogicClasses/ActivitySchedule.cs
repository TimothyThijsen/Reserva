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
        List<Reservation> _activities;
        public void AddReservation(Reservation reservation)
        {
            _activities.Add(reservation);
        }
        public void RemoveReservation(Reservation reservation)
        {
            _activities.RemoveAt(_activities.FindIndex(r => r.Id == reservation.Id));
        }
    }
}
