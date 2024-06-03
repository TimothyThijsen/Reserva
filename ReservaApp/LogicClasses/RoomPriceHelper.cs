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
		const decimal reservaFee = 0.8m;
		public static decimal GetTotalPriceExcl(decimal price, DateRange dateRange)
		{
			decimal totalPrice = 0;
			totalPrice = price * (dateRange.GetDaysCount()+1);
			return totalPrice;
		}
		public static decimal CalculateFees(decimal priceExcl)
		{
			return priceExcl * reservaFee;
		}
		public static decimal GetTotalPriceIncl(decimal priceExcl)
		{
			return priceExcl + CalculateFees(priceExcl);
		}
	}
}
