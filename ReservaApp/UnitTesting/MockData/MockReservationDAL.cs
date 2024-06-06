using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.MockData
{
    public class MockReservationDAL : IReservationDAL
    {
        private List<Reservation> reservations;

        public MockReservationDAL()
        {
            DateTime today = DateTime.Today;
            reservations = new List<Reservation>
            {
               
                new RoomReservation(1,2,100,new DateTime(today.Year,today.Month,today.Day,11,00,00),new DateTime(today.Year,today.Month,today.Day+2,16,00,00)),
                new RoomReservation(1,2,100,new DateTime(today.Year,today.Month,today.Day,11,00,00),new DateTime(today.Year, today.Month, today.Day+2,16,00,00)),
                new RoomReservation(1,2,100,new DateTime(today.Year,today.Month,today.Day+2,11,00,00),new DateTime(today.Year, today.Month, today.Day+5,16,00,00)),
                new RoomReservation(1,2,100,new DateTime(today.Year,today.Month,today.Day+2,11,00,00),new DateTime(today.Year, today.Month, today.Day+5,16,00,00)),
                new RoomReservation(1,2,100,new DateTime(today.Year,today.Month,today.Day+2,11,00,00),new DateTime(today.Year, today.Month, today.Day+5,16,00,00)),
                new RoomReservation(1,2,100,new DateTime(today.Year,today.Month,today.Day+2,11,00,00),new DateTime(today.Year, today.Month, today.Day+5,16,00,00)),
                new RoomReservation(1,2,100,new DateTime(today.Year,today.Month,today.Day+2,11,00,00),new DateTime(today.Year, today.Month, today.Day+5,16,00,00))
            };
            foreach (RoomReservation rm in reservations)
            {
                rm.ReservedRooms = new List<ReservedRoom> {
                new ReservedRoom(1,1)
                };
            }
        }
        public void CreateReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public void UpdateReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetAllReservationByMember(int userId)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetAllReservationByEntityId(int entityId)
        {
            return reservations;
        }

        public Reservation GetByReservationId(int id)
        {
            throw new NotImplementedException();
        }

        public int GetAvailability(DateRange dateRange, int entityId)
        {
            throw new NotImplementedException();
        }
    }
}
