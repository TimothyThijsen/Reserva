using DomainLayer.Interfaces;
using DomainLayer.ServiceClasses;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{

	
	public static class RoomPriceHelper
	{
		public static decimal GetTotalPriceExcl(List<ReservedRoom> reservedRooms, List<Room> roomsAtHotel, TimeSpan numberOfDays)
		{
			decimal totalPrice = 0;
			foreach (var room in reservedRooms)
			{
				totalPrice += (room.Quantity * roomsAtHotel.Find(r => r.Id == room.RoomId).Price) * numberOfDays.Days;
			}
			return totalPrice;
		}
		public static decimal CalculateFees(decimal priceExcl)
		{
			return priceExcl * (decimal)0.08;
		}
		public static decimal GetTotalPriceIncl(decimal priceExcl)
		{
			return priceExcl + CalculateFees(priceExcl);
		}
	}
}
